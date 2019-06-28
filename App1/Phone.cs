namespace App1
{
    public class Phone
    {
        public Phone(string title, string company, int price)
        {
            Title = title;
            Company = company;
            Price = price;
        }

        public string Title { get; }
        public string Company { get; }
        public int Price { get; }
    }
}