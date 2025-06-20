using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public DateTime DueTime { get; set; }
        public int IsDeleted { get; set; }

        //User
        public Guid UserId { get; set; }
        public User User { get; set; }

        //Project
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        //Attachment
        public ICollection<Attachment> Attachments { get; set; }

        //Comments
        public ICollection<Comment> Comments { get; set; }
    }
}
