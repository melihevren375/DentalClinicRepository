using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.AppointmentDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class AppointmentManager : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<AppointmentDtoForRead> _dataShaperOfAppointment;

    public AppointmentManager(IAppointmentRepository appointmentRepository, IMapper mapper, IDataShaper<AppointmentDtoForRead> dataShaperOfAppointment)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _dataShaperOfAppointment = dataShaperOfAppointment;
    }

    public async Task CreateAppointmentAsync(AppointmentDtoForInsertion appointmentDtoForInsertion)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDtoForInsertion);

        await _appointmentRepository.CreateAppointmentAsync(appointment);
    }

    public async Task DeleteAppointmentAsync(Guid id, bool trackChanges)
    {
        Appointment appointment = await CheckAndReturnAppointment(id, trackChanges);

        await _appointmentRepository.DeleteAppointmentAsync(appointment);
    }

    public async Task<(IEnumerable<ExpandoObject> appointmentDtosForRead, MetaData metaData)> GetAppointments(AppointmentParams appointmentParams)
    {
        var pagedListResults = await _appointmentRepository.
            GetAppointmentsAsync(appointmentParams);
        var dtos = _mapper.Map<IEnumerable<AppointmentDtoForRead>>(pagedListResults);
        var metaData = pagedListResults.MetaData;
        var dataShaper = _dataShaperOfAppointment.ShapeData(dtos, appointmentParams.Fields);

        return (appointmentDtosForRead: dataShaper, MetaData: metaData);
    }

    public async Task UpdateAppointmentAsync(Guid id, bool trackChanges, AppointmentDtoForUpdate appointmentDtoForUpdate)
    {
        Appointment appointment = await CheckAndReturnAppointment(id, trackChanges);

        _mapper.Map(appointmentDtoForUpdate, appointment);

        await _appointmentRepository.UpdateAppointmentAsync(appointment);
    }

    private async Task<Appointment> CheckAndReturnAppointment(Guid id, bool trackChanges)
    {
        var result = await _appointmentRepository.GetAppointmentByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new AppointmentNotFoundException(id);

        return result;
    }
}
