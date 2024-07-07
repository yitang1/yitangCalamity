using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace yitangCalamity.Content.Items.SummonItems
{
	public class ShinyPinkBalloon : ModItem
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
				.AddIngredient(ItemID.ShinyRedBalloon)
				.AddIngredient(ItemID.PinkGel, 10)
				.AddIngredient(ItemID.FallenStar)
				.Register();
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(NPCID.BoundTownSlimePurple) && !NPC.AnyNPCs(NPCID.TownSlimePurple);
		}

		public override bool? UseItem(Player player)
		{
			Vector2 spawnPosition = player.Center - Vector2.UnitY * 350f;
			NPC.NewNPC(player.GetSource_ItemUse(Item), (int)spawnPosition.X, (int)spawnPosition.Y, NPCID.BoundTownSlimePurple);
			return true;
		}
	}
}
