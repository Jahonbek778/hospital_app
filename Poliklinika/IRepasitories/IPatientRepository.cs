using Poliklinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Repasitories
{
    internal interface IPatientRepository
    {
        IList<Patient> GetPatients();

        void CreatePatient(Patient patient);

        void UpdatePatient(Patient patient);

        void DeletePatient(int Id);

    }
}
