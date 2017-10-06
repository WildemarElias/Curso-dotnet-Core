using System;
using System.Collections.Generic;
using System.Linq;//Uma maneira de escrever os Query
using System.Threading.Tasks;
using MicrosoftAspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList.Models;

namespace WatchList.Controllers 
{
    [Route("api/user")]
    public class UserController
    {
        private readonly MovieContext _ctx;
        
        public UserController(MovieContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _ctx.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _ctx.User.FirstOrDefaul(u => u.Id == id);
        }
        [HttpPost]
        public int Post([FromBody]User value)
        {
            _ctx.User.Add(value);
            _ctx.SaveChanges();
            return value.Id;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            var user = Get(id);
            user.Name = Value.Name;
            user.Email = value.Email;
            _ctx.Entry(user).state = EntityState.Modified;
            _ctx.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = Get(id);
            _ctx.User.Remove(user);
            _ctx.SaveChanges();
        }
    }
}