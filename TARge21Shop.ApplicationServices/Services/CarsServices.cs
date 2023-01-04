using System;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
	public class CarsServices : ICarsServices
	{
        private readonly TARge21ShopContext _context;

        public CarsServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car()
            {
                car.Id = Guid.NewGuid();
                car.Brand = dto.Brand;
                car.Type = dto.Type;
                car.Model = dto.Model;
                car.Color = dto.Color;
                car.Price = dto.Price;
                car.HorsePower = dto.HorsePower;
                car.Weight = dto.Weight;
                car.BuiltDate = dto.BuiltDate;
                car.LastMaintenance = dto.LastMaintenance;
                car.CreatedAt = DateTime.Now;
                car.ModifiedAt = DateTime.Now;
        }

        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

            return car;
        }

    public async Task<Car> Update(CarDto dto)
    {
        var domain = new Car()
        {
            Id = dto.Id,
            Brand = dto.Brand,
            Type = dto.Type,
            Model = dto.Model,
            Color = dto.Color,
            Price = dto.Price,
            HorsePower = dto.HorsePower,
            Weight = dto.Weight,
            BuiltDate = dto.BuiltDate,
            LastMaintenance = dto.LastMaintenance,
            CreatedAt = dto.CreatedAt,
            ModifiedAt = DateTime.Now,
        };

        _context.Cars.Update(domain);
        await _context.SaveChangesAsync();

        return domain;
    }

    //public async Task<Car> GetUpdate(Guid id)
    //{
    //    var result = await _context.Cars
    //        .FirstOrDefaultAsync(x => x.Id == id);

    //    return result;
    //}

    public async Task<Car> Delete(Guid id)
    {
        var carId = await _context.Cars
            .FirstOrDefaultAsync(x => x.Id == id);

        _context.Cars.Remove(carId);
        await _context.SaveChangesAsync();

        return carId;
    }

    public async Task<Car> GetAsync(Guid id)
    {
        var result = await _context.Cars
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

}


