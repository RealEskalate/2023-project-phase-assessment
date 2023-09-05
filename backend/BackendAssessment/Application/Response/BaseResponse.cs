using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BaseResponse<T>
    {
        public bool Success {set; get;}
        public string? Message {set; get;}

        public T? Value {set; get;}
        
    }
}