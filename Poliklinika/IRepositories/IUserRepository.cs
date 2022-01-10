using Poliklinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Repasitories
{
    internal interface IUserRepository
    {
        IList<User> GetUsers();
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
