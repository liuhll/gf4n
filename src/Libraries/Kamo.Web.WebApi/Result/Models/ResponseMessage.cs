namespace Kamo.Web.WebApi.Result.Models
{
    public class ResponseMessage : ResponseMessage<object>
    {
        public ResponseMessage(object data) : base(data)
        {
        }

        public ResponseMessage(int status, object data) : base(status, data)
        {
        }
    }
}