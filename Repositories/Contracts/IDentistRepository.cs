﻿using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IDentistRepository : IBaseRepository<Dentist>
{
    Task<PagedList<Dentist>> GetDentistsAsync(DentistParams dentistParams);
    Task<Dentist> GetDentistByConditionAsync(Expression<Func<Dentist, bool>> expression,bool trackChanges);
    Task CreateDentistAsync(Dentist dentist);
    Task DeleteDentistAsync(Dentist dentist);
    Task UpdateDentistAsync(Dentist dentist);
}
