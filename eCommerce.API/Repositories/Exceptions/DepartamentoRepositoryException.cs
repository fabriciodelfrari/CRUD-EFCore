namespace eCommerce.API.Repositories.Exceptions
{
    public class DepartamentoRepositoryException : Exception
    {
        public DepartamentoRepositoryException(string message, Exception exception) : base(message, exception)
        {
            
        }
    }
}