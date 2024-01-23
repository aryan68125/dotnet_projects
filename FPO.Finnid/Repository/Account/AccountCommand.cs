using MediatR;

namespace finnit.Repository.Account
{
    public class AccountCommand
    { }
    public class LoginCommand : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignUpCommand : IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string CreatedIP { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string HostName { get; set; }
    }
}
