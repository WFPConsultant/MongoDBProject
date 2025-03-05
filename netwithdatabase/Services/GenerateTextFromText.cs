using Google.Api.Gax.Grpc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Cloud.AIPlatform.V1;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace netwithdatabase.Models
{
    public class GenerateTextFromText
    {
        const string ProjectId = "jamil-333509";
        const string Location = "us-central1";
        const string AiPlatformUrl = $"https://{Location}-aiplatform.googleapis.com";
        const string ModelId = "gemini-pro";
        const string EndpointUrl = $"{AiPlatformUrl}/v1/projects/{ProjectId}/locations/{Location}/publishers/google/models/{ModelId}:streamGenerateContent";

        public async static Task<string> Generate(string text)
        {

            try {
                //string text = Console.ReadLine();//"can you give me the denominator between 9999";
                //Console.WriteLine($"Text: {text}");

                string payload = GeneratePayload(text);
                string response = await SendRequest(payload);
                var geminiResponses = JsonConvert.DeserializeObject<List<GeminiResponse>>(response);

                string fullText = string.Join("", geminiResponses
                    .SelectMany(co => co.Candidates)
                    .SelectMany(c => c.content.Parts)
                    .Select(p => p.Text));

                //Console.WriteLine($"Response: {fullText}");

                return fullText.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private static string GeneratePayload(string text)
        {
            var payload = new
            {
                contents = new
                {
                    role = "USER",
                    parts = new
                    {
                        text = text
                    }
                },
                generation_config = new
                {
                    temperature = 0.4,
                    top_p = 1,
                    top_k = 32,
                    max_output_tokens = 2048
                }
            };
            return JsonConvert.SerializeObject(payload);
        }

       
        private async static Task<string> SendRequest(string payload)
        {
            GoogleCredential credential = GoogleCredential.GetApplicationDefault();
            var handler = credential.ToDelegatingHandler(new HttpClientHandler());
            using HttpClient httpClient = new(handler);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.PostAsync(EndpointUrl,
                new StringContent(payload, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }



    }
}
