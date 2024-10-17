using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParams appointmentParams);
    Task<Appointment> GetAppointmentByConditionAsync(Expression<Func<Appointment, bool>> expression,bool trackChanges);
    Task CreateAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(Appointment appointment);
    Task UpdateAppointmentAsync(Appointment appointment);
}
