using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Activities;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
 public class Unattend
 {
  public class Command : IRequest
  {
   public Guid Id { get; set; }
  }

  public class Handler : IRequestHandler<Command>
  {
   private readonly IUserAccessor _userAccessor;
   private readonly DataContext _context;
   public Handler(DataContext context, IUserAccessor userAccessor)
   {
    _context = context;
    _userAccessor = userAccessor;
   }

   public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
   {
    var activity = await _context.Activities.FindAsync(request.Id);

    if (activity == null)
     throw new RestException(HttpStatusCode.NotFound, new { Activity = "Could not find activity" });

    var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());

    var attendance = await _context.UserActivities.SingleOrDefaultAsync(x => x.ActivityId == activity.Id && x.AppUserId == user.Id);

    if (attendance == null)
     return Unit.Value;

    if (attendance.IsHost)
     throw new RestException(HttpStatusCode.BadRequest, new { Attendance = "You cannot remove yourselft as host" });

    _context.UserActivities.Remove(attendance);

    var success = await _context.SaveChangesAsync() > 0;

    if (success) return Unit.Value;

    throw new Exception("Problem saving changes");
   }
  }
 }
}