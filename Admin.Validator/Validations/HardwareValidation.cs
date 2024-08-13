using FluentValidation;
using Admin.Share.Request;

namespace Admin.Validator.Validations;

public class HardwareValidation : AbstractValidator<HardwareRequest>
{
    public HardwareValidation()
    {
        RuleFor(hardware => hardware.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Id não pode ser negativo");

        RuleFor(hardware => hardware.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .MaximumLength(50).WithMessage("Nome de modelo muito longa");

        RuleFor(hardware => hardware.Description)
            .NotEmpty().WithMessage("Descrição não pode ser vazia")
            .MaximumLength(50).WithMessage("Descrição muito longa");

        RuleFor(hardware => hardware.HardwareModel)
            .IsInEnum().WithMessage("Modelo inválido");

        RuleFor(hardware => hardware.Ipv4)
            .NotEmpty().WithMessage("Ipv4 não pode ser vazio")
            .MaximumLength(15).WithMessage("Ipv4 inválido")
            .Matches(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
            .WithMessage("Formato de Ipv4 inválido");
    }
}
