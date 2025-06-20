using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }

        //Task
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
