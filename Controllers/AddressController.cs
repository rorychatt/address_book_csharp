using address_book_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace address_book_csharp.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressRepository _repository = new();

        public IActionResult Index(string searchQuery)
        {
            var addresses = string.IsNullOrEmpty(searchQuery) ?
                _repository.GetAll() : _repository.Search(searchQuery);
            ViewBag.searchQuery = searchQuery;
            return View(addresses);
        }

        public IActionResult Details(int id)
        {
            var address = _repository.GetByID(id);
            if (address == null) return NotFound();
            return View(address);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            _repository.Add(address);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var address = _repository.GetByID(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        public IActionResult Edit(Address address)
        {
            _repository.Update(address);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var address = _repository.GetByID(id);
            if (address == null) return NotFound();
            return View(address);
        }

        [HttpDelete]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}