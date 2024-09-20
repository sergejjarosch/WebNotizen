using Microsoft.AspNetCore.Mvc;
using WebNotizen.Models;
using WebNotizen.ViewModels;

namespace WebNotizen.Controllers
{
    public class NotizenController : Controller
    {
        public IActionResult Index()
        {
            var notizen = NotizenRepository.GetNotiz(loadCategory: true);
            return View(notizen);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new NotizViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(NotizViewModel notizViewModel)
        {
            if (ModelState.IsValid)
            {
                NotizenRepository.AddNotiz(notizViewModel.Notiz);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add"; // in case of Invalid Information
            notizViewModel.Categories = CategoriesRepository.GetCategories();
            return View(notizViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var notizViewModel = new NotizViewModel
            {
                Notiz = NotizenRepository.GetNotizById(id) ?? new Notiz(),
                Categories = CategoriesRepository.GetCategories()
            };

            return View(notizViewModel);
        }

        [HttpPost]
        public IActionResult Edit(NotizViewModel notizenViewModel)
        {
            if (ModelState.IsValid)
            {
                NotizenRepository.UpdateNotiz(notizenViewModel.Notiz.NotizId, notizenViewModel.Notiz);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";// <- View Information in Case of Invalid Information
            notizenViewModel.Categories = CategoriesRepository.GetCategories();
            return View(notizenViewModel);
        }

        public IActionResult Delete(int id)
        {
            NotizenRepository.DeleteNotiz(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var notizen = NotizenRepository.GetNotizByCategoryId(categoryId);

            return PartialView("_Products", notizen);
        }
    }
}
