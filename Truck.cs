public class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string manufacturer, int year, decimal price, string company)
    {
        Manufacturer = manufacturer;
        Year = year;
        Price = price;
        Company = company;
    }
}