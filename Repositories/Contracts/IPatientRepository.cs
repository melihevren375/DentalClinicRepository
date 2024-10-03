using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPatientRepository:IBaseRepository<Patient>
{
    Task<PagedList<Patient>> GetPatientsAsync(PatientParams patientParams);
    Task<Patient> GetPatientByConditionAsync(Expression<Func<Patient, bool>> expression);
    void CreatePatientAsync(Patient patient);
    void DeletePatientAsync(Patient patient);
    void UpdatePatientAsync(Patient patient);
}
