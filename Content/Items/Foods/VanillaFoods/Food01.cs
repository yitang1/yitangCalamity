using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Foods.VanillaFoods
{
	public class Food01 : BaseFood
	{
		public override Color NameColor => new(66, 211, 255);

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.width = 63;
			Item.height = 58;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item2; //食用固体食物的音效
			Item.useStyle = ItemUseStyleID.EatFood; //吃食物的动作
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
				.AddIngredient(ItemID.RoyalGel)
				.Register();
		}
	}
}