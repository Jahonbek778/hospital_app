using Poliklinika.Models;
using Poliklinika.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Repasitories
{
    internal class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            int count = File.ReadAllLines(Constants.adminpath).Count() + 1;

            File.AppendAllText(Constants.adminpath, count + " " + user.FirstName + " " + user.LastName + " " +
                   user.Login + " " + user.Password + Environment.NewLine);
            
        }

        public void DeleteUser(User user)
        {
            List<string> lines = File.ReadAllLines(Constants.adminpath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] users = lines[i].Split();

                if (users[0] == user.Id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(Constants.adminpath, lines.ToArray());
        }

        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();

            users.Clear();

            string[] patients = File.ReadAllLines(Constants.adminpath).ToArray();

            foreach (string patient in patients)
            {
                string[] pat = patient.Split(" ");
                users.Add(new User
                {
                    Id = int.Parse(pat[0]),
                    FirstName = pat[1],
                    LastName = pat[2],
                    Login = pat[3],
                    Password = pat[4],
                });
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            List<string> lines = File.ReadAllLines(Constants.adminpath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] users = lines[i].Split();

                if (users[0] == user.Id.ToString())
                {
                    lines[i] = user.Id + " " +
                               user.FirstName + " " +
                               user.LastName + " " +
                               user.Login + " " +
                               user.Password;
                }
            }
            File.WriteAllLines(Constants.adminpath, lines.ToArray());
        }
    }
}
