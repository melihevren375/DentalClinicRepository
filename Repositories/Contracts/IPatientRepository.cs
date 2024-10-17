using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPatientRepository:IBaseRepository<Patient>
{
    Task<PagedList<Patient>> GetPatientsAsync(PatientParams patientParams);
    Task<Patient> GetPatientByConditionAsync(Expression<Func<Patient, bool>> expression,bool trackChanges);
    Task CreatePatientAsync(Patient patient);
    Task DeletePatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient);
}
