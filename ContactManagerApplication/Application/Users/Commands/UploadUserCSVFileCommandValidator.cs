using FluentValidation;

namespace Application.Users.Commands;

public class UploadUserCSVFileCommandValidator : AbstractValidator<UploadUserCSVFileCommand>
{
    public UploadUserCSVFileCommandValidator()
    {
        RuleFor(x=>x.filePath).NotEmpty().WithMessage("File path cannot be empty");
    }
}