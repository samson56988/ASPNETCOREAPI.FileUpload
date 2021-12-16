using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI
{
    public interface IUploadService
    {
        public Task<HttpResponseMessage> SingleUplaod(string Filename, byte[] bytes);
    }
}
