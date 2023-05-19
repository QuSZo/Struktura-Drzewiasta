namespace StrukturaDrzewiasta.App.Middleware;

public class BadRequestException : Exception
{
    public BadRequestException(string message = "Bad request") : base(message)
    {
        
    }
}
public class NotFoundException : Exception
{
    public NotFoundException(string message = "Not found") : base(message)
    {
        
    }
}

