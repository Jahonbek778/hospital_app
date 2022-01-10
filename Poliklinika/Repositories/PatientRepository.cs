using Poliklinika.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Poliklinika.Services;

namespace Poliklinika.Repasitories
{
    internal class PatientRepository : IPatientRepository
    {

        public IList<Patient> GetPatients()
        {
            IList<Patient> _patients = new List<Patient>();

            _patients.Clear();

            string[] patients = File.ReadAllLines(Constants.patientpath).ToArray();

            foreach (string patient in patients)
            {
                string[] pat = patient.Split(" ");
                _patients.Add(new Patient
                {
                    Id = int.Parse(pat[0]),
                    FirstName = pat[1],
                    LastName = pat[2],
                    Age = pat[3],
                    Disease = pat[4],
                    Address = pat[5],
                });
            }
            return _patients;
        }

        public void CreatePatient(Patient patient)
        {
            int count = File.ReadAllLines(Constants.patientpath).Count() + 1;
            patient.Id = count;

            File.AppendAllText(Constants.patientpath,
                patient.Id + " " +
                patient.FirstName + " " +
                patient.LastName + " " +
                patient.Age + " " +
                patient.Disease + " " +
                patient.Address + Environment.NewLine);
        }

        public void UpdatePatient(Patient patient)
        {
            List<string> lines = File.ReadAllLines(Constants.patientpath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] pats = lines[i].Split();

                if (pats[0] == patient.Id.ToString())
                {
                    lines[i] = "\n" + patient.Id + " " +
                                      patient.FirstName + " " +
                                      patient.LastName + " " +
                                      patient.Age + " " +
                                      patient.Disease + " " +
                                      patient.Address;
                    break;
                }
            }

            File.WriteAllLines(Constants.patientpath, lines.ToArray());
        }

        public void DeletePatient(int Id)
        {
            List<string> lines = File.ReadAllLines(Constants.patientpath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] pats = lines[i].Split();

                if(pats[0] == Id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(Constants.patientpath, lines.ToArray());
        }

        
    }
}
