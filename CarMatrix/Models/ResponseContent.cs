using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMatrix.Models
{
    public class ResponseContent
    {
        public int Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseContent()
        {
            Result = 0;
            Message = "数据请求失败";
        }
    }
}