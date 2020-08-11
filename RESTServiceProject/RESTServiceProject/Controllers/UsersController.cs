using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTServiceProject.Models;

namespace RESTServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<UserModel> users = new List<UserModel>();
        public static int CurrentId = 101;


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.DateAdded = DateTime.Now;
            value.Id = CurrentId++;
            users.Add(value);

            // Look at the Headers in the response output in Postman
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }




        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel value)
        {
            if (users.FirstOrDefault(t => t.Id == id) != null)
            {
                var modifyUser = users.FirstOrDefault(t => t.Id == id);

                modifyUser.Id = id;
                modifyUser.Email = value.Email;
                modifyUser.Password = value.Password;

                //modifyContact = value;
                return Ok(users);
            }

            return NotFound();
        }





        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (users.FirstOrDefault(t => t.Id == id) != null)
            {
                var removeContact = users.Where(t => t.Id == id);
                users.Remove(removeContact.First());

                //contacts.RemoveAll(t => t.Id == id);

                return Content(String.Format("{0} deleted", id.ToString()));
            }

            return NotFound();
        }
    }
}
