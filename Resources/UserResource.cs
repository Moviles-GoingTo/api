namespace GoingTo_API.Resources
{
    public class UserResource
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public string Status { get; set; }

        public UserResource(string message, int code, string status)
        {
            this.Message = message;
            this.Code = code;
            this.Status = status;
        }
    }
}
