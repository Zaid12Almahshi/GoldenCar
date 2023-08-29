using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class CommonClass
    {
        public class ResponseStandardJsonApi
        {
            public bool Success { get; set; }
            public int Code { get; set; }
            public object? Message { get; set; }
            public object? Result { get; set; }

        }
        public class ResponseStandardJson<T>
        {

            public bool Success { get; set; }
            public int Code { get; set; }
            public object? Message { get; set; }
            public T? Result { get; set; }
        }
        public class NullColumns
        {

        }
        public class JwtAuthResponce
        {
            public string nameid { get; set; } = string.Empty;
            public string name { get; set; } = string.Empty;
            public string familyname { get; set; } = string.Empty;
            public string email { get; set; } = string.Empty;
            public string azp { get; set; } = string.Empty;
            public string jti { get; set; } = string.Empty;
        }
    }
}
