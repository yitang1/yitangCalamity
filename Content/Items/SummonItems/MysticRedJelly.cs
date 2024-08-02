using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Materials;

namespace yitangCalamity.Content.Items.SummonItems
{
	public class MysticRedJelly : ModItem
	{
		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<BloodOrb>(5)
				.AddIngredient(ItemID.Gel, 20)
				.AddIngredient(ItemID.FallenStar)
				.Register();
		}

		public override bool CanUseItem(Player player) => !NPC.AnyNPCs(NPCID.TownSlimeRed);

		public override bool? UseItem(Player player)
		{
			Vector2 spawnPosition = player.Center - Vector2.UnitX * 250f;
			NPC.NewNPC(player.GetSource_ItemUse(Item), (int)spawnPosition.X, (int)spawnPosition.Y, NPCID.TownSlimeRed);
			return true;
		}
	}
}