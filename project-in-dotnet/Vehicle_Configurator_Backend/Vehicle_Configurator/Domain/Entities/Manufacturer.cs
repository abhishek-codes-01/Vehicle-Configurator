using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("manufacturer")]
    public class Manufacturer
    {
        [Key]
        [Column("mfg_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MfgId { get; set; }

        [Column("mfg_name")]
        public string MfgName { get; set; }

        public ICollection<Model> Models { get; set; }
        public ICollection<SgMfgMaster> SgMfgMasters { get; set; }
    }
}
