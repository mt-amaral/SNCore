
using Admin.Shared.Payload;
using FluentValidation;

namespace Admin.Validator.Validations;

public class TelnetValidation<T> : AbstractValidator<T>
    where T : TelnetPayload
{
    public TelnetValidation()
    {

        RuleFor(telnet => telnet.User)
            .NotEmpty().WithMessage("Usuario não pode ser vazio")
            .MaximumLength(30).WithMessage("Versão muito longa");

        RuleFor(telnet => telnet.Password)
            .NotEmpty().WithMessage("Senha não pode ser vazio")
            .MaximumLength(100).WithMessage("Versão muito longa");

        RuleFor(telnet => telnet.Port)
            .GreaterThan(0).WithMessage("Porta deve ser maior que zero")
            .LessThanOrEqualTo(65536).WithMessage("Porta inválida");
    }
}
