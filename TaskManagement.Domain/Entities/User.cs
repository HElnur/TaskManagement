using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        //Project
        public ICollection<Project> Projects { get; set; }

        //Tasks
        public ICollection<Task> Tasks { get; set; }


        //Comments
        public ICollection<Comment> Comments { get; set; }

        public void AddPassword(string password)
        {
            Guid guid = new Guid();

            using(SHA256 sha256 = SHA256.Create())
            {
                var salt = sha256.ComputeHash(Encoding.UTF8.GetBytes(guid.ToString()));

                using (HMACSHA256 hmacsha256 = new HMACSHA256(salt))
                {
                    var buffer = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                    Salt = salt;
                    Password = buffer;
                }
            }
        }

        public bool CheckPassword(string password)
        {
            using (HMACSHA256 hmacSha256 = new HMACSHA256(Salt))
            {
                var buffer = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return buffer.SequenceEqual(Password);
            }
        }
    }
}
