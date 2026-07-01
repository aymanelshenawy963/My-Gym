using GymManagement.Core.Contracts.Users;
using GymManagement.Core.Entities;
using Mapster;

namespace GymManagement.Core.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
       

        config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
          .Map(dest => dest, src => src.user)
          .Map(dest => dest.Roles, src => src.roles);

        config.NewConfig<CreateUserRequest, ApplicationUser>()
          .Map(dest => dest.EmailConfirmed, src => true);

        config.NewConfig<UpdateUserRequest, ApplicationUser>()
          .Map(dest => dest.NormalizedUserName, src => src.Email.ToUpper()); 


    } 
}
