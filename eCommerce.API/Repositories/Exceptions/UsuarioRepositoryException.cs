namespace eCommerce.API.Repositories.Exceptions
{
    public class UsuarioRepositoryException : Exception
    {
        public UsuarioRepositoryException(string message, Exception exception) : base(message, exception)
        {
            
        }
    }
}