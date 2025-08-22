using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("alternate_component_master")]
    public class AlternateComponentMaster
    {
        [Key]
        [Column("alt_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AltId { get; set; }

        [Column("delta_price")]
        public double DeltaPrice { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        [Column("comp_id")]
        public int CompId { get; set; }
        public Component Component { get; set; }

        [Column("alt_comp_id")]
        public int AltCompId { get; set; }
        public Component AltComponent { get; set; }
    }
}
