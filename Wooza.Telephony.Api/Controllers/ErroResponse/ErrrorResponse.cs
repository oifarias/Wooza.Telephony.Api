using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wooza.Telephony.Api.Controllers.ErroResponse
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Validations = new List<ErrorFieldMessage>();
        }
        public List<ErrorFieldMessage> Validations { get; set; }

        public class ErrorFieldMessage
        {
            public string Field { get; set; }
            public string Message { get; set; }
        }

    }
}
