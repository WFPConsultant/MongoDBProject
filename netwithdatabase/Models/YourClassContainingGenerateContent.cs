using Google.Api.Gax.Grpc;
using Google.Cloud.AIPlatform.V1;
using System.Text;

namespace netwithdatabase.Models
{
    public class YourClassContainingGenerateContent
    {
        //public async Task<string> GenerateContent(string projectId, string location, string publisher, string model, string prompt)
        //{
        //    // Create client
        //    var predictionServiceClient = new PredictionServiceClientBuilder
        //    {
        //        Endpoint = $"{location}-aiplatform.googleapis.com",
        //        //CredentialsPath = "C:\\Practice\\netwithdatabase\\netwithdatabase\\jamil-333509-cd2d04ec0d5f.json"
        //        //CredentialsPath = Path.Combine("Configs", "jamil-333509-cd2d04ec0d5f.json")
        //        CredentialsPath = "jamil-333509-cd2d04ec0d5f.json"
        //    }.Build();

        //    // Prompt
        //    //string prompt = "how are you?";
        //    string imageUri = "gs://generativeai-downloads/images/scones.jpg";

        //    // Initialize request argument(s)
        //    var content = new Content
        //    {
        //        Role = "USER"
        //    };
        //    content.Parts.AddRange(new List<Part>()
        //        {
        //            new() {
        //                Text = prompt
        //            },
        //            new() {
        //                FileData = new() {
        //                    MimeType = "image/png",
        //                    FileUri = imageUri
        //                }
        //            }
        //        });

        //    var generateContentRequest = new GenerateContentRequest
        //    {
        //        Model = $"projects/{projectId}/locations/{location}/publishers/{publisher}/models/{model}",
        //        GenerationConfig = new GenerationConfig
        //        {
        //            Temperature = 0.4f,
        //            TopP = 1,
        //            TopK = 32,
        //            MaxOutputTokens = 2048
        //        }
        //    };
        //    generateContentRequest.Contents.Add(content);

        //    // Make the request, returning a streaming response
        //    using PredictionServiceClient.StreamGenerateContentStream response = predictionServiceClient.StreamGenerateContent(generateContentRequest);

        //    StringBuilder fullText = new();

        //    // Read streaming responses from server until complete
        //    AsyncResponseStream<GenerateContentResponse> responseStream = response.GetResponseStream();
        //    await foreach (GenerateContentResponse responseItem in responseStream)
        //    {
        //        fullText.Append(responseItem.Candidates[0].Content.Parts[0].Text);
        //    }

        //    return fullText.ToString();
        //}
    }
}
