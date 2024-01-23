using finnit.Models;
using MediatR;
using System.Collections.Generic;

namespace finnit.Repository.Common
{
    public class CommanCommands
    {
    }
    public class StateCommand : IRequest<List<State>>
    {
        public int Id { get; set; }
    }
    public class CityCommand : IRequest<List<City>>
    {
        public int StateId { get; set; }
    }
}
