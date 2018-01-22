using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradetool
{
    public class DriverHelper
    {
        public static void SaveSessionToDB(string sourceFolder, ChromeDriver driver, string url)
        {
            string fileName = CreateMD5(url) + ".txt";
            if (!Directory.Exists(sourceFolder))
                Directory.CreateDirectory(sourceFolder);
            var ListCookieNew = new List<OpenQA.Selenium.Cookie>();
            var current = driver.Manage().Cookies.AllCookies;
            foreach (OpenQA.Selenium.Cookie coi in current)
            {
                ListCookieNew.Add(coi);
            }
            string jsonstring = JsonConvert.SerializeObject(ListCookieNew);

            using (StreamWriter writer = new StreamWriter(string.Format("{0}{1}", sourceFolder, fileName), false, Encoding.UTF8))
            {
                writer.WriteLine(jsonstring);
            }
        }
        public static void LoadSessionFromDB(ChromeDriver driver, string pathSystemLocal, string url)
        {
            try
            {
                string filename = CreateMD5(url) + ".txt";
                string output = File.ReadAllText(pathSystemLocal + filename);
                if (!string.IsNullOrEmpty(output))
                {
                    var ListCookieNew = ConvertCookie(JsonConvert.DeserializeObject<List<CookieCus>>(output));
                    foreach (OpenQA.Selenium.Cookie cooki in ListCookieNew)
                    {
                        try
                        {
                            driver.Manage().Cookies.AddCookie(cooki);
                        }
                        catch
                        {

                        }

                    }
                }
            }
            catch
            { }
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static List<OpenQA.Selenium.Cookie> ConvertCookie(List<CookieCus> cookicus)
        {
            List<OpenQA.Selenium.Cookie> listResu = new List<OpenQA.Selenium.Cookie>();
            foreach (var item in cookicus)
            {
                OpenQA.Selenium.Cookie coki = new OpenQA.Selenium.Cookie(item.Name, item.Value, item.Domain, item.Path, item.Expiry);
                listResu.Add(coki);
            }
            return listResu;
        }

    }
    public class CookieCus
    {

        public string CurrentHost { get; set; }
        public string Secure { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public DateTime? Expiry { get; set; }
    }
}
