namespace buildxact_supplies.Models
{
    public class BuildingSupply
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Price:C2}";
        }
    }
}
