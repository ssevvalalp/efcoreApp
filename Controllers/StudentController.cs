using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class StudentController : Controller
    {
        //------ injection
       // var context = new DataContext();
        private readonly DataContext _context;
        public StudentController(DataContext context)
        {

            _context = context; 

        }
        //------


        public async Task <IActionResult> Index()
        {
            //var students = _context.Students.ToList(); //senkron
            var students =await  _context.Students.ToListAsync();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Student model)  //database iletişimlerinde async. yemek sipariş örneği
        {
            _context.Students.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
    }
}
