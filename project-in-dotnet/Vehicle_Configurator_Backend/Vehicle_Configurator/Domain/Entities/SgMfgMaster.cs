using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("sg_mfg_master")]
    public class SgMfgMaster
    {
        [Key]
        [Column("sgmf_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SgmfId { get; set; }

        [Column("seg_id")]
        public int SegId { get; set; }

        //public Segment Segment { get; set; }

        [Column("mfg_id")]
        public int MfgId { get; set; }

       // public Manufacturer Manufacturer { get; set; }
    }
}
