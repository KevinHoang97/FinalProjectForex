using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForex.Client.Service
{
    public static class ServiceExtension
    {

        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url); //makes request
            request.Headers.Add("Authorization", "Bearer 50f5b6cf1d7ec2e9adbb46f534883f5a-d9f458ef2e65108b1ba1ade2f0f68926"); //no point in hiding this, in public header anyway.

            var response = await httpClient.SendAsync(request);
            response.Headers.Add("Access-Control-Allow-Origin", "*"); //Allows for CORS in response headers
            response.EnsureSuccessStatusCode();

            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            return System.Text.Json.JsonSerializer.Deserialize<T>(responseBytes);
        }

        public static async Task<T> PostBuyJsonAsync2<T>(this HttpClient httpClient, string url, string content)
        {
            // Console.WriteLine("outide");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            {
                //   Console.WriteLine("gotin");
                //  request.Headers.Add("Client-ID", "l5vezref7z6b8mxfqamgnr186tn4dg"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Authorization", "Bearer 50f5b6cf1d7ec2e9adbb46f534883f5a-d9f458ef2e65108b1ba1ade2f0f68926"); //no point in hiding this, in public header anyway.
                                                                                                                                  //  Console.WriteLine("Authorization");
                                                                                                                                  // request.Headers.Add("Content-Type", "application/json");
                                                                                                                                  // Console.WriteLine("Content-type");

                //     var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(content, Encoding.UTF8, "application/json"))
                {
                    //   Console.WriteLine("string content method");
                    request.Content = stringContent;
                    // Console.WriteLine("request.content");


                    using (var response = await httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBytes = await response.Content.ReadAsByteArrayAsync();
                        return System.Text.Json.JsonSerializer.Deserialize<T>(responseBytes);

                    }

                }
            }
        }

        public static async Task<T> PostFBuyJsonAsync<T>(string requestUri, string content)
        {


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                //  request.Headers.Add("Client-ID", "l5vezref7z6b8mxfqamgnr186tn4dg"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Authorization", "Bearer 50f5b6cf1d7ec2e9adbb46f534883f5a-d9f458ef2e65108b1ba1ade2f0f68926"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Content-Type", "application/json");

                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBytes = await response.Content.ReadAsByteArrayAsync();
                        return System.Text.Json.JsonSerializer.Deserialize<T>(responseBytes);

                    }

                }
            }
        }



        public static async Task<T> PostSellJsonAsync<T>(string requestUri, string content)
        {


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                //  request.Headers.Add("Client-ID", "l5vezref7z6b8mxfqamgnr186tn4dg"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Authorization", "Bearer 50f5b6cf1d7ec2e9adbb46f534883f5a-d9f458ef2e65108b1ba1ade2f0f68926"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Content-Type", "application/json");

                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBytes = await response.Content.ReadAsByteArrayAsync();
                        return System.Text.Json.JsonSerializer.Deserialize<T>(responseBytes);

                    }

                }
            }
        }

        /*public static async Task<T> KevPostAsJsonAsync<T>(this HttpClient httpClient ,string requestUri, string content)
        {
            //using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                request.Headers.Add("Client-ID", "l5vezref7z6b8mxfqamgnr186tn4dg"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Authorization", "Bearer 50f5b6cf1d7ec2e9adbb46f534883f5a-d9f458ef2e65108b1ba1ade2f0f68926"); //no point in hiding this, in public header anyway.
                request.Headers.Add("Content-Type", "application/json");

                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBytes = await response.Content.ReadAsByteArrayAsync();
                        return System.Text.Json.JsonSerializer.Deserialize<T>(responseBytes);

                    }

                }
            }
        }*/
    }
}
