using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Exceptions;

internal class ValidationException : Exception
{
    public IList<ValidationResult> Errors { get; }
    public ValidationException(IList<ValidationResult> errors)
    {
        Errors = errors;
    }
}
