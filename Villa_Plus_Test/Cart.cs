using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa_Plus_Test
{
    public class Cart
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public Items Item { get; set; }

        public Cart(int qty, Items item)
        {
            this.Qty = qty;
            this.Item = item;
        }

        public double FinalQty
        {
            get { return UpdateQty(); }
        }
        public double FinalPrice
        {
            get { return CalculateFinalPrice(this); }
        }
        public ItemDiscounts ItemDiscount
        {
            get { return ItemDiscounts.GetDiscountsData().Where(x => x.ItemId == Item.Id).SingleOrDefault(); }
        }
        public double DiscountedPrice
        {
            get { return (this.FinalQty * this.Item.Price) - FinalPrice; }
        }
        public int UpdateQty()
        {
            if (ItemDiscount.DiscountType == DiscountTypes.BOGO)
            {
                if (ItemDiscount.DiscountQty <= 1)
                    return this.CalculateFinalQty(2);
                else
                    return this.CalculateFinalQty(ItemDiscount.DiscountQty);
            }
            return this.Qty;
        }
        int CalculateFinalQty(int discountQty)
        {
            return (this.Qty % discountQty) + (this.Qty / discountQty);
        }
        double CalculateFinalPrice(Cart cart)
        {
            ICalculateDiscount? calculate = null;
            double price = this.Qty * cart.Item.Price; ;

            if (ItemDiscount.DiscountType == DiscountTypes.FlatPriceDiscount)
                calculate = new DiscountFlatPrice();
            else if (ItemDiscount.DiscountType == DiscountTypes.FlatPercent)
                calculate = new DiscountFlatPercent();
            else if (ItemDiscount.DiscountType == DiscountTypes.BOGO)
                price = this.FinalQty * cart.Item.Price;

            if (calculate != null)
                price = calculate.CalculateDiscount(cart);
            return price;
        }
    }

}
