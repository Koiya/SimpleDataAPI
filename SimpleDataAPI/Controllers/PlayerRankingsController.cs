using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDataAPI.Models;
using SimpleDataAPI.Data;

namespace SimpleDataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerRankingsController : ControllerBase
    {
        private readonly APIContext _context;
        public PlayerRankingsController(APIContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(PlayerRankings rankings)
        {
            if (rankings.Id == 0)
            {
                _context.Rankings.Add(rankings);
            } else
            {
                var rankingsInDb = _context.Rankings.Find(rankings.Id);
                if (rankingsInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                rankingsInDb = rankings;

            }
            _context.SaveChanges();
            return new JsonResult(Ok(rankings));
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Rankings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Rankings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());

            }

            _context.Rankings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());

        }
        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Rankings.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
