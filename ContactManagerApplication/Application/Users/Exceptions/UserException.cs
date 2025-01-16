using Domain;

namespace Application.Users.Exceptions;

public class UserException(string message, Exception? innerException = null)
    : Exception(message, innerException)
{
}

public class UserNotFoundException(int UserId)
    : UserException($"User with id {UserId} not found");
public class NotCorrectFileExtension() 
    : UserException( $"File with wrong extension!");

public class CorrectFileNotFoundException(string fileName) 
    : UserException($"File with name: ({fileName}) not found!");

public class UnknownException(Exception exception) 
    : UserException($"Unknown exception!{exception}", exception);