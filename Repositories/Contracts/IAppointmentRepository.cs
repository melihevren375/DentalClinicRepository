using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParams appointmentParams);
    Task<Appointment> GetAppointmentByConditionAsync(Expression<Func<Appointment, bool>> expression);
    void CreateAppointmentAsync(Appointment appointment);
    void DeleteAppointmentAsync(Appointment appointment);
    void UpdateAppointmentAsync(Appointment appointment);
}
