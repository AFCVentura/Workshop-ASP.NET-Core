namespace workshop_asp_net_core_mvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
