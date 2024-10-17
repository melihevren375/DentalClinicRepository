using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EfCore.Repository_Extensions;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateAppointmentAsync(Appointment appointment) => await CreateEntityAsync(appointment);

    public async Task DeleteAppointmentAsync(Appointment appointment) => await DeleteEntityAsync(appointment);

    public async Task<Appointment> GetAppointmentByConditionAsync(Expression<Func<Appointment, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).SingleOrDefaultAsync();
        return result;
    }

    public async Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParams appointmentParams)
    {
        var results = await GetEntities(appointmentParams).
            FilterCreatedDate(appointmentParams.MinCreatedDate, appointmentParams.MaxCreatedDate).
            FilterDateOfAppointment(appointmentParams.MinDate, appointmentParams.MaxDate).
            FilterIsActive(appointmentParams.IsActive).
            FilterNotes(appointmentParams.Notes).ToListAsync();

        return PagedList<Appointment>.ToPagedList(results, appointmentParams.PageNumber, appointmentParams.PageSize);

    }

    public async Task UpdateAppointmentAsync(Appointment appointment) => await UpdateEntityAsync(appointment);

}
