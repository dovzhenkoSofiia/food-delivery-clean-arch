using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Repositories;

// === Dependency Injection (ручне збирання шарів) ===
IRestaurantRepository repository = new InMemoryRestaurantRepository();
var getRestaurants = new GetRestaurantsUseCase(repository);
var selectRestaurant = new SelectRestaurantUseCase(repository);

// === Імітація інтерфейсу (CLI) ===
Console.WriteLine("=== Сервіс доставки їжі ===");
var restaurants = getRestaurants.Execute().ToList();

for (int i = 0; i < restaurants.Count; i++)
{
    var r = restaurants[i];
    string mark = r.IsSelected ? "[*]" : "[ ]";
    Console.WriteLine($"{i + 1}. {mark} {r.Name} | {r.DeliveryTime} | Від {r.MinOrder} грн");
}

Console.Write("\nОберіть номер ресторану для виділення (або 0 для виходу): ");
if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= restaurants.Count)
{
    var selected = selectRestaurant.Execute(restaurants[choice - 1].Id);
    Console.WriteLine($"Ви обрали: {selected?.Name}. Тепер картка підсвічена!");
}