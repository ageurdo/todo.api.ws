using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.api.ws.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
