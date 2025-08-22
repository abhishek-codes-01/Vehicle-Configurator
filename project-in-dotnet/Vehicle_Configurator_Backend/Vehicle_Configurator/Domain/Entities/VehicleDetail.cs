using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Vehicle_Configurator.Domain.Enums;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("vehicle_detail")]
    public class VehicleDetail
    {
        [Key]
        [Column("config_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigId { get; set; }

        [Column("comp_id")]
        public int CompId { get; set; }

        [ForeignKey("CompId")]
        public Component Component { get; set; }

        [Column("comp_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ComponentType CompType { get; set; }

        [Column("is_config")]
        public string IsConfig { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public Model Model { get; set; }
    }
}
