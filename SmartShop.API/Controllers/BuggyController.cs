using Microsoft.AspNetCore.Mvc;
using SmartShop.Entities;
using SmartShop.Infrastructure;

namespace SmartShop.API;

public class BuggyController : BaseApiController
{
    private readonly ApplicationDbContext _context;
    public BuggyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequest()
    {
        var thing = _context.Computers.Find(42);

        if (thing == null) return NotFound(new ApiResponse(404));

        return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        throw new Exception();
        // var thing = _context.Products.Find(42);
        // var thingToReturn = thing.ToString();
        //return Ok(); //we will comment this part of the code until we test it 
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    {
        return Ok();
    }
}
