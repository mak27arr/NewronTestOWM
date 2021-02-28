using NewronTestOWM.BLL.Interface;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Module
{
    internal class RESTConector : IRESTConector, IDisposable
    {
        // To detect redundant calls
        private bool _disposed = false;
        private HttpClient client;
        public RESTConector()
        {
            var handler = new HttpClientHandler()
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
            };
            client = new HttpClient(handler);
        }
        public async Task<IEnumerable<T>> GetListAsync<T>(string url, string paramtr, IDictionary<string, string> header)
        {
            return await GetAsync<List<T>>(url,paramtr,header);
        }
        public async Task<T> GetAsync<T>(string url, string paramtr, IDictionary<string, string> header)
        {
            client.BaseAddress = new Uri(url);
            // Add an Accept header for JSON format.
            AddHeaders(header);
            // List data response.
            HttpResponseMessage response = await client.GetAsync(paramtr);  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var datastring = await response.Content.ReadAsStringAsync();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                return JsonConvert.DeserializeObject<T>(datastring);
            }
            else
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error("Error hhtp GET reqwest: " + response.StatusCode);
                return default(T);
            }
        }
        private void AddHeaders(IDictionary<string, string> header)
        {
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            if (header != null)
            {
                foreach (var hed in header)
                {
                    client.DefaultRequestHeaders.Add(hed.Key, hed.Value);
                }
            }
        }
        public void Dispose() => Dispose(true);
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // Dispose managed state (managed objects).
                client?.Dispose();
            }
            _disposed = true;
        }
    }
}
