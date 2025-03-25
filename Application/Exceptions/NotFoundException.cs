namespace Application.Exceptions;

public class NotFoundException(string entityName, string entityId) : Exception($"{entityName} with id {entityId} not found")
{

}
