namespace workshop_asp_net_core_mvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string? message) : base(message)
        {
        }
    }
}
