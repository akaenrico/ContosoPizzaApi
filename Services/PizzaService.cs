using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    // Create a list that accepts the Pizza Model and give it a name of "Pizza"
    static List<Pizza> Pizzas { get; }
    // Sets the next possible ID
    static int nextId = 3;
    // Constructor initializing the pizza list with two Pizza's object
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", isGlutenFree = false },
            new Pizza { Id = 2, Name = "Escarola", isGlutenFree = true },
        };
    }

    // List All
    public static List<Pizza> GetAll() => Pizzas;

    // Get By ID
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    // Create Pizza
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    // Update Pizza
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;
        
        Pizzas[index] = pizza;
    }

    // Delete Pizza
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }
}