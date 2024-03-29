﻿using AutoMapper;
using FuelProject.Domain.DTos;
using FuelProject.Domain.Entities;
using FuelProject.Infrastructure;
using MediatR;
using MediatR.Extensions.AttributedBehaviors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelProject.Cars.Queries.GetCarsForUser;

[MediatRBehavior(typeof(ValidateUserExistsBehavior))]
public record GetCarsForUserQuery(string UserId) : IRequest<ActionResult<List<CarDto>>>;

public class GetCarsForUserQueryHandler : IRequestHandler<GetCarsForUserQuery, ActionResult<List<CarDto>>>
{
    private readonly IMapper _mapper;
    private readonly DiaryDbContext _context;

    public GetCarsForUserQueryHandler(IMapper mapper, DiaryDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ActionResult<List<CarDto>>> Handle(GetCarsForUserQuery request, CancellationToken cancellationToken)
    {
        var query = (await _context.Users.Include(x => x.Cars).Where(x => x.Id.ToString() == request.UserId).FirstAsync()).Cars;

        return new OkObjectResult(_mapper.Map<List<Car>, List<CarDto>>(query));
    }
}
