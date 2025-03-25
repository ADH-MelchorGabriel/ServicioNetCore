using Microsoft.AspNetCore.Mvc;
using ServicioNetCore.Web.Data;

namespace ServicioNetCore.Web.Controllers
{
    public class AlumnoController : Controller
    {

        private readonly DataContext _context;
        public AlumnoController(DataContext context)
        {
                _context=context;
        }
        public IActionResult Index()
        {
            var lista=_context.Alumnos.ToList();
            return View(lista);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.AlumnoEntity alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var alumno = _context.Alumnos.Where(x=> x.NumeroCuenta==id).FirstOrDefault();
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        public IActionResult Edit(Models.AlumnoEntity alumno)
        {
            if (ModelState.IsValid)
            {
                var update = _context.Alumnos.Where(x => x.NumeroCuenta == alumno.NumeroCuenta).FirstOrDefault();
                update.Nombre = alumno.Nombre;
                update.ApellidoPaterno = alumno.ApellidoPaterno;
                update.ApellidoMaterno = alumno.ApellidoMaterno;    
                update.Nip = alumno.Nip;
                update.Grado = alumno.Grado;    

                _context.Alumnos.Update(update);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var alumno = _context.Alumnos.Where(x => x.NumeroCuenta == id).FirstOrDefault();
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumno); 
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
