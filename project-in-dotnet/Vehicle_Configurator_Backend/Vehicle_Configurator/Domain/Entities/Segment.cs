using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("segment")]
    public class Segment
    {
        [Key]
        [Column("seg_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SegId { get; set; }

        [Column("seg_name")]
        public string SegName { get; set; }

        public ICollection<Model> Models { get; set; }
        public ICollection<SgMfgMaster> SgMfgMasters { get; set; }
    }
}
