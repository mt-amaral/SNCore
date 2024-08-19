using Admin.Shared.Base;
using FluentValidation;

namespace Admin.Validator.Validations;

public class SnmpValidation<T> : AbstractValidator<T>
    where T : SnmpBase
{
    public SnmpValidation()
    {

        RuleFor(snmp => snmp.Version)
            .NotEmpty().WithMessage("Versão não pode ser vazia")
            .MaximumLength(10).WithMessage("Versão muito longa");

        RuleFor(snmp => snmp.Community)
            .NotEmpty().WithMessage("Community não pode ser vazia")
            .MaximumLength(100).WithMessage("Community muito longa");

        RuleFor(snmp => snmp.Port)
            .GreaterThan(0).WithMessage("Porta deve ser maior que zero")
            .LessThanOrEqualTo(65536).WithMessage("Porta inválida");
    }
}
