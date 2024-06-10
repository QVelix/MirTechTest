using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MirTechTest.Models;

namespace MirTechTest.Controllers;

[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
	private ApplicationContext _applicationContext;

	public StaffController(ApplicationContext applicationContext)
	{
		_applicationContext = applicationContext;
	}

	[HttpGet]
	public ActionResult<IEnumerable<Staff>> Get()
	{
		return _applicationContext.Staffs.ToList();
	}

	[HttpGet("{id}")]
	public ActionResult<Staff> Get(long id)
	{
		var foundStaff = _applicationContext.Staffs.Find(id);
		if (foundStaff == null)
		{
			return NotFound();
		}

		return foundStaff;
	}

	[HttpPost]
	public ActionResult Post(Staff staff)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		_applicationContext.Staffs.Add(staff);
		_applicationContext.SaveChanges();
		return Ok(staff);
	}

	[HttpPut("{id}")]
	public ActionResult Put(long id, Staff staff)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		_applicationContext.Entry(staff).State = EntityState.Modified;
		_applicationContext.SaveChanges();
		return Ok(staff);
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(long id)
	{
		var staff = _applicationContext.Staffs.Find(id);
		if (staff == null)
		{
			return NotFound();
		}

		_applicationContext.Staffs.Remove(staff);
		_applicationContext.SaveChanges();
		return NoContent();
	}
}