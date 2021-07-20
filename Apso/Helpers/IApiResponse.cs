using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apso.Helpers
{
    public class IApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object exception { get; set; }
    }

    public class IApiResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public object exception { get; set; }
    }
}
