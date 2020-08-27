namespace re_jos1.api.vs1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Cart { get; set; }
        public decimal Total { get; set; }
    }
}
