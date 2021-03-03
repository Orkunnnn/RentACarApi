using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
