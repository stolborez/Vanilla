using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("instance_reset", Schema="characters")]

    public partial class instance_reset
    {
 
        [Column("mapid")] 
		        public long mapid { get; set; }
 
        [Column("resettime")] 
		        public decimal resettime { get; set; }
    }
}
