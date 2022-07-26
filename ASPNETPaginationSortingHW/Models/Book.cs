namespace ASPNETPaginationSortingHW.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private decimal _price;
        public decimal Price
        {
            get
            {
                return Math.Round(_price, 2);
            }
            set { _price = value; }
        }
        public int Pages { get; set; }
    }
}
