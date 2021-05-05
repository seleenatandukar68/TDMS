using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDMS.Data;
using TDMS.Data.Core;

using TDMS.Model;

namespace TDMS.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TeleDirectoryController : ControllerBase
    {
        //private TeleDirectoryRepo teleDirectoryRepo { get; set; }
        private IRepository<TeleDirectory> repoTeledirectory;
        public TeleDirectoryController(IRepository<TeleDirectory> _repo)
        {
            this.repoTeledirectory = _repo;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeleDirectory>>> Get()
        {
            return await repoTeledirectory.GetAll();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TeleDirectory>>> GetById(int id)
        {
            return await repoTeledirectory.GetAllByCondition(x => x.Id == id);

        }
        [HttpPost]
        public async Task<ActionResult<TeleDirectory>> Post(TeleDirectory teleDir)
        {
            return Ok(await repoTeledirectory.Add(teleDir));

        }

        [HttpPut]
        public async Task<ActionResult<TeleDirectory>> Update(TeleDirectory teleDir)
        {
            return Ok(await repoTeledirectory.Update(teleDir));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TeleDirectory>> Delete(int id)
        {
            return Ok(await repoTeledirectory.Delete(id));

        }


    }
}
