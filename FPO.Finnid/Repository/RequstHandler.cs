using finnit.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace finnit.Repository
{
    public class RequstHandler :
        IRequestHandler<RegistrationEnquery, object>
    {

        public async Task<object> Handle(RegistrationEnquery request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
              
                string Body = @"<b>Title: </b>"+request.Title+"<br><b>Name : </b>" + request.Name + "<br/><b>Email : </b>" + request.Email + "<br/><b>Contact No. : </b>" + request.ContactNo;
                data = MyUtility.SendEmail("info@finnidpro.com", "Finnid Website Enquiry", Body);
               
            }
            catch (Exception ex)
            {
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message.ToString());
            }
            return data;
        }

    }
}
