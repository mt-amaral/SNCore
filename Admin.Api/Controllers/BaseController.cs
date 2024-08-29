using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace Admin.Api.Controllers;

[ApiController]
public class BaseController<TBase, TRequest> : ControllerBase
    where TBase : class
    where TRequest : class
{
    private readonly IValidator<TRequest> _validatorRequest;
    private readonly IValidator<TBase> _validatorBase;
    public BaseController(IValidator<TRequest> validatorRequest, IValidator<TBase> validatorBase)
    {
        _validatorRequest = validatorRequest;
        _validatorBase = validatorBase;
    }

    protected void ValidateEntity<T>(T entity, IValidator<T> validator)
    {
        var validationResult = validator.Validate(entity);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }
    protected void ValidateInt(int num)
    {
        if (num <= 0)
            throw new ValidationException("O número deve ser maior que zero.");
    }
    protected void ValidationBase(TBase entityBase)
    {
        ValidateEntity(entityBase, _validatorBase);
    }

    protected void ValidationRequest(TRequest entityRequest)
    {
        ValidateEntity(entityRequest, _validatorRequest);
    }
}