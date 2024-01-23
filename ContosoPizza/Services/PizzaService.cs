using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context = default!;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public IList<Pizza> GetPizzas()
        {
            if (_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log the error or rethrow the exception
                    throw;
                }


            }
        }

        public void AddPizzas(List<Pizza> pizzas)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.AddRange(pizzas);
                _context.SaveChanges();
            }
        }

        public void UpdatePizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();
            }
        }

        public void DeletePizza(int id)
        {
            if (_context.Pizzas != null)
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }
        }
    }
}
