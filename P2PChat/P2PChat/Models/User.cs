using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2PChat.Models
{
    public class User
    {
        [Key]
        public long ID { get; set; }
        public string Username { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<Message> Messages { get; set; }

        public User()
        {
            this.CreatedTime = DateTime.Now;
            Messages = new List<Message>();
        }
    }
}
