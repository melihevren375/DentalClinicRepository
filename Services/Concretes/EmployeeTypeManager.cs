using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.EmployeeTypeDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class EmployeeTypeManager : IEmployeeTypeService
{
    private readonly IEmployeeTypeRepository _employeeTypeRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<EmployeeTypeDtoForRead> _dataShaperOfEmployeeType;

    public EmployeeTypeManager(IEmployeeTypeRepository employeeTypeRepository, IMapper mapper, IDataShaper<EmployeeTypeDtoForRead> dataShaperOfEmployeeType)
    {
        _employeeTypeRepository = employeeTypeRepository;
        _mapper = mapper;
        _dataShaperOfEmployeeType = dataShaperOfEmployeeType;
    }

    public async Task CreateEmployeeTypeAsync(EmployeeTypeDtoForInsertion employeeTypeDtoForInsertion)
    {
        EmployeeType employeeType = _mapper.Map<EmployeeType>(employeeTypeDtoForInsertion);

        await _employeeTypeRepository.CreateEmployeeTypeAsync(employeeType);
    }

    public async Task DeleteEmployeeTypeAsync(Guid id, bool trackChanges)
    {
        EmployeeType employeeType = await CheckAndReturnEmployeeType(id, trackChanges);

        await _employeeTypeRepository.DeleteEmployeeTypeAsync(employeeType);
    }

    public async Task<(IEnumerable<ExpandoObject> employeeTypeDtosForRead, MetaData metaData)> GetEmployeeTypes(EmployeeTypeParams employeeTypeParams)
    {
        var pagedListResults = await _employeeTypeRepository.
            GetEmployeeTypesAsync(employeeTypeParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<EmployeeTypeDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfEmployeeType.ShapeData(dtos, employeeTypeParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateEmployeeTypeAsync(Guid id, bool trackChanges, EmployeeTypeDtoForUpdate employeeTypeDtoForUpdate)
    {
        EmployeeType employeeType = await CheckAndReturnEmployeeType(id, trackChanges);
        _mapper.Map(employeeTypeDtoForUpdate, employeeType);
        await _employeeTypeRepository.UpdateEmployeeTypeAsync(employeeType);
    }

    private async Task<EmployeeType> CheckAndReturnEmployeeType(Guid id, bool trackChanges)
    {
        var result = await _employeeTypeRepository.GetEmployeeTypeByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new EmployeeTypeNotFoundException(id);

        return result;
    }
}
