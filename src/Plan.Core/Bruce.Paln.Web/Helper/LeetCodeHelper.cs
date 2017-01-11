using System.IO;
namespace Bruce.Paln.Web.Helper
{
    public class LeetCodeHelper
    {
        public string GetAllQuestion()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\StaticData\\LeetCodeList.json";
                string questations = "";
                //using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                //{
                //    questations = reader.ReadToEnd();
                //}
                return questations;
            }
            catch
            {
                return "";
            }
        }
    }
}