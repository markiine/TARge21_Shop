using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly TARge21ShopContext _context;
        public RealEstatesServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.City = dto.City;
            realEstate.Region = dto.Region;
            realEstate.PostalCode = dto.PostalCode;
            realEstate.Country = dto.Country;
            realEstate.Phone = dto.Phone;
            realEstate.Fax = dto.Fax;
            realEstate.Size = dto.Size;
            realEstate.Floor = dto.Floor;
            realEstate.Price = dto.Price;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.ModifiedAt = DateTime.Now;
            realEstate.CreatedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;

        }


        /*public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
                Crew = dto.Crew,
                Passengers = dto.Passengers,
                CargoWeight = dto.CargoWeight,
                FullTripsCount = dto.FullTripsCount,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                MaidenLaunch = dto.MaidenLaunch,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, domain);
            }

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    SpaceshipId = y.SpaceshipId,
                })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images); // et andmebaasist ka ära kustuks
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }*/

    }
}
