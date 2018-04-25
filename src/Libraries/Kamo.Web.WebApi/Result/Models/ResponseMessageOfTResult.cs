using Kamo.Common.Enums;

namespace Kamo.Web.WebApi.Result.Models
{
    public class ResponseMessage<TData> : ResponseMessageBase
    {
        /// <summary>
        /// The actual result object of AJAX request.
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// Creates an <see cref="ResponseMessage"/> object with <see cref="Data"/> specified.
        /// </summary>
        /// <param name="result">The actual result object of AJAX request</param>
        public ResponseMessage(TData data)
        {
            Data = data;
            Status = (int)ActionResultCode.Success;
        }

        public ResponseMessage(int status, TData data)
        {
            Data = data;
            Status = status;
        }
    }
}