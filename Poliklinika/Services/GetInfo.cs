using Poliklinika.Models;
using Poliklinika.Repasitories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poliklinika.Services
{
    internal class GetInfo
    {
        static IPatientRepository patientRepo = new PatientRepository();
        static IUserRepository userRepo = new UserRepository();

        public static User CheckAdmin()
        {
            SignIn signIn = new SignIn();
            Console.Write("Login: ");
            signIn.Login = Console.ReadLine();
            Console.Write("Parrword: ");
            signIn.Password = Console.ReadLine();

            IList<User> users = userRepo.GetUsers().ToList();
            var user = users.Where(x => x.Login == signIn.Login)
                .Where(x => x.Password == signIn.Password).FirstOrDefault();
            return user;
        }

        public static User ObjectAdmin()
        {
            User user = new User();
            Console.Write("First name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            user.LastName = Console.ReadLine();
            Console.Write("Login: ");
            user.Login = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            return user;
        }
        public static Patient ObjectPatient()
        {
            Patient patient = new Patient();
            Console.Write("Ismi: ");
            patient.FirstName = Console.ReadLine();
            Console.Write("Familya: ");
            patient.LastName = Console.ReadLine();
            Console.Write("Yosh: ");
            patient.Age = Console.ReadLine();
            Console.Write("Kasallik turi: ");
            patient.Disease = Console.ReadLine();
            Console.Write("Viloyat: ");
            patient.Address = Console.ReadLine();
            return patient;
        }
        public static Patient SearchPatient(string name)
        {
            var patients = patientRepo.GetPatients();
            var patient = patients.Where(x => x.FirstName == name).FirstOrDefault();
            return patient;
        }
        public static void ShowAllUsers()
        {
            var users = userRepo.GetUsers();
            foreach (var user in users)
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
        }
        public static void Added()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdded!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static User DeleteAdmin(int Id)
        {
            SignIn signIn = GetInfo.CheckAdmin();
            if (signIn != null)
            {
                var users = userRepo.GetUsers();
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == Id)
                    {
                        return users[i];
                    }
                }
            }
            return null;
        }
        public static User UpdateAdmin(int Id)
        {
            SignIn signIn = GetInfo.CheckAdmin();
            if (signIn != null)
            {
                var users = userRepo.GetUsers();
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == Id)
                    {
                        var user = GetInfo.ObjectAdmin();
                        user.Id = Id;
                        return user;
                    }
                }
            }
            return null;
        }

    }
}
