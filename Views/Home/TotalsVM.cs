namespace schedule_mvc.Views.Home
{
    public class TotalsVM
    {
        public int? TotalClients { get; set; }
        public int? TotalDoctors { get; set; }

        //public IEnumerable<CartItem> CartItems { get; set; }
        //public decimal? TotalPrice { get; set; }
        //public int? TotalCount { get; set; }

        //public double Total => CartItems.Sum(m => m.Amount * m.Product.ListPrice);
        //public double Total => CartItems.Sum(m => m.GetTotal());
        //public int Amount => CartItems.Sum(item => item.Amount);

    }
}
