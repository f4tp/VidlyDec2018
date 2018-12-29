using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyDec2018.Models;
using VidlyDec2018.Models.Dto;



//the API has been changed... it was first being passed in domain model objects (e.g. Customer), but instead, the data transfer object (DTO) has been used which reduced e.g. security issues

    //If using the API approach to interaction with the system, rather than the MVC approach, drop the MVC approach and just implement API approach... there should only be one way to e.g. create a new customer...
    //You obviously need to create Customer class and CustomerDto class, but the form that interacts with this should only interact with the API variant, not the actual MVC also, and you need to set attribute tags in the DTO class, not the actual class
namespace VidlyDec2018.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //  GET / api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {


            //after Map<Customer, CustomerDto> .. where dots would have been parentheses, these have been missed so the method is not called, instead it will use a delegate... a reference to this method
            //below is for when customers were being returned through MVC and not through the API
            //return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return customerDtos;
        }


        //  GET / api/customer/1
        public IHttpActionResult GetCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }

            

        }


        //although it is a post and expected would be a void / procedure instead of a function, it will create new things on the server we need to be aware of, like an id, that you would not otherwise know, so this is returned
        //if we have named the method PostCustomer, we wouldn't need the HttpPost tag also, but this isn't best practice as can cause errors later
        [HttpPost]
        //  POST /api/customers
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new can be used in place of return
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri.AbsoluteUri + "/" + customer.Id), customerDto);
            }
        }

        //  PUT / api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new can be used in place of return
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    Mapper.Map(customerDto, customerInDb);
                    //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
                    //customerInDb.Name = customerDto.Name;
                    //customerInDb.Birthdate = customerDto.Birthdate;
                    //customerInDb.IsSubscribedToNewsletter = //customerDto.IsSubscribedToNewsletter;
                    //customerInDb.MemberShipTypeId = customerDto.MemberShipTypeId;
                    _context.SaveChanges();
                }
            }
        }

        //  DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        }
    }
}
