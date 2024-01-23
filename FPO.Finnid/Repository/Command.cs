using MediatR;

namespace finnit.Repository
{
    public class Command
    {
    }
    public class RegistrationEnquery : IRequest<object>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Title { get; set; }
    }
}
