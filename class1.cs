using System.Text;

namespace web
{
    public class Web
    {
        private static readonly HttpClient httpClient = new HttpClient();

        #region get
        /// <summary>
        /// Gets string from Server
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <returns>Result-string from Server</returns>
        public static string Get(string url)
        {
            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return data;
        }

        /// <summary>
        /// Gets string from Server async
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <returns>Result-string from Server</returns>
        public static async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            return data;
        }

        /// <summary>
        /// Sends a get-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="callback">returns what the server returned (string) and status-code (int)</param>
        public static void Get(string url, Action<string, int> callback)
        {
            using HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage result = httpClient.GetAsync(url).GetAwaiter().GetResult();
                string content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                callback(content, (int)result.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                callback($"Error: {ex.Message}", 0);
            }
        }

        /// <summary>
        /// Sends a get-async-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="callback">returns what the server returned (string) and status-code (int)</param>
        public static async Task GetAsync(string url, Action<string, int> callback)
        {
            using HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage result = await httpClient.GetAsync(url);
                string content = await result.Content.ReadAsStringAsync();
                callback(content, (int)result.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                callback($"Error: {ex.Message}", 0);
            }
        }


        #endregion

        #region post
        /// <summary>
        /// Sends an async-post-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="data">string that will be sent</param>
        /// <param name="contentType">type of the content. default: "application/json"</param>
        /// <returns>Result string from the Server</returns>
        public static string Post(string url, string data, string contentType = "application/json")
        {
            HttpContent content = new StringContent(data, Encoding.UTF8, contentType);
            HttpResponseMessage response = httpClient.PostAsync(url, content).GetAwaiter().GetResult();
            string responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return responseString;

        }

        /// <summary>
        /// Sends an async-post-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="data">string that will be sent</param>
        /// <param name="contentType">type of the content. default: "application/json"</param>
        /// <returns>Result string from the Server</returns>
        public static async Task<string> PostAsync(string url, string data, string contentType = "application/json")
        {
            HttpContent content = new StringContent(data, Encoding.UTF8, contentType);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        /// <summary>
        /// Sends a post-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="data">string that will be sent</param>
        /// <param name="callback">returns what the server returned (string) and status-code (int)</param>
        /// <param name="contentType">type of the content. default: "application/json"</param>
        public static void Post(string url, string data, Action<string, int> callback, string contentType = "application/json")
        {
            using HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(data, Encoding.UTF8, contentType);
            try
            {
                HttpResponseMessage result = httpClient.PostAsync(url, content).GetAwaiter().GetResult();
                string response = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                callback(response, (int)result.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                callback($"Error: {ex.Message}", 0);
            }
        }

        /// <summary>
        /// Sends a async-post-request to the server.
        /// </summary>
        /// <param name="url">URL to the server</param>
        /// <param name="data">string that will be sent</param>
        /// <param name="callback">returns what the server returned (string) and status-code (int)</param>
        /// <param name="contentType">type of the content. default: "application/json"</param>
        public static async Task PostAsync(string url, string data, Action<string, int> callback, string contentType = "application/json")
        {
            using HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(data, Encoding.UTF8, contentType);
            try
            {
                HttpResponseMessage result = await httpClient.PostAsync(url, content);
                string response = await result.Content.ReadAsStringAsync();
                callback(response, (int)result.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                callback($"Error: {ex.Message}", 0);
            }
        }

    #endregion
}
}
