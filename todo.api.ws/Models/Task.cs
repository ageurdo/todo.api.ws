using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace todo.api.ws.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }

        [ForeignKey("BoardId")]
        public virtual Board Board { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
