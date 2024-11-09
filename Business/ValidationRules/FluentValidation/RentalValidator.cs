using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty(); 


            RuleFor(r => r.CustomerId).GreaterThan(0);

            // RentDate boş olamaz ve ReturnDate'ten önce olmalıdır.
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate)
                .When(r => r.ReturnDate.HasValue); // ReturnDate varsa, RentDate'ten büyük olmalı

            // ReturnDate, RentDate'ten önce olamaz.
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate)
                .When(r => r.ReturnDate.HasValue); // ReturnDate varsa, RentDate'ten büyük olmalı
        }
    }
}
