using System.Globalization;
using Application.Common;
using Application.Common.Helper;
using Application.Common.Interfaces.Repositories;
using Application.Users.Exceptions;
using CsvHelper;
using Domain;
using MediatR;

namespace Application.Users.Commands;

public class UploadUserCSVFileCommand : IRequest<Result<IReadOnlyList<User>, UserException>>
{
    public string filePath { get; init; }
}

public class UploadUserCSVFileCommandHandler(IUserRepository repository)
    : IRequestHandler<UploadUserCSVFileCommand, Result<IReadOnlyList<User>, UserException>>
{
    public async Task<Result<IReadOnlyList<User>, UserException>> Handle(UploadUserCSVFileCommand request,
        CancellationToken cancellationToken)
    {
        if (Path.GetExtension(request.filePath)?.ToLower() != ".csv")
        {
            return new NotCorrectFileExtension();
        }

        return await GetDataFromFile(request.filePath,cancellationToken);
    }

    private async Task<Result<IReadOnlyList<User>, UserException>> GetDataFromFile(string filePath,
        CancellationToken cancellationToken)
    {
        try
        {
            var users = new List<User>();

            using var reader = new StreamReader(filePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<UserCsvMap>();

            users = csvReader.GetRecords<User>().ToList();

            await repository.AddRange(users, cancellationToken);

            return users;
        }
        catch (Exception e)
        {
            return new UnknownException(e);
        }
    }
}