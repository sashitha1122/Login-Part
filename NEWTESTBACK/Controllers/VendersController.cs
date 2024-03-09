using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEWTESTBACK.Models;

namespace NEWTESTBACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendersController : ControllerBase
    {
        private readonly UserContext userContext;

        public VendersController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [HttpGet]
        [Route("GetVenders")]

        public List<Venders> GetVenders()
        {
            return userContext.Venders.ToList();
        }

        [HttpGet]
        [Route("GetVender")]

        public Venders GetVenders(int id)
        { 
            return userContext.Venders.Where(v => v.Id == id).FirstOrDefault();
        
        }

        [HttpPost]
        [Route("AddVender")]
        public string AddUser(Venders venders)
        {
            string response = string.Empty;
            userContext.Venders.Add(venders);
            userContext.SaveChanges();
            return "Vender added";
        }

        [HttpPut]
        [Route("UpdateVender")]
        public string UpdateVenders(Venders Vender)
        {
            userContext.Entry(Vender).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges();
            return "Vender Updated";
        }

        [HttpDelete]
        [Route("DeleteVender")]
        public string DeleteUser(int id)
        {
            Users user = userContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return "User deleted";
            }
            else
            {
                return "Not User deleted";
            }
        } 
    }
}
