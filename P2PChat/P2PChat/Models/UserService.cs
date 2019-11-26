using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P2PChat.Models
{
    public class UserService
    {
        private readonly ApplicationContext appContext;

        public UserService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public User AddUserToDatabase(string name)
        {
            var user = new User();
            user.Username = name;
            appContext.Users.Add(user);
            appContext.SaveChanges();
            return user;
        }

        internal List<Message> GetAllMessages()
        {
            return appContext.Messages.ToList();
        }

        internal bool DoesUserExist(string username)
        {
            var user = appContext.Users.Any(u => u.Username.Equals(username));
            return user;
        }

        internal User FindUserByUsername(string username)
        {
            var list = appContext.Users.ToList();
            var user = list.First(u => u.Username == username);
            return user;
        }

        public User GetUserByID(long id)
        {
            var user = appContext.Users.Find(id);
            return user;
        }

        public void AddMessage(long id, string text)
        {
            var user = GetUserByID(id);
            var newMessage = new Message();
            newMessage.Text = text;
            newMessage.User = user;
            user.Messages.Add(newMessage);
            appContext.Messages.Add(newMessage);
            appContext.SaveChanges();
        }

        internal List<Message> GetMessages(long id)
        {
            return appContext.Messages.Include(u => u.User).Where(u => u.User.ID == id).ToList();
        }
    }
}
