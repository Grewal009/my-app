using pizza.api.Entities;

namespace pizza.api.Repositories;

public class InMemoryPizzasRepository : IPizzasRepository
{
     List<Pizza> pizzaList = new(){
        new Pizza(){Id= 1,Name= "Heavy Heaven",Image= "https://www.peppes.no/bilder_webshop/0130.jpg",Ingredients="Pepperoni, garlic-spiced meatballs, marinated beef, red onion and oregano",Allergens= "Wheat, Gluten, Milk",RegularPrice= 100,LargePrice= 310,Vegetarian= false,GlutenFree= false},
        new Pizza(){Id= 2,Name= "Chicken Flyaway",Image= "https://www.peppes.no/bilder_webshop/0119.jpg",Ingredients= "Marinated chicken, corn, leek and red pepper",Allergens= "Wheat, Gluten, Milk",RegularPrice= 110,LargePrice= 298,Vegetarian= false,GlutenFree= false},
        new Pizza(){Id= 3,Name= "Oh My Garden!",Image= "https://www.peppes.no/bilder_webshop/0141.jpg",Ingredients= "Avocado, red onion, marinated aromatic mushrooms, olives, cherry tomatoes and kale mix. The cheese has been replaced with a tasty vegan aioli. Topped with freshly ground pepper and lime zest",Allergens= "Wheat, Gluten, Milk",RegularPrice= 115,LargePrice= 310,Vegetarian= true,GlutenFree= false},
        new Pizza(){Id= 4,Name= "Green Garden",Image= "https://www.peppes.no/bilder_webshop/0147.jpg",Ingredients=  "Avocado, red onion, marinated aromatic mushrooms, olives, cherry tomatoes, kale mix, fresh mozzarella and Peppe's cheese mixture. Topped with freshly ground pepper and lime zest",Allergens= "Wheat, Gluten, Milk",RegularPrice= 110,LargePrice= 310,Vegetarian= true,GlutenFree= false},
        new Pizza(){Id= 5,Name= "GLUTEN-FREE Chicken Flyaway",Image= "https://www.peppes.no/bilder_webshop/0319.jpg",Ingredients= "Marinated chicken, corn, leek and red pepper",Allergens= "Soya, Milk",RegularPrice= 115,LargePrice= 350,Vegetarian= false,GlutenFree= true},
    };
     
     // method to read all pizzas
    public IEnumerable<Pizza> GetAll()
    {
        return pizzaList;
    }

    //method to get pizza by id
    public Pizza? GetById(int id)
    {
        return pizzaList.Find(p => p.Id == id);
    }

    //method to create new pizza item
    public void Create(Pizza pizza)
    {
        pizza.Id = pizzaList.Max(p => p.Id) + 1;
        pizzaList.Add(pizza);
    }

    //method to update existing pizza item
    public void Update(Pizza updatedPizza)
    {
        var index  = pizzaList.FindIndex(p => p.Id == updatedPizza.Id);
        pizzaList[index] = updatedPizza;
    }
    
    //method to delete existing pizza item
    public void Delete(int id)
    {
        var index = pizzaList.FindIndex(p => p.Id == id);
        pizzaList.RemoveAt(index);
    }




}