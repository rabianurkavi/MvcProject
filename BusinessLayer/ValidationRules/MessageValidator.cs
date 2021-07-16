using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).MaximumLength(400).WithMessage("400 karakterden fazla yazamazsınız.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("400 karakterden fazla yazamazsınız.");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mailini boş geçemezsiniz.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("30 karakterden fazla metin giremezsiniz.");
        }
    }
}
