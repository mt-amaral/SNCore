using System.ComponentModel.DataAnnotations;

namespace Admin.Domain.Exceptions;

internal class ValidationException : Exception
{
    public IList<ValidationResult> Errors { get; }
    public ValidationException(IList<ValidationResult> errors)
    {
        Errors = errors;
    }
}
