namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playercreateinfo_item", Schema = "mangos")]
    public class PlayerCreateInfoItem
    {
 
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("itemid")] 
                public int Itemid { get; set; }
 
        [Column("amount")] 
                public byte Amount { get; set; }
    }
}
