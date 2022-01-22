using System;

namespace MKT.WebUI.Models
{
    public class ErrorViewModel
    {
        public string Message { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
