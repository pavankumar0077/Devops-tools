namespace InMemoryCrudApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // or consider using the 'required' modifier (C# 11)
        public decimal Price { get; set; }
    }
}
