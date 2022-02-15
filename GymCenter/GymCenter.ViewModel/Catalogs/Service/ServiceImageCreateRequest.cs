using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.ViewModel.Catalogs.Service
{
    public class ServiceImageCreateRequest
    {
        public IFormFile ImageFile { get; set; }

    }
}
