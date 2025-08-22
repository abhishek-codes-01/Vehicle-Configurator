namespace Vehicle_Configurator.Domain.Entities
{
    public class InvoiceEmailRequest
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Tax { get; set; }
        public string Segment { get; set; }
        public string Manufacturer { get; set; }
        public string Email { get; set; }
        public string Model { get; set; }
        //public string Email { get; set; }
    }
}
