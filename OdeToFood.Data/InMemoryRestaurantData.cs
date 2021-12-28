using OdeToFood.Core;
using System.Collections.Generic;
using static OdeToFood.Core.Restaurant;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Sabor Mais", Location = "Bloco 2", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Gisela's", Location = "Bloco 4", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from restaurant in restaurants
                   where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                   orderby restaurant.Name
                   select restaurant;
        }

        public Restaurant Add(Restaurant restaurant)
        { 
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id); 
        }

        public Restaurant Update(Restaurant restaurant)
        {
            Restaurant rr = restaurants.SingleOrDefault(r => r.Id == restaurant.Id);

            if (rr != null)
            {
                rr.Name = restaurant.Name;
                rr.Location = restaurant.Location;
                rr.Cuisine = restaurant.Cuisine;
            }

            return rr;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(Restaurant restaurant)
        {
            Restaurant rr = restaurants.FirstOrDefault(r => r.Id == restaurant.Id);

            if (rr != null)
            {
                restaurants.Remove(rr);
            }

            return rr;
        }
    }
}
