namespace Product.Service.Interfaces.Responses
{
    public class Error
    {        
        public bool Warning { get; set; }
       
        public string CustomisedMessage { get; set; }
        
        public string SystemMessage { get; set; }
        
        public string StackTrace { get; set; }
    }
}
