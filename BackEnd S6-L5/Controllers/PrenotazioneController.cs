using BackEnd_S6_L5.Models.Entities;
using BackEnd_S6_L5.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_S6_L5.Controllers
{

    public class PrenotazioneController : Controller
    {
        private readonly ICameraServices _cameraServices;
        private readonly IClienteServices _clienteServices;
        private readonly IPrenotazioneServices _prenotazioneServices;

        public PrenotazioneController(ICameraServices cameraServices, IClienteServices clienteServices, IPrenotazioneServices prenotazioneServices)
        {
            _cameraServices = cameraServices;
            _clienteServices = clienteServices;
            _prenotazioneServices = prenotazioneServices;
        }
        public IActionResult Index()
        {
            ViewBag.Camere = _cameraServices.GetAllAsync().Result;
            ViewBag.Clienti = _clienteServices.GetAllAsync().Result;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Prenotazione prenotazione)
        {
            prenotazione.Cliente = await _clienteServices.GetByIdAsync(prenotazione.ClienteId);
            prenotazione.Camera = await _cameraServices.GetByIdAsync(prenotazione.CameraId);

            prenotazione.IdPrenotazione = Guid.NewGuid();

            await _prenotazioneServices.CreateAsync(prenotazione);

            return RedirectToAction("Index");

        }
    }
}