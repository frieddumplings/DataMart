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

        
        [HttpGet]
        [ActionName("GetTop5")]
        public List<seedData> GetTop5()
        {
            return db.seedData.OrderBy(x => x.counter).Take(5).ToList();
        }

        [HttpGet]
        [Route("api/Car/returnText/{id}")]
        public string returnText(int? id)
        {
            return "This is default";
        }

        [HttpGet] //This is some custom MVC Routing that can be defined specificlly with the decoration method Route.
        [Route("Custom/Car/returnText/{text}")]
        [Route("GET/returnText/{text}")]
        public string returnText(string text)
        {
            return text;
        }

        // GET api/<controller>
        public List<seedData> Get()
        {
            return db.seedData.ToList();
        }

        // GET api/<controller>/5
        public seedData Get(int id)
        {
            return db.seedData.FirstOrDefault(x => x.id == id);
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