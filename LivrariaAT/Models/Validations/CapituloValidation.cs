using FluentValidation;

namespace LivrariaAT.Models.Validations
{
    public class CapituloValidation : AbstractValidator<Capitulo>
    {
        public CapituloValidation()
        {
            RuleFor(parameter => parameter.titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo.")
                .Length(1, 2083).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.")
                .Must(o => !(Uri.IsWellFormedUriString(o, UriKind.Absolute))).WithMessage("O endereço da imagem é inválido.");

            RuleFor(parameter => parameter.descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo.")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            
            RuleFor(parameter => parameter.livroid.ToString())
                    .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo.")
                    .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
