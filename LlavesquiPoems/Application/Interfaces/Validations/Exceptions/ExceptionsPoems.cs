namespace LlavesquiPoems.Application.Interfaces.Validations.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string message) : base(message) { }
}

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message) { }
}