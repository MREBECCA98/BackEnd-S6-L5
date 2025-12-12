using BackEnd_S6_L5.Models.Entities;
using BackEnd_S6_L5.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_S6_L5.Controllers
{
    public class CameraController : Controller
    {
        private readonly ICameraServices _cameraServices;

        public CameraController(ICameraServices cameraServices)
        {
            _cameraServices = cameraServices;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var camere = await _cameraServices.GetAllAsync();
            return View(camere);
        }




        // POST
        [HttpPost]
        public async Task<IActionResult> Index(Camera camera)
        {
            if (!ModelState.IsValid)
            {
                var camere = await _cameraServices.GetAllAsync();
                return View(camere);
            }



            camera.IdCamera = Guid.NewGuid();
            await _cameraServices.CreateAsync(camera);

            return RedirectToAction("Index");

        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var camera = await _cameraServices.GetByIdAsync(id);
            if (camera == null)
                return NotFound();

            return View(camera);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Update(Camera camera)
        {
            if (!ModelState.IsValid)
            {
                return View(camera);
            }

            await _cameraServices.UpdateAsync(camera);
            return RedirectToAction("Index");
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var camera = await _cameraServices.GetByIdAsync(id);
            if (camera != null)
            {
                await _cameraServices.DeleteAsync(camera);
            }

            return RedirectToAction("Index");
        }
    }
}
