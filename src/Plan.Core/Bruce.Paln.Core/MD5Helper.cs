using System.Security.Cryptography;
using System.Text;

namespace Bruce.Paln.Core
{
    public class MD5Helper
    {

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
    }
}
