using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Teambuilderv2
{
    class OCRApi
    {
        private string Key { get; set;}
        private string uri { get; set; }

        public OCRApi()
        {
            Key = "3f5d480d6d88957";
            //  uri = $"https://api.ocr.space/parse/imageurl?apikey=" + Key + "&url=";
            uri = $"https://api.ocr.space/Parse/Image";
        }
        protected HttpResponseMessage GET(string URL) // ,HttpContent content
        {
            using (HttpClient client = new HttpClient())
            {
                // var result = client.PostAsync(URL,content);
                var result = client.GetAsync(URL+ "https://imgur.com/6L66zrT"); //testocr.PNG
                result.Wait();
                return result.Result;
            }
        }
        protected HttpResponseMessage POST(string URL,HttpContent content) // ,HttpContent content
        {
            using (HttpClient client = new HttpClient())
            {
                 var result =  client.PostAsync(URL,content);
                
                result.Wait();
                return result.Result;
            }
        }
        public async Task<String[]> ResultAsync()
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(Key), "apikey");
            form.Add(new StringContent("eng"), "language");
            string imgPath = Path.GetFullPath("testocr.PNG");
            byte[] imageData = File.ReadAllBytes(imgPath);
            form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "testocr.PNG");
          //  HttpContent content = new StringContent("testocr.PNG");
           // form.Add(content, "fileToUpload");
         

            var response = POST(uri,form);
            
            string result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Rootobject ocrResult = JsonConvert.DeserializeObject<Rootobject>(result);
                if(ocrResult.OCRExitCode == 1)
                {
                    string[] results = new string[ocrResult.ParsedResults.Count()];
                    for (int i = 0; i< ocrResult.ParsedResults.Count(); i++)
                    {
                        results[i] = ocrResult.ParsedResults[i].ParsedText;
                       // Console.WriteLine(results[i]);
                    }
                    return results;
                   
                }
                else
                {
                    Console.Write("ERROR with names ocr");
                    return null;
                    
                }
            }
            else
            {
                return null;

            }
        }
       
      



    }
}
