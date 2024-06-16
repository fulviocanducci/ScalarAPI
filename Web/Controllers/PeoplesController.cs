using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Web.Models;

namespace Web.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Produces(MediaTypeNames.Application.Json)]
   public class PeoplesController : ControllerBase
   {
      [HttpGet]
      [ProducesResponseType(typeof(People[]), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public IResult GetPeople()
      {
         try
         {
            return Results.Ok(new People[]
            {
               new People{ Id = 1, Name = "Forisvaldo"}
            });
         }
         catch (Exception)
         {
            throw;
         }
         finally
         {

         }
      }


      [HttpGet("{id}", Name = "GetPeople")]
      public IResult GetPeople(int id)
      {
         try
         {
            return Results.Ok(new People[]
            {
               new People { Id = 1, Name = "Forisvaldo 1111"}
            });
         }
         catch (Exception)
         {
            throw;
         }
         finally
         {

         }
      }



      [HttpPost]
      public IResult Create(People p)
      {
         return Results.CreatedAtRoute(routeName: nameof(GetPeople), new { Id = 1 }, new People { Id = 1, Name = "Forisvaldo 333" });
      }
   }
}
