using System;
using System.Security.Cryptography;
using System.Text;

namespace Bruce.Paln.Core
{
    public class MD5Helper
    {

        #region RSA加密解密
        //加密
        public static string RSAEncrypt(string publickey, string content)
        {
            //publickey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            //rsa.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        public static string RSAEncrypt(string username)
        {
            //加密KEY
            string publickey2 = @"<RSAKeyValue><Modulus>sVzVUhOP1hBGNTPmBr5Bdxtm0C7XaJcw0Sov5Ljd91a2w1kT+AulRWtpGRSW7ao/e5iLuk3We1H634lv1kDEQ6+itNFAv/grruBYY69VFGYXM5WKctdN8W8YgzqlEue89jzCd5YrG6XvC1enCjO3Hv1GqUp1GRDnL9tti1pGZt0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            return RSAEncrypt(publickey2, username);
        }

        //解密
        public static string RSADecrypt(string privatekey, string content)
        {
            //privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            //rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        public static string RSADecrypt(string content)
        {
            string privatekey = @"<RSAKeyValue><Modulus>sVzVUhOP1hBGNTPmBr5Bdxtm0C7XaJcw0Sov5Ljd91a2w1kT+AulRWtpGRSW7ao/e5iLuk3We1H634lv1kDEQ6+itNFAv/grruBYY69VFGYXM5WKctdN8W8YgzqlEue89jzCd5YrG6XvC1enCjO3Hv1GqUp1GRDnL9tti1pGZt0=</Modulus><Exponent>AQAB</Exponent><P>8BnKQWTAkUqQ8RsuxaD4i0xSWzgwdycBR9gTUxhzhx95gRdMAI7ecHXoXkvIlI1eVi51KZgU7gNYXpPD0JmUZQ==</P><Q>vRuAPnMNnvtBa0Sn5mQxTgIXn9dLOmtReH3N6gTzftb9xwGaw0lc0oIsqZWHFedNMsOTpBu387xXYN4XlXY1GQ==</Q><DP>4I1uQLym8PuJFUXz93d2HGlz+MZTZYzAQN4QLL4Ihk5kh9wvA7KazRkpCs/btzuECBwJDa6jnHrachHGqFiKlQ==</DP><DQ>AFQ16uXkVix1tqwN5rax50LVq6+CL/3TzHPbkdakXcod8uSr0j8kbDFRxpG+BGm8lqQEc7qgnUnslPyN6fKksQ==</DQ><InverseQ>25/ej481MO0i/lOCjL9YHWE9uJGqt43JRCDD3jlAxoyyw9BM/w5oqTOWfaKswoCsiR8DXL7d5rUdJOorONb1nQ==</InverseQ><D>BHfIkMP0Y0dz0L4ABRGcBZJzEV9ZRs7dWr1AQFNDleWO9X+K45fQFILRGgZtHObcO0AwJp89xycUCACLZC9ifbLqGSB4BhjrrMx82FSJ9VX/Sbn7uN7UrlUnZnMfenToDhw+/Py+PCatfq49VosfWXzHyvkuItAZkWv1U19RwlE=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            //rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        #endregion


        #region MD5小写加密
        //新加的MD5小写
        public static string GetMD5(string str)
        {
            string convertStr;
            MD5 md5 = MD5.Create();//实例化一个MD5对象，也可以这样：  
            byte[] value = UTF8Encoding.UTF8.GetBytes(str);
            byte[] data = md5.ComputeHash(value);//使用十六进制类型格式  
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));//直接ToString()后的字符是小写的字母，如果使用大写则格式为ToString("X")  
            }
            convertStr = sb.ToString();

            return convertStr;
        }
        #endregion
    }
}
