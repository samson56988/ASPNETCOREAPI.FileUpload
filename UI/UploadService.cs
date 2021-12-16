using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI
{
    public class UploadService : IUploadService 
    {


        private string BaseURL = "https://localhost:44309/api/demo/";
        public Task<HttpResponseMessage> SingleUplaod(string Filename,byte[] bytes)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BaseURL);
                var multipartFormDataContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(bytes);
                multipartFormDataContent.Add(fileContent, "file", Filename);
                return client.PostAsync("singleupload", multipartFormDataContent);

                 


            }
            catch
            {
                return null;
            }
        }


    }
}
