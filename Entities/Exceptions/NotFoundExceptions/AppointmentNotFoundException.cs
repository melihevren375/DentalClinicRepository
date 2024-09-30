namespace Entities.Exceptions.NotFoundExceptions;

public sealed class AppointmentNotFoundException:BaseNotFoundException
{
    public AppointmentNotFoundException(Guid id):
        base($"Appointment number {id} not found")
    {
        
    }
}
