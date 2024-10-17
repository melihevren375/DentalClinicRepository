using Entities.Concretes;
using Entities.RequestFeatures;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreatePatientAsync(Patient patient) => await CreateEntityAsync(patient);

    public async Task DeletePatientAsync(Patient patient) => await DeleteEntityAsync(patient);

    public async Task<Patient> GetPatientByConditionAsync(Expression<Func<Patient, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<Patient>> GetPatientsAsync(PatientParams patientParams)
    {
        var results = await GetEntities(patientParams).
            FilterByDateOfBirthRange(patientParams.MinDateOfBirth, patientParams.MaxDateOfBirth).
            FilterByFirstName(patientParams.FirstNameContains).
            FilterByIsActive(patientParams.IsActive).
            FilterCreatedDate(patientParams.MinCreatedDate, patientParams.MaxCreatedDate).
            FilterByLastName(patientParams.LastNameContains).
            FilterByPhoneNumber(patientParams.PhoneNumberContains).ToListAsync();

        return PagedList<Patient>.ToPagedList(results, patientParams.PageNumber, patientParams.PageSize);
    }

    public async Task UpdatePatientAsync(Patient patient) => await UpdateEntityAsync(patient);

}
