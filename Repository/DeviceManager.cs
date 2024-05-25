using PhysioRental.Models;
using RentalPhysioDevices.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentalPhysioDevices.Repisitory
{
    public class DeviceManager
    {
        private readonly ApplicationDbContext _context;

        public DeviceManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDeviceAsync(DeviceModel deviceModel)
        {
            try
            {
                await _context.AddAsync(deviceModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<DeviceModel>> GetAllDevicesAsync()
        {
            try
            {
                return await _context.Devices.ToListAsync();
            }
            catch (Exception e)
            {
                return new List<DeviceModel>();
            }
        }

        public async Task<DeviceModel> GetDeviceAsync(int id)
        {
            try
            {
                return await _context.Devices.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateDeviceAsync(DeviceModel deviceModel)
        {
            try
            {
                _context.Devices.Update(deviceModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveDeviceAsync(int deviceId)
        {
            try
            {
                var device = await _context.Devices.FindAsync(deviceId);
                if (device == null)
                {
                    return false;
                }

                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                // Log error
                return false;
            }
        }

        public async Task<bool> RentDeviceAsync(int deviceId)
        {
            try
            {
                var device = await _context.Devices.FindAsync(deviceId);
                if (device == null)
                {
                    return false;
                }

                device.IsRented = true;
                device.IsAvailable = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ReturnDeviceAsync(int deviceId)
        {
            try
            {
                var device = await _context.Devices.FindAsync(deviceId);
                if (device == null)
                {
                    return false;
                }

                device.IsRented = false;
                device.IsAvailable = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
