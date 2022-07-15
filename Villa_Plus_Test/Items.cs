namespace Villa_Plus_Test
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Items(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public static List<Items> GetItemsData()
        {
            List<Items> items = new List<Items>();
            items.Add(new Items(1, "Banana", 20));
            items.Add(new Items(2, "Apples", 100));
            items.Add(new Items(3, "Cherry", 50));
            items.Add(new Items(4, "Oranges", 150));
            items.Add(new Items(5, "Kiwi", 100));
            return items;
        }
    }


}
