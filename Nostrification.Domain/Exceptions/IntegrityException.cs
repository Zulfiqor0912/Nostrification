namespace Nostrification.Domain.Exceptions;

public class IntegrityException(string message) : Exception(message)
{
}
