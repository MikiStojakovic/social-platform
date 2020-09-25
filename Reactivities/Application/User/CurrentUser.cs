using System.Threading;
using MediatR;
using Persistence;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain;
using Application.Interfaces;

namespace Application.User
{
 public class CurrentUser
 {
  public class Query : IRequest<User> { }

  public class Handler : IRequestHandler<Query, User>
  {
   private readonly UserManager<AppUser> _userManager;
   private readonly IJwtGenerator _jwtGenerator;
   private readonly IUserAccessor _userAccessor;
   public Handler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
   {
    _userAccessor = userAccessor;
    _jwtGenerator = jwtGenerator;
    _userManager = userManager;
   }

   public async Task<User> Handle(Query request, CancellationToken cancellationToken)
   {
    //Handler logic goes here
    var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

    return new User
    {
     DisplayName = user.DisplayName,
     Username = user.UserName,
     Token = _jwtGenerator.CreateToken(user),
     Image = null
    }
   }
  }
 }
}