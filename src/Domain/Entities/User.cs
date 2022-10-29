namespace Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

        public override string ToString()
        {
            return @$"{Name.Trim()},{Email.Trim()},{Phone.Trim().Replace(" ", "")},{Address.Trim()},{UserType.Trim()},{Money.ToString().Replace(",", ".")}";
        }
    }
}