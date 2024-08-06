using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Foods.VanillaFoods
{
	public class Food02 : BaseFood
	{
		public override Color NameColor => new(235, 87, 87);

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.width = 48;
			Item.height = 61;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item3; //饮用药水、液体食物的音效
			Item.useStyle = ItemUseStyleID.DrinkLiquid; //喝药水、饮料、药剂、染发剂的动作
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
				.AddIngredient(ItemID.EoCShield)
				.Register();
		}
	}
}