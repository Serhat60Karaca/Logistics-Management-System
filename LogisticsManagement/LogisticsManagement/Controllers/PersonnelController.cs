using LogisticsManagement.Models;
using LogisticsManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagement.Controllers
{
    public class PersonnelController : Controller
    {
        private IPersonnelRepository personnelRepository;
        public PersonnelController(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public IActionResult Index()
        {
            var result = personnelRepository.Personnels;
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personnel p)
        {
            personnelRepository.CreatePersonnel(p);
            return View();
        }
        public IActionResult Delete(int id, Personnel p)
        {
            p = personnelRepository.GetById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            personnelRepository.DeletePersonnel(id);
            return View("Index");
        }
        public IActionResult Update(int id)
        {
            return View(personnelRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Update(Personnel personnel)
        {
            personnelRepository.UpdatePersonnel(personnel);
            return View();
        }
    }
}
