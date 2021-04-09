using GrapeCity.Forguncy.ServerApi;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostDataPluginApi
{
    public class Handler : ForguncyApi
    {
        [Post]
        public async Task FromPost()
        {
            using (var stream = new StreamReader(Context.Request.Body))
            {
                var content = stream.ReadToEndAsync().Result;

                var bytes = Encoding.Default.GetBytes(content);

                await Context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        [Get]
        public async Task FromGet()
        {
            var bytes = Encoding.Default.GetBytes(Context.Request.QueryString.Value);

            await Context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }

        [Post]
        public void FromPost_Error()
        {
            throw new WebException("FromPost_Error throws exception.");
        }
    }
}
