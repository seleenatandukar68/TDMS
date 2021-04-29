using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TDMS.Data;

namespace TDMS.Model
{
    public class TeleDirectory : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Address { get; set; }
        public Boolean Gender { get; set; } // 0 male 1 female 

        [Required]
        [StringLength(15)]
        public string PhoneNo { get; set; }

    }
}
