using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("model")]
    public class Model
    {
        [Key]
        [Column("model_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }

        [Column("model_name")]
        public string ModelName { get; set; }

        [Column("min_qty")]
        public int MinQty { get; set; }

        [Column("img_path")]
        public string ImgPath { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("seg_id")]
        public int SegId { get; set; }

        [ForeignKey("SegId")]
        public Segment Segment { get; set; }

        [Column("mfg_id")]
        public int MfgId { get; set; }

        [ForeignKey("MfgId")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<VehicleDetail> VehicleDetails { get; set; }
        public ICollection<AlternateComponentMaster> AlternateComponents { get; set; }
        public ICollection<InvoiceHeader> Invoices { get; set; }
    }
}
