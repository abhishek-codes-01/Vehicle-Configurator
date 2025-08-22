using Microsoft.EntityFrameworkCore;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicle_Configurator.Domain.Enums;

// This is the converter you provided.
public class ComponentTypeConverter : ValueConverter<ComponentType, string>
{
    public ComponentTypeConverter() : base(
        v => v.ToString(),
        v => (ComponentType)Enum.Parse(typeof(ComponentType), v))
    {
    }
}