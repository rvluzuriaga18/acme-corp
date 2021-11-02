using System;
using System.Net;
using System.Web.Http;
using Acme.Data.DbContext;
using Acme.Data.Interfaces;
using Acme.Data.Services;

namespace Acme.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        ICustomer _icustomer;

        //Constructor
        public CustomerController()
        {
            _icustomer = new CustomerRepository();
        }

        [HttpGet]
        [Route("api/Customer/GetAllCustomers")]
        public IHttpActionResult GetAllCustomers()
        {
            try
            {
                var data = _icustomer.GetAllCustomers();
                if (!data.IsSuccess) throw new Exception(data.Message);

                return Ok(data.Result);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/Customer/GetCustomerByID")]
        public IHttpActionResult GetCustomerByID(long id)
        {
            try
            {
                var data = _icustomer.GetCustomerByCustomerID(id);
                if (!data.IsSuccess) throw new Exception(data.Message);

                return Ok(data.Result);
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Record not found."))
                    return Content(HttpStatusCode.NotFound, e.Message);
                else
                    return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/Customer/Save")]
        public IHttpActionResult SaveCustomer(Customer customer)
        {
            try
            {
                var data = _icustomer.SaveCustomer(customer);
                if (!data.IsSuccess) throw new Exception(data.Message);

                return Ok(data.IsSuccess);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/Customer/Update")]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                var data = _icustomer.UpdateCustomer(customer);
                if (!data.IsSuccess) throw new Exception(data.Message);

                return Ok(data.IsSuccess);
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Record not found."))
                    return Content(HttpStatusCode.NotFound, e.Message);
                else
                    return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Customer/Delete")]
        public IHttpActionResult DeleteCustomer(long id)
        {
            try
            {
                var data = _icustomer.DeleteCustomer(id);
                if (!data.IsSuccess) throw new Exception(data.Message);

                return Ok(data.IsSuccess);
            }
            catch (Exception e)
            {
               if(e.ToString().Contains("Record not found."))
                    return Content(HttpStatusCode.NotFound, e.Message);
               else
                    return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}