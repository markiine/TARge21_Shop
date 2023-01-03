using System;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Spaceship> Create(CarDto dto);
        Task<Spaceship> Update(CarDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> GetAsync(Guid id);
    }
}

