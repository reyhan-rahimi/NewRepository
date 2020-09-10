using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using testMiddelware.classes;
using testMiddelware.filters;

namespace testMiddelware.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {

        public readonly ClassTest TTT;
        public readonly DataBase db;
        public readonly indentity indentity;
        public readonly ActionFilter context;
        public HomeController(IOptions <ClassTest> test, DataBase DB, IOptions<indentity> options, ActionFilter filter)
        {
            TTT = test.Value;
            db = DB;
            indentity = options.Value;
            context = filter;
        }

        [HttpGet]
        public IActionResult action()
        {
            Console.WriteLine(TTT.Name);
            Console.WriteLine(TTT.Lastname);
            return Ok();
        }
        [HttpPost]
        public IActionResult add([FromBody] ClassTest test)
        {
            db.Add(new ClassTest() { Name = test.Name, Lastname = test.Lastname });
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult back(string c)
        {
            var s = db.Classes.Where(n => n.Name == c);
            var f = s.First();
            Console.WriteLine(f.Name + f.Lastname);
            return Ok();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult grase([FromBody] ClassTest c)
        {
            ClassTest c1 = new ClassTest();
            c1.Name = c.Name;
            c1.Lastname = c.Lastname;
            db.Classes.Add(c);
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult grase2([FromBody] ClassTest test)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Classes.Add(test);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);
            
            }
            catch(Exception )
            {
                throw;
            }
           
        }

    }
}
