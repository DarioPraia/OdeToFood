using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this.context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);

            return restaurant;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(Restaurant restaurant)
        {
            Restaurant r = GetRestaurantById(restaurant.Id);

            if (r != null)
            {
                context.Restaurants.Remove(restaurant);
            }

            return r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from restaurant in context.Restaurants
                        where restaurant.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby restaurant.Name
                        select restaurant;

            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var rr = context.Restaurants.Attach(restaurant);
            rr.State = EntityState.Modified;
            return restaurant;
        }
    }
}
