using System.Collections.Generic;
using System.Linq;
using Web_API_Test.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Web_API_Test.Services
{
    public class CompanyService
    {

        // mongo company collection reference
        private readonly IMongoCollection<Company> _company;


        // company service constructor
        public CompanyService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("caliber"));
            var database = client.GetDatabase("caliber");
            _company = database.GetCollection<Company>("company");
        }


        // get all companies
        public List<Company> Get()
        {
            return _company.Find(company => true).ToList();
        }


        // get an individual company
        public Company Get(string id)
        {
            Company comp = _company.Find<Company>(company => company.Id == id).FirstOrDefault();
            if(comp == null)
            {
                return _company.Find<Company>(company => company._id == id).FirstOrDefault();
            }
            return comp;
        }


        // create a company
        public Company Create(Company company)
        {
            _company.InsertOne(company);
            return company;
        }


        // update a company
        public void Update(string id, Company companyIn)
        {
            _company.ReplaceOne(company => company.Id == id || company._id == id, companyIn);
        }


        // remove a company by a Company reference
        public void Remove(Company companyIn)
        {
            _company.DeleteOne(company => company.Id == companyIn.Id || company._id == companyIn._id);
        }


        // remove a company by the company _id
        public void Remove(string id)
        {
            _company.DeleteOne(company => company.Id == id || company._id == id);
        }
    }
}
