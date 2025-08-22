using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("component")]
    public class Component
    {
        [Key]
        [Column("comp_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompId { get; set; }

        [Column("comp_name")]
        public string CompName { get; set; }

        public ICollection<VehicleDetail> VehicleDetails { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public ICollection<AlternateComponentMaster> DefaultComponents { get; set; }
        public ICollection<AlternateComponentMaster> AltComponents { get; set; }
    }
}
