using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentValidator:AbstractValidator<Rental>
    {
        public RentValidator()
        {
            RuleFor(r=>r.ReturnDate == null);
        }
    }
}
