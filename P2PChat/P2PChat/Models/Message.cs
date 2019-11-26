using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2PChat.Models
{
    public class Message
    {
        [Key]
        public long ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public User User { get; set; }

        public Message()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
