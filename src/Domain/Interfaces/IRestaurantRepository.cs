using Domain.Entities;

namespace Domain.Interfaces;

public interface IRestaurantRepository
{
    IEnumerable<Restaurant> GetAll();
    Restaurant? GetById(Guid id);
    void Update(Restaurant restaurant);
}