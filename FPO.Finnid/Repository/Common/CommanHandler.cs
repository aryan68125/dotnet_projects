using finnit.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace finnit.Repository.Common
{
    public class CommanHandler : IRequestHandler<StateCommand, List<State>>,IRequestHandler<CityCommand,List<City>>
    {
        private readonly IDataLayer _dataLayer;
        public CommanHandler(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public async Task<List<State>> Handle(StateCommand request, CancellationToken cancellationToken)
        {
            var list = new List<State>();
            try
            {
                list = await _dataLayer.GetAllAsync<State>("Proc_GetState",new
                {
                    request.Id
                });
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public async Task<List<City>> Handle(CityCommand request, CancellationToken cancellationToken)
        {
            var list = new List<City>();
            try
            {
                list = await _dataLayer.GetAllAsync<City>("Proc_GetCity", new
                {
                    request.StateId
                });
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
