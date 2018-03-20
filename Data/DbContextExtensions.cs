using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
  public static class DbContextExtensions
  {
    public static RoleManager<AppRole> RoleManager { get; set; }
    public static UserManager<AppUser> UserManager { get; set; }

    public static void EnsureSeeded(this EcommerceContext context)
    {
      AddRoles(context);
      AddUsers(context);
      AddColoursFeaturesAndStorage(context);
      AddOperatingSystemsAndBrands(context);
      AddProducts(context);
    }

    private static void AddRoles(EcommerceContext context)
    {
      if (RoleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
      {
        RoleManager.CreateAsync(new AppRole("Admin")).GetAwaiter().GetResult();
      }

      if (RoleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult() == false)
      {
        RoleManager.CreateAsync(new AppRole("Customer")).GetAwaiter().GetResult();
      }
    }

    private static void AddUsers(EcommerceContext context)
    {
      if (UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult() == null)
      {
        var user = new AppUser
        {
          FirstName = "Stu",
          LastName = "Ratcliffe",
          UserName = "stu@ratcliffe.io",
          Email = "stu@ratcliffe.io",
          EmailConfirmed = true,
          LockoutEnabled = false
        };

        UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
      }

      var admin = UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult();

      if (UserManager.IsInRoleAsync(admin, "Admin").GetAwaiter().GetResult() == false)
      {
        UserManager.AddToRoleAsync(admin, "Admin");
      }
    }

    private static void AddColoursFeaturesAndStorage(EcommerceContext context)
    {
      if (context.Colours.Any() == false)
      {
        var colours = new List<string>() { "Black", "White", "Gold", "Silver", "Grey", "Spacegrey", "Red", "Pink" };

        colours.ForEach(c => context.Add(new Colour
        {
          Name = c
        }));

        context.SaveChanges();
      }

      if (context.Features.Any() == false)
      {
        var features = new List<string>() { "3G", "4G", "Bluetooth", "WiFi", "Fast charge", "GPS", "NFC" };

        features.ForEach(f => context.Add(new Feature
        {
          Name = f
        }));

        context.SaveChanges();
      }

      if (context.Storage.Any() == false)
      {
        var storage = new List<int>() { 4, 8, 16, 32, 64, 128, 256 };

        storage.ForEach(s => context.Storage.Add(new Storage
        {
          Capacity = s
        }));

        context.SaveChanges();
      }
    }

    private static void AddOperatingSystemsAndBrands(EcommerceContext context)
    {
      if (context.OS.Any() == false)
      {
        var os = new List<string>() { "Android", "iOS", "Windows" };

        os.ForEach(o => context.OS.Add(new OS
        {
          Name = o
        }));

        context.SaveChanges();
      }

      if (context.Brands.Any() == false)
      {
        var brands = new List<string>() { "Acme", "Globex", "Soylent", "Initech", "Umbrella" };

        brands.ForEach(b => context.Brands.Add(new Brand
        {
          Name = b
        }));

        context.SaveChanges();
      }
    }

    private static void AddProducts(EcommerceContext context)
    {
      if (context.Products.Any() == false)
      {
        var products = new List<Product>()
        {
          new Product
          {
            Name = "Acme TNT 4",
            Slug = "acme-tnt-4",
            Thumbnail = "/assets/images/thumbnail.jpeg",
            ShortDescription = "Acme TNT 4 Android smartphone with true edge to edge display",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
            ScreenSize = 5M,
            TalkTime = 8M,
            StandbyTime = 36M,
            Brand = context.Brands.Single(b => b.Name == "Acme"),
            OS = context.OS.Single(os => os.Name == "Android"),
            Images = new List<Image>
            {
              new Image { Url = "/assets/images/gallery1.jpeg" },
              new Image { Url = "/assets/images/gallery2.jpeg" },
              new Image { Url = "/assets/images/gallery3.jpeg" },
              new Image { Url = "/assets/images/gallery4.jpeg" },
              new Image { Url = "/assets/images/gallery5.jpeg" },
              new Image { Url = "/assets/images/gallery6.jpeg" }
            },
            ProductFeatures = new List<ProductFeature>
            {
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "3G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Bluetooth")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "WiFi")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "GPS")
              }
            },
            ProductVariants = new List<ProductVariant>
            {
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 299M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 349M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Gold"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 319M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Gold"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 369M
              }
            }
          },
          new Product
          {
            Name = "Globex Scorpio",
            Slug = "globex-scorpio",
            Thumbnail = "/assets/images/thumbnail.jpeg",
            ShortDescription = "Globex Scorpio Windows smartphone with true edge to edge display",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
            ScreenSize = 7M,
            TalkTime = 6M,
            StandbyTime = 30M,
            Brand = context.Brands.Single(b => b.Name == "Globex"),
            OS = context.OS.Single(os => os.Name == "Windows"),
            Images = new List<Image>
            {
              new Image { Url = "/assets/images/gallery1.jpeg" },
              new Image { Url = "/assets/images/gallery2.jpeg" },
              new Image { Url = "/assets/images/gallery3.jpeg" },
              new Image { Url = "/assets/images/gallery4.jpeg" },
              new Image { Url = "/assets/images/gallery5.jpeg" },
              new Image { Url = "/assets/images/gallery6.jpeg" }
            },
            ProductFeatures = new List<ProductFeature>
            {
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "3G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Bluetooth")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "WiFi")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "GPS")
              }
            },
            ProductVariants = new List<ProductVariant>
            {
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "White"),
                Storage = context.Storage.Single(s => s.Capacity == 8),
                Price = 149M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "White"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 169M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 8),
                Price = 159M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 179M
              }
            }
          },
          new Product
          {
            Name = "Soylent MegaFone",
            Slug = "soylent-megafone",
            Thumbnail = "/assets/images/thumbnail.jpeg",
            ShortDescription = "Soylent MegaFone budget Android smartphone with true edge to edge display",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
            ScreenSize = 5M,
            TalkTime = 10M,
            StandbyTime = 48M,
            Brand = context.Brands.Single(b => b.Name == "Soylent"),
            OS = context.OS.Single(os => os.Name == "Android"),
            Images = new List<Image>
            {
              new Image { Url = "/assets/images/gallery1.jpeg" },
              new Image { Url = "/assets/images/gallery2.jpeg" },
              new Image { Url = "/assets/images/gallery3.jpeg" },
              new Image { Url = "/assets/images/gallery4.jpeg" },
              new Image { Url = "/assets/images/gallery5.jpeg" },
              new Image { Url = "/assets/images/gallery6.jpeg" }
            },
            ProductFeatures = new List<ProductFeature>
            {
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "3G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Bluetooth")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "WiFi")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "GPS")
              }
            },
            ProductVariants = new List<ProductVariant>
            {
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 4),
                Price = 99M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 8),
                Price = 119M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 139M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 4),
                Price = 99M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 8),
                Price = 119M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 139M
              }
            }
          },
          new Product
          {
            Name = "Initech Silicon 5",
            Slug = "initech-silicon-5",
            Thumbnail = "/assets/images/thumbnail.jpeg",
            ShortDescription = "Initech Silicon 5 premium iOS smartphone with true edge to edge display",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
            ScreenSize = 4.7M,
            TalkTime = 8M,
            StandbyTime = 36M,
            Brand = context.Brands.Single(b => b.Name == "Initech"),
            OS = context.OS.Single(os => os.Name == "iOS"),
            Images = new List<Image>
            {
              new Image { Url = "/assets/images/gallery1.jpeg" },
              new Image { Url = "/assets/images/gallery2.jpeg" },
              new Image { Url = "/assets/images/gallery3.jpeg" },
              new Image { Url = "/assets/images/gallery4.jpeg" },
              new Image { Url = "/assets/images/gallery5.jpeg" },
              new Image { Url = "/assets/images/gallery6.jpeg" }
            },
            ProductFeatures = new List<ProductFeature>
            {
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "3G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "4G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Bluetooth")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "WiFi")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "GPS")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Fast charge")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "NFC")
              }
            },
            ProductVariants = new List<ProductVariant>
            {
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 128),
                Price = 799M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 256),
                Price = 899M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 128),
                Price = 799M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 256),
                Price = 899M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 128),
                Price = 799M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 256),
                Price = 899M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 799M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 128),
                Price = 899M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 256),
                Price = 999M
              }
            }
          },
          new Product
          {
            Name = "Umbrella T3",
            Slug = "umbrella-t3",
            Thumbnail = "/assets/images/thumbnail.jpeg",
            ShortDescription = "Umbrella T3 premium Android smartphone with true edge to edge display",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
            ScreenSize = 5.5M,
            TalkTime = 8M,
            StandbyTime = 36M,
            Brand = context.Brands.Single(b => b.Name == "Umbrella"),
            OS = context.OS.Single(os => os.Name == "Android"),
            Images = new List<Image>
            {
              new Image { Url = "/assets/images/gallery1.jpeg" },
              new Image { Url = "/assets/images/gallery2.jpeg" },
              new Image { Url = "/assets/images/gallery3.jpeg" },
              new Image { Url = "/assets/images/gallery4.jpeg" },
              new Image { Url = "/assets/images/gallery5.jpeg" },
              new Image { Url = "/assets/images/gallery6.jpeg" }
            },
            ProductFeatures = new List<ProductFeature>
            {
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "3G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "4G")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Bluetooth")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "WiFi")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "GPS")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "Fast charge")
              },
              new ProductFeature
              {
                Feature = context.Features.Single(f => f.Name == "NFC")
              }
            },
            ProductVariants = new List<ProductVariant>
            {
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Black"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Silver"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Grey"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Spacegrey"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Red"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Red"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Red"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Pink"),
                Storage = context.Storage.Single(s => s.Capacity == 16),
                Price = 499M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Pink"),
                Storage = context.Storage.Single(s => s.Capacity == 32),
                Price = 599M
              },
              new ProductVariant
              {
                Colour = context.Colours.Single(c => c.Name == "Pink"),
                Storage = context.Storage.Single(s => s.Capacity == 64),
                Price = 699M
              }
            }
          }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
      }
    }
  }
}