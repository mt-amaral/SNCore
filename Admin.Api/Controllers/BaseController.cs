using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers;

[ApiController]
public class BaseController<TBase, TRequest> : ControllerBase
    where TBase : class
    where TRequest : class
{
    private readonly IValidator<TRequest> _validator;
    private readonly IValidator<TBase> _validatorBase;
    public BaseController(IValidator<TRequest> validator, IValidator<TBase> validatorBase)
    {
        _validator = validator;
        _validatorBase = validatorBase;
    }

    protected void ValidationBase(TBase entityBase)
    {
        var validationResult =  _validatorBase.Validate(entityBase);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }

    protected void ValidationRequest(TRequest entityRequest)
    {
        var validationResult = _validator.Validate(entityRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }
}