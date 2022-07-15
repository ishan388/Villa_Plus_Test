namespace Villa_Plus_Test
{
    public class ItemDiscounts
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DiscountTypes DiscountType { get; set; } = DiscountTypes.None;
        public int DiscountQty { get; set; }
        public double DiscountPrice { get; set; } = 0;

        public ItemDiscounts(int id, int itemId, int qty, double price, DiscountTypes discountType = DiscountTypes.None)
        {
            Id = id;
            ItemId = itemId;
            DiscountQty = qty;
            DiscountPrice = price;
            DiscountType = discountType;
        }

        public static List<ItemDiscounts> GetDiscountsData()
        {
            List<ItemDiscounts> discounts = new List<ItemDiscounts>();
            discounts.Add(new ItemDiscounts(1, 1, 3, 0, DiscountTypes.BOGO));
            discounts.Add(new ItemDiscounts(2, 2, 2, 10, DiscountTypes.FlatPercent));
            discounts.Add(new ItemDiscounts(3, 3, 3, 120, DiscountTypes.FlatPriceDiscount));
            discounts.Add(new ItemDiscounts(4, 4, 1, 0, DiscountTypes.BOGO));
            discounts.Add(new ItemDiscounts(5, 5, 1, 0));
            return discounts;
        }

    }

}
