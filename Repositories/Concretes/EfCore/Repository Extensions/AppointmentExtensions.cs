using Entities.Concretes;

namespace Repositories.Concretes.EfCore.Repository_Extensions;

public static class AppointmentExtensions
{
    public static IQueryable<Appointment> FilterIsActive(this IQueryable<Appointment> appointments, bool? isActive)
    {
        if (isActive.HasValue)
        {
            appointments = appointments.Where(a => a.IsActive.Equals(isActive.Value));
        }

        return appointments;
    }

    public static IQueryable<Appointment> FilterDateOfAppointment(this IQueryable<Appointment> appointments, DateTime? minDate, DateTime? maxDate)
    {
        if (minDate.HasValue)
        {
            appointments = appointments.Where(a => a.DateOfAppointment >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            appointments = appointments.Where(a => a.DateOfAppointment <= maxDate.Value);
        }

        return appointments;
    }

    public static IQueryable<Appointment> FilterNotes(this IQueryable<Appointment> appointments, string? notes)
    {
        if (string.IsNullOrWhiteSpace(notes))
            return appointments;

        notes = notes.Trim().ToLower();

        var result = appointments.Where(a => a.Notes.ToLower().Contains(notes));
        return result;
    }

    public static IQueryable<Appointment> FilterCreatedDate(this IQueryable<Appointment> appointments, DateTime? minDate, DateTime? maxDate)
    {
        if (minDate.HasValue)
        {
            appointments = appointments.Where(a => a.DateOfAppointment >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            appointments = appointments.Where(a => a.DateOfAppointment <= maxDate.Value);
        }

        return appointments;
    }

}
