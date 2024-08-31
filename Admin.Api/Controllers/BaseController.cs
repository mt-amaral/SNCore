using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers;

[ApiController]
public class BaseController : ControllerBase

{
    protected void ValidateEntity<T>(T entity, IValidator<T> validator)
    {
        var validationResult = validator.Validate(entity);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }
    protected void ValidateInt(int num)
    {
        if (num <= 0)
            throw new ValidationException("O número deve ser maior ou igual a zero.");
    }
}