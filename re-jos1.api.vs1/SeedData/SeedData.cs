using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using re_jos1.api.vs1.Models;
using System;
using System.Linq;

namespace re_jos1.api.vs1.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext
                (serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                if (context.Pages.Any())
                {
                    return;
                }

                context.Pages.AddRange(
                    new Page
                    {
                        Name = "Home",
                        Slug = "home",
                        Content = "Hemsida"
                    },
                    new Page
                    {
                        Name = "About",
                        Slug = "about",
                        Content = "Om"
                    },
                    new Page
                    {
                        Name = "Service",
                        Slug = "service",
                        Content = "Service"
                    },
                    new Page
                    {
                        Name = "Contact",
                        Slug = "contact",
                        Content = "Kontakt"
                    }
                    );

                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Jos",
                        Slug = "jos"
                    },
                    new Category
                    {
                        Name = "Smoothie",
                        Slug = "smoothie"
                    }
                );

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Äpplejos",
                        CategoryId = 1,
                        Description = "Jos från räddade äpplen.",
                        Image = "apple.jpg",
                        Price = 25
                    },
                    new Product
                    {
                        Name = "Gurkjos",
                        CategoryId = 1,
                        Description = "Jos från räddade kiwis.",
                        Image = "kiwi.jpg",
                        Price = 25
                    },
                    new Product
                    {
                        Name = "Banan-Avokado-Smoothie",
                        CategoryId = 2,
                        Description = "Smoothie av räddade bananer och avokados.",
                        Image = "avocado.jpg",
                        Price = 25
                    },
                    new Product
                    {
                        Name = "Apelsin-Banan-Smoothie",
                        CategoryId = 2,
                        Description = "Smoothie av räddade apelsiner och bananer.",
                        Image = "orange.jpg",
                        Price = 25
                    }
                );

                context.SaveChanges();
            };
        }
    }
}
