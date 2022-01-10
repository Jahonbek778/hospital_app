using ConsoleTables;
using Poliklinika.Models;
using Poliklinika.Repasitories;
using Poliklinika.Services;
using System;
using System.IO;
using System.Threading;

namespace Poliklinika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepo = new UserRepository();
            IPatientRepository patientRepo = new PatientRepository();

        MainMenu:
            Console.WriteLine("1.Add patient \t 2.Search Patient \t3.Login admin\t4.Exit");
            var choose = Console.ReadLine();

            if (choose == "1")
            {
                patientRepo.CreatePatient(GetInfo.ObjectPatient());
                GetInfo.Added();
                goto MainMenu;
            }
            else if (choose == "2")
            {
                Console.Write("Enter patient name: ");
                string res = Console.ReadLine();
                var patient = GetInfo.SearchPatient(res);
                Console.WriteLine("\n" + patient.Id + " " + patient.FirstName + " " + patient.LastName + " " + patient.Age + " " + patient.Disease + " " + patient.Address + "\n");
                goto MainMenu;
            }
            else if (choose == "3")
            {
                Console.Title = "Login: radjabov4443    Password: 12345";
                var resault = GetInfo.CheckAdmin();
                if (resault != null)
                {
                AminMenu:
                    Console.WriteLine("\n1.Show all patients\t2.Add new admin\t\t3.Delate admin\t4.Update admin info\t5.Back to main menu");
                    int a = int.Parse(Console.ReadLine());
                    if (a == 1)
                    {
                        var patients = patientRepo.GetPatients();
                        for (int i = 0; i < patients.Count; i++) Console.WriteLine("\n" + patients[i].Id + " " + patients[i].FirstName + " " + patients[i].LastName + " " + patients[i].Age + " " + patients[i].Disease + " " + patients[i].Address); goto AminMenu;
                    }
                    else if (a == 2)
                    {
                        userRepo.CreateUser(GetInfo.ObjectAdmin()); GetInfo.Added(); goto AminMenu;
                    }
                    else if (a == 3)
                    {
                        var users = userRepo.GetUsers();
                        for (int i = 0; i < users.Count; i++) Console.WriteLine("\n" + users[i].Id + " " + users[i].FirstName + " " + users[i].LastName);
                        Console.WriteLine("\nChoose admin Id: ");
                        int Id = int.Parse(Console.ReadLine());
                        User user = GetInfo.DeleteAdmin(Id);
                        if (user == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nNot Found"); Console.ForegroundColor = ConsoleColor.White;
                            goto AminMenu;
                        }
                        else
                        {
                            userRepo.DeleteUser(user);
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nDeleted!"); Console.ForegroundColor = ConsoleColor.White;
                            goto AminMenu;
                        }
                    }
                    else if (a == 4)
                    {
                        GetInfo.ShowAllUsers();
                        Console.WriteLine("\nEnter admin Id: ");
                        int res = int.Parse(Console.ReadLine());
                        var user = GetInfo.UpdateAdmin(res);
                        if (user != null)
                        {
                            userRepo.UpdateUser(user);
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nUpdated!"); Console.ForegroundColor = ConsoleColor.White;
                            goto AminMenu;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nNot Found"); Console.ForegroundColor = ConsoleColor.White;
                            goto AminMenu;
                        }
                    }
                    else goto MainMenu;
                }
                else
                {
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nThere is no such user!!!"); Console.ForegroundColor = ConsoleColor.White;
                    goto MainMenu;
                }
            }
            else if (choose == "4") return;
            else goto MainMenu;
        }
    }
}

