using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Models
{
    public class ErrorResponse
    {
        public string ErrorCd { get; set; }
        public string ErrorType { get; set; }
        public string HelpUrl { get; set; }
        public string ErrorMsg { get; set; }
        [JsonIgnore]
        public HttpResponseMessage HttpResponseMsg { get; set; }
    }

    public enum ErrorTypeEnum
    {
        Success,
        Information,
        Error,
        Warning,
    }
}
