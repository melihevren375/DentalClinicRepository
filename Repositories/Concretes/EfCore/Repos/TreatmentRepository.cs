using Entities.Concretes;
using Entities.RequestFeatures;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class TreatmentRepository : BaseRepository<Treatment>, ITreatmentRepository
{
    public TreatmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateTreatmentAsync(Treatment treatment)
        => await CreateEntityAsync(treatment);

    public async Task DeleteTreatmentAsync(Treatment treatment)
        => await DeleteEntityAsync(treatment);

    public async Task<Treatment> GetTreatmentByConditionAsync(Expression<Func<Treatment, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<Treatment>> GetTreatmentsAsync(TreatmentParams treatmentParams)
    {
        var results = await GetEntities(treatmentParams).
            FilterByAppointmentId(treatmentParams.AppointmentId).
            FilterByDentistId(treatmentParams.DentistId).
            FilterByPatientId(treatmentParams.PatientId).
            FilterByTotalAmount(treatmentParams.MinTotalAmount, treatmentParams.MaxTotalAmount).
            FilterCreatedDate(treatmentParams.MinCreatedDate, treatmentParams.MaxCreatedDate).
            ToListAsync();

        return PagedList<Treatment>.ToPagedList(results, treatmentParams.PageNumber, treatmentParams.PageSize);
    }

    public async Task UpdateTreatmentAsync(Treatment treatment)
        => await UpdateEntityAsync(treatment);
}
