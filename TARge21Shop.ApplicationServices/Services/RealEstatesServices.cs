using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class RealEstatesServices
    {
        private readonly TARge21ShopContext _context;
        public RealEstatesServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }

    }
}
