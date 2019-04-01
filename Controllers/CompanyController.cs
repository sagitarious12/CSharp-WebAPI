using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API_Test.Services;
using Web_API_Test.Models;
using System.Web.Http.Cors;

namespace Web_API_Test.Controllers
{

    // creating the route for the endpoints
    [Route("api/companies")]
    // enabling CORS to allow the angular application to send requests to this group of endpoints
    [EnableCors(origins: "http://www.example.com", headers: "*", methods: "*")]


    public class CompanyController : ControllerBase
    {
        // a reference to the company service which holds the methods to do database work.
        private readonly CompanyService _companyService;


        // the Company Controller Constructor
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }



        /*
         * This is the first endpoint. this is a get request to get companies from the database 
         */
        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            return _companyService.Get();
        }


        /*
         * this is also a get request but requires an id to return one company record
         */
        [HttpGet("{id}", Name = "GetCompany")]
        public ActionResult<Company> Get(string id)
        {
            var company = _companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }


        /*
         * This is a post request.
         * send the company data in the body of the request and this will save it into the database        
         */
        [HttpPost]
        public ActionResult<Company> Create([FromBody]Company company)
        {
            _companyService.Create(company);
            return CreatedAtRoute("GetCompany", new { id = company.Id.ToString() }, company);
        }


        /*
         * this is a PUT request
         * send the id in the route parameters and the updated company in the body of the request
         * and it will update the company in the database
         */
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]string id, [FromBody]Company companyIn)
        {
            var company = _companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            _companyService.Update(id, companyIn);
            return NoContent();
        }


        /*
         * this is a DELETE request
         * send this delete request with the id in the route parameters and it will delete that record
         * from the database.
         */
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var company = _companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            _companyService.Remove(company._id);
            return NoContent();
        }
    }
}
