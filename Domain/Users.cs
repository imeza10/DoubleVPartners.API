using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Users
    {
        public Guid UserID { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public bool? Status { get; set; }
        public DateTime AddAt { get; set; }
        public ICollection<Tickets>? Tickets { get; set; }
    }
}
