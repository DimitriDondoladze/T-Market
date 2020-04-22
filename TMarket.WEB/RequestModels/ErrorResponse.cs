using System.Collections.Generic;

namespace TMarket.WEB.RequestModels
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
