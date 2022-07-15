using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa_Plus_Test
{
    public interface ICalculateDiscount
    {
        public double CalculateDiscount(Cart cart);
    }

    public class DiscountFlatPercent : ICalculateDiscount
    {
        public double CalculateDiscount(Cart cart)
        {
            cart.ItemDiscount.DiscountQty = cart.ItemDiscount.DiscountQty == 0 ? 1 : cart.ItemDiscount.DiscountQty;
            cart.ItemDiscount.DiscountPrice = cart.ItemDiscount.DiscountPrice > 100 ? 100 : cart.ItemDiscount.DiscountPrice;
            return (cart.Qty * cart.Item.Price) 
                - ((cart.Item.Price * cart.ItemDiscount.DiscountQty) * cart.ItemDiscount.DiscountPrice / 100);
        }
    }

    public class DiscountFlatPrice : ICalculateDiscount
    {
        public double CalculateDiscount(Cart cart)
        {
            double final = 0;
            if (cart.ItemDiscount.DiscountPrice > 0)
            {
                cart.ItemDiscount.DiscountQty = cart.ItemDiscount.DiscountQty == 0 ? 1 : cart.ItemDiscount.DiscountQty;

                if (cart.Qty <= cart.ItemDiscount.DiscountQty)
                    final = cart.Qty * cart.Item.Price;
                else
                {
                    final = ((cart.Qty / cart.ItemDiscount.DiscountQty) * cart.ItemDiscount.DiscountPrice);
                    if (cart.Qty > cart.ItemDiscount.DiscountQty && (cart.Qty % cart.ItemDiscount.DiscountQty > 0))
                        final += (cart.Qty % cart.ItemDiscount.DiscountQty * cart.Item.Price);
                }
            }

            return final;
        }
    }
}
