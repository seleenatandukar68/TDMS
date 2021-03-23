using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDMS.Data.Core;
using TDMS.Model;

namespace TDMS.Data.Repositories
{
    public class TeleDirectoryRepo: CoreRepository<TeleDirectory, MyDbContext>
    {
        public TeleDirectoryRepo(MyDbContext context) : base(context)
        {
        }
            public async Task<ActionResult<IEnumerable<TeleDirectory>>> Get()
            {
                return await GetAll();
            }

        
    }
}
