using Microsoft.AspNetCore.Mvc;
using PhysioRental.Models;
using RentalPhysioDevices.Repisitory;

namespace RentalPhysioDevices.Controllers
{
    public class DevicesController : Controller
    {
        private readonly DeviceManager _manager;
        public DevicesController(DeviceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var devices = await _manager.GetAllDevicesAsync();
            return View(devices);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DeviceModel device)
        {
            if (ModelState.IsValid)
            {
                await _manager.AddDeviceAsync(device);
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int deviceId)
        {
            var device = await _manager.GetDeviceAsync(deviceId);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeviceModel device)
        {
            if (ModelState.IsValid)
            {
                await _manager.UpdateDeviceAsync(device);
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int deviceId)
        {
            await _manager.RemoveDeviceAsync(deviceId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(int deviceId)
        {
            await _manager.RentDeviceAsync(deviceId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int rentalId)
        {
            await _manager.ReturnDeviceAsync(rentalId);
            return RedirectToAction(nameof(Index));
        }
    }
}
