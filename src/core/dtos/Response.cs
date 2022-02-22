namespace Delicious.core
{
    public class Response
    {
        public bool Status { get; set; }
        public string Error { get; set; } = "";
        public object Data { get; set; } = null!;
    }
}