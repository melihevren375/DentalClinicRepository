using Entities.DataTransferObjects.AppointmentDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IAppointmentService
{
    Task CreateAppointmentAsync(AppointmentDtoForInsertion appointmentDtoForInsertion);
    Task DeleteAppointmentAsync(Guid id, bool trackChanges);
    Task UpdateAppointmentAsync(Guid id, bool trackChanges, AppointmentDtoForUpdate appointmentDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> appointmentDtosForRead, MetaData metaData)> GetAppointments(AppointmentParams appointmentParams);
}
