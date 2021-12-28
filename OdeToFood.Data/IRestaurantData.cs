using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurantById(int id);
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(Restaurant restaurant);
        int Commit();
    }


}
