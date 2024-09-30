namespace Entities.Exceptions.NotFoundExceptions;

public sealed class EmployeeTypeNotFoundException:BaseNotFoundException
{
    public EmployeeTypeNotFoundException(Guid id):
        base($"Employee number {id} not found.")
    {
        
    }
}
