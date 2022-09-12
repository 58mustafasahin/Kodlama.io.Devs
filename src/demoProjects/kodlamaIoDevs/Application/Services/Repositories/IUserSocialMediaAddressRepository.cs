using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUserSocialMediaAddressRepository : IAsyncRepository<UserSocialMediaAddress>, IRepository<UserSocialMediaAddress>
    {
    }
}
