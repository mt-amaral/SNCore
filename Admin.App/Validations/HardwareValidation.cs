using FluentValidation;
using Admin.Share.Response;

namespace Admin.App.Validations
{
    public class HardwareValidation : AbstractValidator<HardwareResponse>
    {
        public HardwareValidation()
        {
            RuleFor(hardware => hardware.Description)
                .NotEmpty().WithMessage("Descrição não pode ser vazia")
                .MaximumLength(50).WithMessage("Descrição muito longa");

            RuleFor(hardware => hardware.Model)
                .NotEmpty().WithMessage("Modelo não pode ser vazio")
                .MaximumLength(50).WithMessage("Descrição de modelo muito longa");

            RuleFor(hardware => hardware.Ipv4)
                .NotEmpty().WithMessage("Ipv4 não pode ser vazio")
                .MaximumLength(15).WithMessage("Ipv4 inválido")
                .Matches(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$").WithMessage("Formato de Ipv4 inválido");
        }
    }
}
