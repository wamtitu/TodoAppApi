using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Responses
{
    public class SuccessMessage
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public SuccessMessage(int c , string m)
        {
            this.Code = c;
            this.Message = m;
        }
    }
}