using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyWebAPI
{
    public class EasyWebApi
    {
        private static int reponseCode = 0;
        public static int getStatusCode { get => reponseCode; }

        private static string zfilePath = "";

        private static string zname = "";

        private static string zfileName = "";

        public static  void addFile(string filePath, string name, string fileName)
        {
            zfilePath = filePath;
            zname = name;
            zfileName = fileName;

        }
        //private static List<KeyValuePair<string, string>> listGetHeaders = new List<KeyValuePair<string, string>>();

       // public static void addGetHeader(string value, string key)
       // {
       //     listGetHeaders.Add(new KeyValuePair<string, string> ( value, key ));
       // }
        private static List<string[]> listPostHeaders = new List<string[]>();

        public static void addHeader(string value, string key)
        {
            listPostHeaders.Add(new string[] { value, key });
        }
        private static byte[] readFile(string filepath) 
        {
            //Max file (4.2 GB)

            return File.ReadAllBytes(filepath);
        }

        public static string postFile(string actionUrl, bool hasHeader = false)
        {
            return post(actionUrl, true, hasHeader).Result;
        }

        public static string postHeader(string actionUrl)
        {
            return post(actionUrl, false, true).Result;
        }

        public static string getContent(string actionUrl)
        {
            return get(actionUrl).Result;
        }
        private static async Task<string> post(string actionUrl, bool hasFile, bool hasHeader=false)
        {
            using (var client = new HttpClient())
            {
                using (var content =
                    new MultipartFormDataContent("------------------------" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    if(hasFile) content.Add(new StreamContent(new MemoryStream(readFile(zfilePath))), zname, zfileName);

                    if (hasHeader) foreach (var vk in listPostHeaders) content.Add(new StringContent(vk[0]), vk[1]);

                    using (
                       var message = await client.PostAsync(actionUrl, content))
                    {
                        reponseCode = Int32.Parse(message.StatusCode.ToString());
                        listPostHeaders.Clear();
                        return await message.Content.ReadAsStringAsync();
                    }
                }
            }
        }

        private static async Task<string> get(string actionUrl)
        {
            using (var client = new HttpClient())
            { 
                    using (
                       var message = await client.GetAsync(actionUrl))
                    {
                        reponseCode = Int32.Parse(message.StatusCode.ToString());
                        return await message.Content.ReadAsStringAsync();
                    }
                
            }
        }


    }
}
