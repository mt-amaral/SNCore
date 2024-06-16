using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Validations;

internal class DomainValidation : Exception
{
    public DomainValidation(string error): base(error) { }
    public static void When(bool hasErro, string error)
    {
        if (hasErro)
        {
            throw new Exception(error);
        }
    }
};
