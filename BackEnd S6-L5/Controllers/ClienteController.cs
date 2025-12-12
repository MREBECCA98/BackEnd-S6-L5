using BackEnd_S6_L5.Models.Entities;
using BackEnd_S6_L5.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_S6_L5.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clienti = await _clienteServices.GetAllAsync();
            return View(clienti);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Index(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var clienti = await _clienteServices.GetAllAsync();
                return View(clienti);
            }

            cliente.IdCliente = Guid.NewGuid();
            await _clienteServices.CreateAsync(cliente);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cliente = await _clienteServices.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            await _clienteServices.UpdateAsync(cliente);
            return RedirectToAction("Index");
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteServices.GetByIdAsync(id);
            if (cliente != null)
            {
                await _clienteServices.DeleteAsync(cliente);
            }

            return RedirectToAction("Index");
        }
    }
}
