using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schedule_mvc.Models;
using schedule_mvc.Repositories;

namespace schedule_mvc.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctor_repository;

        public DoctorsController(IDoctorRepository doctor_repository)
        {
            _doctor_repository = doctor_repository;
        }

        // GET: Doctors
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Doctor.ToListAsync());
        //}

        public async Task<IActionResult> Index(string name)
        {
            IQueryable<Doctor> query = _doctor_repository.QueryLikeName(name);

            int count = _doctor_repository.GetTotal();
            int filtered_count = query.Count();
            ViewData["CountText"] = $"Total: {count} Filtered {filtered_count}";
            return View(await query.ToListAsync());
        }



        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctor_repository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Id = Guid.NewGuid();
                _doctor_repository.Add(doctor);
                await _doctor_repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctor_repository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Phone,Email")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _doctor_repository.Update(doctor);
                    await _doctor_repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_doctor_repository.Exists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctor_repository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doctor = await _doctor_repository.GetByIdAsync(id);
            if (doctor != null)
            {
                _doctor_repository.Delete(doctor);
                await _doctor_repository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
