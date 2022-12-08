using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                List<Visitor> values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                Visitor value = context.Visitors.Find(id);
                if (value == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(value);
                }
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context= new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                Visitor value = context.Find<Visitor>(visitor.VisitorId);
                if (value == null)
                {
                    return NotFound();
                }
                else
                {
                    value.Name = visitor.Name;
                    value.Surname = visitor.Surname;
                    value.Mail = visitor.Mail;
                    value.City = visitor.City;
                    value.Country = visitor.Country;
                    context.Update(value);
                    context.SaveChanges();
                    return Ok(value);
                }
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                Visitor value = context.Visitors.Find(id);
                if (value == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(value);
                    context.SaveChanges();
                    return Ok(value);
                }
            }
        }

    }
}
