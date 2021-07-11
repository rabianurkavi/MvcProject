using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContentValidator:AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x => x.ContentValue).NotEmpty().WithMessage("İçerik kısmını boş bırakamazsınız.");
        }
    }
}
