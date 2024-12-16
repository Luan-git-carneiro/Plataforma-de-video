namespace FlixCatalogDomain.Exceptions;

public class EntityValidationArgumentException : System.Exception
{
    public EntityValidationArgumentException(string message) : base(message)
    {
    }
}
