using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;
using TARge21Shop.Models.Spaceship;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly IRealEstatesServices _realEstates;

        public RealEstatesController
            (
                TARge21ShopContext context, 
                IRealEstatesServices realEstates

            )
        {
            _context = context; 
            _realEstates = realEstates;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    Size = x.Size,
                    Price = x.Price,
                   
                });
            return View(result);
        }

        /*[HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();
            return View("CreateUpdate", realEstate);
        }*/



        /*[HttpGet]
        public async Task<IActionResult> Update(Guid id)
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
        }*/
    }
}
