using FluentValidation;
using Admin.Shared.Base;


namespace Admin.Validator.Validations;

public class HardwareValidation<T> : AbstractValidator<T>
    where T : HardwareBase
{
    public HardwareValidation()
    {
        // Specify Validation
        //if (typeof(HardwareRequest).IsAssignableFrom(typeof(T)))
        //{
        //    RuleFor(entity => ((HardwareRequest)(object)entity!).Id)
        //        .GreaterThanOrEqualTo(0).WithMessage("Id não pode ser negativo");
        //} 
        RuleFor(entity => entity.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .MaximumLength(50).WithMessage("Nome de modelo muito longa");

        RuleFor(entity => entity.Description)
            .NotEmpty().WithMessage("Descrição não pode ser vazia")
            .MaximumLength(50).WithMessage("Descrição muito longa");

        RuleFor(entity => entity.HardwareModel)
            .IsInEnum().WithMessage("Modelo inválido");

        RuleFor(entity => entity.Ipv4)
            .NotEmpty().WithMessage("Ipv4 não pode ser vazio")
            .MaximumLength(15).WithMessage("Ipv4 inválido")
            .Matches(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
            .WithMessage("Formato de Ipv4 inválido");
    }
}
