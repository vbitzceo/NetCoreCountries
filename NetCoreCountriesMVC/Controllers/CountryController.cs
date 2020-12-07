using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using voidBitz.NetCore.Utilities;
using voidBitz.NETCore.NetCoreCountries.Models;
using voidBitz.NETCore.NetCoreCountries.Repository.Interfaces;

namespace NetCoreCountriesMVC.Views.Home
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        
        //GET - INDEX
        public IActionResult Index()
        {
            var model = _countryRepository.GetWhere(orderBy: x => x.OrderBy(x => x.Name.ToLower()),
                                                      isTracking: false);

            return View(model.ToList());
        }

        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            var model = new Country();
            if (id == null)
            {
                return View(model);
            }
            else
            {
                model = _countryRepository.GetById(id.GetValueOrDefault());
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Country model)
        {
            if (ModelState.IsValid)
            {
                if (_countryRepository.Exists(a => a.Id != model.Id && a.Name.Equals(model.Name)))
                {
                    TempData[AppConstants.Failure] = string.Format(AppConstants.Notification_Error, String.Format(AppConstants.ExistsErrorString, "country"));
                    ModelState.AddModelError("Text", String.Format(AppConstants.ExistsErrorString, "country"));
                    return View(model);
                }

                if (_countryRepository.Upsert(model))
                {
                    TempData[AppConstants.Success] = string.Format(AppConstants.Notification_Saved, "country");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData[AppConstants.Failure] = string.Format(AppConstants.Notification_Error, String.Format(AppConstants.UpdateAddErrorWhenSaving, model.Name));
                    ModelState.AddModelError("", String.Format(AppConstants.UpdateAddErrorWhenSaving, model.Name));
                    return View(model);
                }
            }

            return View(model);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Country obj = _countryRepository.GetById(id.GetValueOrDefault(), true);
            if (obj == null)
            {
                return NotFound();
            }

            // Incase something goes wrong
            return View(obj);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Country objFromDB = _countryRepository.GetById(id.GetValueOrDefault(), true);
            if (objFromDB == null)
            {
                return NotFound();
            }

            _countryRepository.RemoveWithSave(objFromDB);

            return RedirectToAction(nameof(Index));
        }

    }
}
