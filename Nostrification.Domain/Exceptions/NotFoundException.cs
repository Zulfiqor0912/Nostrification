namespace Nostrification.Domain.Exceptions;

public class NotFoundException(string resource, string resourceId) : Exception($"{resource} with ID {resourceId} doesn't exist")
{

}
