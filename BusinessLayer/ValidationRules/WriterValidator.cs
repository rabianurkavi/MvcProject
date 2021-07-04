using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Lütfen mailinizi girin.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Lütfen şifre girin.");
           
        }
    }
}
