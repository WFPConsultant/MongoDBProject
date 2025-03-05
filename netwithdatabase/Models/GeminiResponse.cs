namespace netwithdatabase.Models
{
    public class GeminiResponse
    {
        public List<Candidate> Candidates { get; set; }
    }



    public class Candidate
    {
        public Content content { get; set; }
        public List<SafetyRating> SafetyRatings { get; set; }
    }

    public class Content
    {
        public string Role { get; set; }
        public List<Part> Parts { get; set; }
    }

    public class Part
    {
        public string Text { get; set; }
        public FileData FileData { get; set; }
    }
    public class FileData
    {
        public string MimeType { get; set; }
        public string FileUri { get; set; }
    }
    public class SafetyRating
    {
        public string Category { get; set; }
        public string Probability { get; set; }
    }
}
