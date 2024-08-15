using CafeteriaWebsite.Enums;
using CafeteriaWebsite.Models;
using CafeteriaWebsite.Repositories.Interfaces;
using CafeteriaWebsite.Repositories.MockRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebsite.Repositories
{
	public class MockFoodRepository : IFoodRepository
	{
		private static readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

		private List<FoodModel> _food = new List<FoodModel>()
		{
			new FoodModel
			{
				Id = 1,
				Name = "Pesto Caprese Toast",
				Description = "A fresh and flavorful combination of juicy tomatoes, creamy fresh cheese, and fragrant basil, drizzled with pesto oil. Perfect for a light, satisfying bite.",
				CategoryId = 1,
				ImageUrl = "/img/sandwichesToasts/1.jpeg",
				Price =5.50f,
				Tags = new List<int>{(int)FoodTag.Vegetarian }
			},
			new FoodModel
			{
				Id = 2,
				Name = "Eco Cherry Avocado Toast",
				Description = "Creamy avocado paired with sweet organic cherry tomatoes, topped with a crunchy mix of seeds and nuts for added texture and flavor.",
				CategoryId = 1,
				Price =5.50f,
				ImageUrl = "/img/sandwichesToasts/2.jpeg",
				Tags = new List<int>{(int)FoodTag.Vegan, (int)FoodTag.Recommended }
			},
			new FoodModel
			{
				Id = 3,
				Name = "Fika Style Avocado Toast",
				Description = "A wholesome toast featuring creamy avocado, peppery arugula, and a perfectly cooked organic egg, inspired by the Fika style.",
				CategoryId = 1,
				Price =6.75f,
				ImageUrl = "/img/sandwichesToasts/3.jpeg",
				Tags = new List<int>{(int)FoodTag.Vegetarian }
			},
			new FoodModel
			{
				Id = 4,
				Name = "Vegan Delight Toast",
				Description = "A delicious vegan option combining ripe tomatoes, fresh arugula, creamy avocado, and Vuna for a hearty and nutritious bite.",
				CategoryId = 1,
				Price =6.50f,
				ImageUrl = "/img/sandwichesToasts/4.jpeg",
				Tags = new List<int>{(int)FoodTag.Vegan }
			},
			new FoodModel
			{
				Id = 5,
				Name = "Spanish Omelette & Avocado Toast",
				Description = "",
				CategoryId = 1,
				Price =7.00f,
				ImageUrl = "/img/sandwichesToasts/5.jpeg",
				Tags = new List<int>{ }
			},
			new FoodModel
			{
				Id = 6,
				Name = "Creamy Turkey Avocado Toast",
				Description = "Smooth cream cheese, lean turkey, and fresh avocado are topped with vibrant sprouts for a wholesome and satisfying snack.",
				CategoryId = 1,
				Price =6.25f,
				ImageUrl = "/img/sandwichesToasts/6.jpeg",
				Tags = new List<int>{(int)FoodTag.Recommended }
			},
			new FoodModel
			{
				Id = 7,
				Name = "Roast Beef Delight Toast",
				Description = "Tender roast beef layered with fresh tomato, peppery arugula, and creamy mayo, finished with our signature sauce for an extra burst of flavor.",
				CategoryId = 1,
				Price =7.50f,
				ImageUrl = "/img/sandwichesToasts/7.jpeg",
				Tags = new List<int>{ }
			},
			new FoodModel
			{
				Id = 8,
				Name = "Avocado Poché Toast",
				Description = "A nourishing combination of grated tomato, creamy avocado, and a perfectly poached organic egg, topped with crunchy pumpkin seeds for a delightful texture.",
				CategoryId = 1,
				Price =7.80f,
				ImageUrl = "/img/sandwichesToasts/8.jpeg",
				Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 9,
				Name = "Strawberry Nutella",
				Description = "Fluffy pancakes topped with sweet Nutella, fresh strawberries, and a sprinkle of crunchy nuts for a decadent treat.",
				CategoryId = 2,
				Price =5.50f,
				ImageUrl = "/img/pancakes/1.jpeg",
				Tags = new List<int>{}
			},
			new FoodModel
			{
				Id = 10,
				Name = "Banana Pistachio Pancakes",
				Description = "",
				CategoryId = 2,
				Price =6.50f,
				ImageUrl = "/img/pancakes/2.jpeg",
				Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 11,
				Name = "Carrot Cake",
				Description = "A moist and spiced carrot cake, with a perfect blend of carrots and aromatic spices, topped with a light frosting.",
				CategoryId = 3,
				Price =4.75f,
				ImageUrl = "/img/cakes/1.jpeg",
				Tags = new List<int>{ }
			},
			new FoodModel
			{
				Id = 12,
				Name = "Vegan Banana Chocolate Cake",
				Description = "A rich and delicious cake featuring sweet banana and decadent chocolate, all made vegan for a guilt-free indulgence.",
				CategoryId = 3,
				Price =5.60f,
				ImageUrl = "/img/cakes/2.jpeg",
				Tags = new List<int>{(int)FoodTag.Vegan }
			},
			new FoodModel
			{
				Id = 13,
				Name = "Lemon Blueberry Cake",
				Description = "A zesty lemon cake studded with juicy blueberries, offering a refreshing and flavorful treat in every bite.",
				CategoryId = 3,
				Price =6.00f,
				ImageUrl = "/img/cakes/3.jpeg",
				Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 14,
				Name = "Cips",
				Description = "",
				CategoryId = 4,
				Price =1.95f,
				ImageUrl = "/img/snacks/1.jpeg",
				Tags = new List<int>{}
			},
			new FoodModel
			{
				Id = 15,
				Name = "Olives",
				Description = "",
				CategoryId = 4,
				Price =2.50f,
				ImageUrl = "/img/snacks/2.jpeg",
				Tags = new List<int>{}
			},
			new FoodModel
			{
				Id = 16,
				Name = "Cheese Platter",
				Description = "A gourmet selection of cheeses: aged, semi-cured, and Brie, perfect for sharing or enjoying on your own.",
				CategoryId = 4,
				Price =11.50f,
				ImageUrl = "/img/snacks/3.jpeg",
				Tags = new List<int>{}
			},
			new FoodModel
			{
				Id = 17,
				Name = "Spanish Bravas",
				Description = "Crispy potatoes topped with a spicy, flavorful sauce, a classic Spanish snack that's always a crowd-pleaser.",
				CategoryId = 4,
				Price =5.50f,
				ImageUrl = "/img/snacks/4.jpeg",
				Tags = new List<int>{(int)FoodTag.Recommended }
			},
			new FoodModel
			{
				Id = 18,
				Name = "Vermouth Snack Pack",
				Description = "",
				CategoryId = 4,
				Price =5.00f,
				ImageUrl = "/img/snacks/5.jpeg",
				Tags = new List<int>{(int)FoodTag.New }
			},
			new FoodModel
			{
				Id = 19,
				Name = "Apple, Orange, and Carrot Juice",
				Description = "A refreshing blend of crisp apples, juicy oranges, and sweet carrots, offering a vibrant and revitalizing drink.",
				CategoryId = 5,
				Price =3.95f,
				ImageUrl = "/img/drinks/1.jpeg",
				Tags = new List<int>{(int)FoodTag.Recommended }
			},
			new FoodModel
			{
				Id = 20,
				Name = "Beetroot, Lemon, Apple, and Ginger Juice",
				Description = "A zesty and invigorating mix of earthy beetroot, tangy lemon, crisp apple, and spicy ginger for a unique and energizing juice.",
				CategoryId = 5,
				Price =3.95f,
				ImageUrl = "/img/drinks/2.jpeg",
				Tags = new List<int>{(int)FoodTag.Recommended }
			},
			new FoodModel
			{
				Id = 21,
				Name = "Orange juice",
				CategoryId = 5,
				Price =2.30f,
			},
			new FoodModel
			{
				Id = 22,
				Name = "Espresso",
				CategoryId = 5,
				Price =1.40f,
			},
			new FoodModel
			{
				Id = 23,
				Name = "Double Espresso",
				CategoryId = 5,
				Price =2.00f,
			},
			new FoodModel
			{
				Id = 24,
				Name = "Caffè Latte",
				CategoryId = 5,
				Price =1.80f,
			},
			new FoodModel
			{
				Id = 25,
				Name = "Mineral Water",
				CategoryId = 5,
				Price =1.50f,
			},
			new FoodModel
			{
				Id = 26,
				Name = "Sparkling Water",
				CategoryId = 5,
				Price =1.90f,
			},
			new FoodModel
			{
				Id = 27,
				Name = "Coca-Cola / Zero",
				CategoryId = 5,
				Price =2.50f,
			},
			new FoodModel
			{
				Id = 28,
				Name = "Nestea",
				CategoryId = 5,
				Price =2.50f,
			},
			new FoodModel
			{
				Id = 29,
				Name = "Aquarius",
				CategoryId = 5,
				Price =2.50f,
			},
			new FoodModel
			{
				Id = 30,
				Name = "Cacaolat (275ml)",
				CategoryId = 5,
				Price =2.75f,
			},
		};

		public List<FoodModel> GetAll()
		{
			return _food;
		}

		public Task<int> Create([Bind(new[] { "Name", "CategoryId" })] FoodModel category)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<FoodModel> GetById(int id)
		{
			return _food.Find(item => item.Id == id);
		}

		public async Task<List<FoodModel>> GetByCategoryId(int id)
		{
			return _food.Where(item => item.CategoryId == id).ToList();
		}
	}
}
