using Delicious.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Delicious.infrastructure
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DeliciousFoodDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DeliciousFoodDbContext>>()))
            {
                if(context.Categories.Any()){
                   return; 
                }

                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName="Breakfast",
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                ProductName="Bacon,Egg & cheese",
                                UrlShortName="bacon-egg-cheese",
                                Price=30,
                                Describe="Bacon, Egg & Cheese Biscuit breakfast sandwich features a warm, buttermilk biscuit brushed with real butter, thick cut Applewood smoked bacon, a fluffy folded egg, and a slice of melty American cheese.There are 460 calories in a Bacon, Egg & Cheese Biscuit ",
                                Images="bacon-egg-cheese.PNG",
                                Sale=10
                            },
                            new Product
                            {
                                ProductName="Sausage,Egg & cheese",
                                UrlShortName="sausage-egg-cheese",
                                Price=30,
                                Describe="Sausage, Egg & Cheese  feature soft, warm griddle cakes—with the sweet taste of maple—that hold a fluffy folded egg, savory sausage, and melty American cheese.cakes have no artificial preservatives or flavors and no colors from artificial sources. There are 550 calories in a Sausage, Egg, and Cheese",
                                Images="sausage-egg-cheese.PNG",
                                Sale=5
                            }
                        }
                    },
                    new Category 
                    {
                        CategoryName="Burger",
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                ProductName="Big Burger",
                                UrlShortName="big-burger",
                                Price=50,
                                Describe="Mouthwatering perfection starts with two 100% pure beef patties and Big burger sauce sandwiched between a sesame seed bun. It's topped off with pickles, crisp shredded lettuce, finely chopped onion and American cheese for a 100% beef burger with a taste like no other.",
                                Images="big-burger.PNG",
                                Sale=0
                            },
                            new Product
                            {
                                ProductName="Cheese, Bacon Burger",
                                UrlShortName="cheese-bacon-burger",
                                Price=42,
                                Describe="Each Quarter Pounder® with Cheese Bacon burger features thick-cut applewood smoked bacon atop a 1/4 lb.* of 100% McDonald's fresh beef that's cooked when you order",
                                Images="cheese-bacon-burger.PNG",
                                Sale=0
                            }
                        }
                    },
                    new Category 
                    {
                        CategoryName="Drink",
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                ProductName="Coca Cola",
                                UrlShortName="coca-cola",
                                Price=3,
                                Describe="The most favorite drink in the world,Coke is very cold and tasty, which will break your thirsty down and make you fresh every time you have it.",
                                Images="coca-cola.PNG",
                                Sale=0
                            },
                            new Product
                            {
                                ProductName="Iced latte",
                                UrlShortName="iced-latte",
                                Price=10,
                                Describe="Cool down with a cold Iced Latte, made from Rainforest Alliance Certified™ espresso. Customize an Iced Latte that’s made fresh just for you with cold whole milk, mixed with your choice of flavor at certain location",
                                Images="iced-latte.PNG",
                                Sale=0
                            }
                        }
                    },
                    new Category
                    {
                        CategoryName="Snack",
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                ProductName="Chips",
                                UrlShortName="chips",
                                Price=12,
                                Describe="fried Potato is very crispy and yummy.",
                                Images="Chips.PNG"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}