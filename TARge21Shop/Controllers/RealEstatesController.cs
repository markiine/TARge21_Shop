﻿using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstates;

        public RealEstatesController
            (
                IRealEstatesServices realEstates
            )
        {
            _realEstates = realEstates;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var realEstate = await _realEstates.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateIndexViewModel();

            vm.Id = id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Phone = realEstate.Phone;
            vm.Fax = realEstate.Fax;
            vm.Size = realEstate.Size;
            vm.Floor = realEstate.Floor;
            vm.Price = realEstate.Price;
            vm.RoomCount = realEstate.RoomCount;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;

            return View();
        }
    }
}
