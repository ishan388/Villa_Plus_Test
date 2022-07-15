using Villa_Plus_Test;

string lineSep = "---------------------------------------------------------------------------------------";
string header = $"|{" Name ",-10}|{" Quantity ",10}|{" Price ",10}|{" Final Price ",15}|{" Discount Type ",-30}|";
string distype = String.Empty;

List<Items> allItems = Items.GetItemsData();
List<Cart> cart = new List<Cart>();
cart.Add(new Cart(5, allItems[0]));
cart.Add(new Cart(2, allItems[1]));
cart.Add(new Cart(5, allItems[2]));
cart.Add(new Cart(2, allItems[3]));
cart.Add(new Cart(2, allItems[4]));

double total = 0, finalPrice = 0;
Console.WriteLine(lineSep);
Console.WriteLine(header);
Console.WriteLine(lineSep);
foreach (var c in cart)
{
    finalPrice = c.FinalPrice;
    distype = String.Format("{0} of ${1}", c.ItemDiscount.DiscountType, c.DiscountedPrice);
    var line = $"|{ c.Item.Name,-10}|{c.Qty,10}|{c.Item.Price,10}|{finalPrice,15}|{distype,30}|";
    Console.WriteLine(line);
    total += finalPrice;
}
Console.WriteLine(lineSep);
Console.WriteLine("Total = " + total);
