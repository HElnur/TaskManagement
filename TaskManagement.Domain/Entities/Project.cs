using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //User
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        //Tasks
        public ICollection<Task> Tasks { get; set; }
    }
}
