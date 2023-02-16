using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly IRealEstatesServices _realEstatesServices;

        public RealEstatesController
            (
                TARge21ShopContext context, 
                IRealEstatesServices realEstatesServices

            )
        {
            _context = context; 
            _realEstatesServices = realEstatesServices;
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

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();
            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Phone = vm.Phone,
                Fax = vm.Fax,
                Size = vm.Size,
                Floor = vm.Floor,
                Price = vm.Price,
                RoomCount = vm.RoomCount,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt,
                Files = vm.Files,
                FileToApiDtos = vm.FileToApiViewModels.Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    RealEstateId = x.RealEstateId
                }).ToArray()

            };

            var result = await _realEstatesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();

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
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Phone = vm.Phone,
                Fax = vm.Fax,
                Size = vm.Size,
                Floor = vm.Floor,
                Price = vm.Price,
                RoomCount = vm.RoomCount,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt,
                Files = vm.Files,
                
                FileToApiDtos = vm.FileToApiViewModels.Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    RealEstateId = x.RealEstateId
                }).ToArray()
            };

            var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstate.Id;
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
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstate.Id;
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
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstateId = await _realEstatesServices.Delete(id);
            if (realEstateId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> RemoveImage(ImageViewModel file)
        //{
        //    var dto = new FileToDatabaseDto()
        //    {
        //        Id = file.ImageId
        //    };

        //    var image = await _filesServices.RemoveImage(dto);

        //    if (image == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
