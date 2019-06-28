namespace App1
{
    public class Phone
    {
        public Phone(string title, string company, int price, string imagePath = "http://www.apankov.com/site/images/f1/images/Android/android_icon_256.png")
        {
            Title = title;
            Company = company;
            Price = price;
            ImagePath = imagePath;
        }

        public string Title { get; }
        public string Company { get; }
        public int Price { get; }
        public string ImagePath { get; }
    }
}