class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car("Toyota", 1995, 150000),
            new Car("Honda", 2000, 180000),
            new Car("Ford", 1998, 220000),
            new Car("Toyota", 2005, 200000),
            new Car("Honda", 1992, 120000),
            new Car("Ford", 2003, 250000)
        };

        List<Truck> trucks = new List<Truck>
        {
            new Truck("Volvo", 2010, 300000, "ABC Company"),
            new Truck("Mercedes", 2015, 350000, "XYZ Company"),
            new Truck("Ford", 2018, 400000, "DEF Company"),
            new Truck("Toyota", 2008, 280000, "GHI Company")
        };

        // Danh sách các xe có giá trong khoảng 100.000 đến 250.000 và năm sản xuất > 1990
        var filteredCars1 = cars.Where(car => car.Price >= 100000 && car.Price <= 250000);

        // Danh sách các xe có năm sản xuất > 1990
        var filteredCars2 = cars.Where(car => car.Year > 1990);

        // Gom các xe theo hãng sản xuất và tính tổng giá trị theo nhóm
        var groupedCars = filteredCars1.GroupBy(car => car.Manufacturer)
                                      .Select(group => new
                                      {
                                          Manufacturer = group.Key,
                                          TotalPrice = group.Sum(car => car.Price)
                                      });

        // Hiển thị kết quả
        Console.WriteLine("Cars with price between 100,000 and 250,000:");
        foreach (var car in filteredCars1)
        {
            Console.WriteLine($"{car.Manufacturer} - {car.Price}");
        }

        Console.WriteLine("\nCars with manufactured after 1990:");
        foreach (var car in filteredCars2)
        {
            Console.WriteLine($"{car.Manufacturer} - {car.Year}");
        }

        Console.WriteLine("\nTotal price of cars grouped by manufacturer:");
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"{group.Manufacturer}: {group.TotalPrice}");
        }

        // Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
        var orderedTrucks = trucks.OrderByDescending(truck => truck.Year);
        Console.WriteLine("\nTrucks ordered by year of manufacture:");
        foreach (var truck in orderedTrucks)
        {
            Console.WriteLine($"{truck.Manufacturer} - {truck.Year} - {truck.Company}");
        }

        Console.ReadLine();
    }
}