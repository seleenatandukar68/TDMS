﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDMS.Data;
using TDMS.Data.Core;

using TDMS.Model;

namespace TDMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeleDirectoryController : ControllerBase
    {
        //private TeleDirectoryRepo teleDirectoryRepo { get; set; }
        private IRepository<TeleDirectory> repoTeledirectory; 
        public TeleDirectoryController (IRepository<TeleDirectory> _repo)
        {
            this.repoTeledirectory = _repo;
            
        }
          [HttpGet]
        public async Task<ActionResult<IEnumerable<TeleDirectory>>> Get()
        {
            return await repoTeledirectory.GetAll();
            
        }
       
    }
}
