namespace AMM_Desktop_Client.Model
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public TypeOfSource Type { get; set; }
        public string Icon { get; set; }
    }
}
