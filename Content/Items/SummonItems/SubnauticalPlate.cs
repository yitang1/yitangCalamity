using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Rarities;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamityMod.NPCs.PrimordialWyrm;
using CalamityMod.Tiles.Furniture.CraftingStations;

namespace yitangCalamity.Content.Items.SummonItems
{
	public class SubnauticalPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = ModContent.RarityType<HotPink>();
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			if (ModContent.TryFind<ModItem>("FargowiltasCrossmod/WyrmTablet", out ModItem WyrmTablet))
			{
				recipe.AddIngredient(WyrmTablet.Type);
			}
			else
			{
				recipe.AddIngredient<Voidstone>(30);
			}
			recipe.AddIngredient<ExoPrism>();
			recipe.AddIngredient<AshesofAnnihilation>();
			recipe.AddTile<DraedonsForge>();
			recipe.Register();
		}

		public override bool CanUseItem(Player player) => !NPC.AnyNPCs(ModContent.NPCType<PrimordialWyrmHead>());

		public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.Roar, player.position);

			Vector2 spawnPosition = player.Center - Vector2.UnitY * 600f;
			NPC.NewNPC(player.GetSource_ItemUse(Item), (int)spawnPosition.X, (int)spawnPosition.Y, ModContent.NPCType<PrimordialWyrmHead>());
			return true;
		}
	}
}