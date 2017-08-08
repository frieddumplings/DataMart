using DataMartApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DataMartApp.Controllers
{
    public class CarController : ApiController
    {
        developmentEntities db = new developmentEntities();
        // GET api/<controller>
        public List<seedData> Get()
        {
            return db.seedData.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public List<seedData> Post([FromBody]string value)
        {
            int data = db.seedData.OrderBy(x => x.id).Max(x => x.id);
            seedData car = new seedData();
            car.id = data + 1;
            car.name = value;
            Random random = new Random();
            car.counter = random.Next(0, 1000000);
            db.seedData.Add(car);
            db.SaveChanges();
            return db.seedData.ToList();
        }

        // PUT api/<controller>/5
        public int Put(int id, [FromBody]string value)
        {
            return 0;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}