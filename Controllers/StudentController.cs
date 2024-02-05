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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var std = await _context.Students.FirstOrDefaultAsync(std => std.StudentId == id);
           var std = await _context.Students.FindAsync(id);

            if (std == null)
            {
                return NotFound();
            }

            return View(std);
        }
    }
}
