using Entities.Concretes;
using Repositories.Contracts;

namespace Repositories.Concretes.EfCore.Repos;

public class TreatmentDetailsRepository : BaseRepository<TreatmentDetails>, ITreatmentDetailsRepository
{
    public TreatmentDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
