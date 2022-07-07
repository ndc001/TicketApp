using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Requests
{
    public class Base_Command_Response
    {
        public int id { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; }
        public List<string> errors { get; set; }
    }
}