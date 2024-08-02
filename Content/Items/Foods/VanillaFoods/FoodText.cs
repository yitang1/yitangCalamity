using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Foods.VanillaFoods
{
	public class FoodText : BaseFood
	{
		public override Color NameColor => new(255, 156, 165);

		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 53;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.consumable = false;
			Item.UseSound = SoundID.Item2;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.ManaCrystal)
				.AddIngredient(ItemID.TissueSample)
				.Register();
		}
	}
}
