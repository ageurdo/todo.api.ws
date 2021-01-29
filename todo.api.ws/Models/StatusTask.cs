
using System.ComponentModel.DataAnnotations;

namespace todo.api.ws.Models
{
    public class StatusTask
    {
        [Key]
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
