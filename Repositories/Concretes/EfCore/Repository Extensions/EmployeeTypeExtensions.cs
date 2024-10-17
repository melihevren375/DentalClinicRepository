using Entities.Concretes;

namespace Repositories.Concretes.EfCore.Repository_Extensions;

public static class EmployeeTypeExtensions
{
    public static IQueryable<EmployeeType> FilterByName(this IQueryable<EmployeeType> employeeTypes, string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return employeeTypes;

        name = name.Trim().ToLower();
        return employeeTypes.Where(e => e.Name.ToLower().Contains(name));
    }

    public static IQueryable<EmployeeType> FilterCreatedDate(this IQueryable<EmployeeType> employeeTypes, DateTime? minDate, DateTime? maxDate)
    {
        if (minDate.HasValue)
        {
            employeeTypes = employeeTypes.Where(et => et.CreatedDate >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            employeeTypes = employeeTypes.Where(et => et.CreatedDate <= maxDate.Value);
        }

        return employeeTypes;
    }

}
