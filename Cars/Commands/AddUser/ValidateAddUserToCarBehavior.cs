﻿using FuelProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FuelProject.Cars.Commands.AddUser;

public class ValidateAddUserToCarBehavior : IPipelineBehavior<AddUserToCarCommand, ActionResult>
{
    private readonly ICarRepository _carRepository;
    private readonly IUserRepository _userRepository;

    public ValidateAddUserToCarBehavior(ICarRepository carRepository, IUserRepository userRepository)
    {
        _carRepository = carRepository;
        _userRepository = userRepository;
    }

    public async Task<ActionResult> Handle(AddUserToCarCommand request, RequestHandlerDelegate<ActionResult> next, CancellationToken cancellationToken)
    {
        if ((await _userRepository.GetUserById(request.UserId)) is null)
        {
            return new NotFoundObjectResult($"User with id: {request.UserId} was not found");
        }

        if ((await _carRepository.GetCarById(request.CarId)) is null)
        {
            return new NotFoundObjectResult($"Car with id: {request.CarId} was not found");
        }
        return await next();
    }
}
