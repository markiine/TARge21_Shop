﻿using TARge21Shop.Core.Dto;

namespace TARge21Shop.Models.RealEstate
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public double Size { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }
        public int RoomCount { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

        // only in database
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
