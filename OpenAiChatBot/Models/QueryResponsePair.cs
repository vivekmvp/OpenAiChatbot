namespace OpenAiChatBot.Models
{
    public class QueryResponseViewModel
    {
        public List<QueryResponsePair> QueryResponsePairs { get; set; } = new List<QueryResponsePair>();
        public string NewQuery { get; set; }  // For capturing the new query from the form
        public string Response { get; set; }  // Add this property to hold messages for the view
    }

    public class QueryResponsePair
    {
        public string Query { get; set; }
        public string Response { get; set; }
    }
}
