using PIA_Backend.Database;
using PIA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIA_Backend.Backend
{
    public class UserService
    {
        NORTHWNDContext DataContext = new NORTHWNDContext();

        public void AddNewUser(UserModel newUser)
        {
            var newUserInDatabase = new User();
            newUserInDatabase.UserId = Guid.NewGuid();
            newUserInDatabase.UserName = newUser.UserName;
            newUserInDatabase.Password = newUser.Password;

            DataContext.Users.Add(newUserInDatabase);
            DataContext.SaveChanges();
        }
    }
}
