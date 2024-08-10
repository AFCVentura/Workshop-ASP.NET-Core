namespace workshop_asp_net_core_mvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string? message) : base(message)
        {
        }
    }
}
