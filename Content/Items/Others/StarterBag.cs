using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using System.Threading.Channels;

namespace yitangCalamity.Content.Items.Others
{
	public class StarterBag : ModItem
	{
		public override void SetDefaults()
		{
			Item.consumable = true;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.value = 0;
			Item.rare = ItemRarityID.Blue;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public void AddModItemLoot(ItemLoot itemLoot, Mod mod, string itemName, int chance = 1, int min = 1, int max = 1)
		{
			if (mod.TryFind<ModItem>(itemName, out ModItem modItem))
			{
				itemLoot.Add(ItemDropRule.Common(modItem.Type, chance, min, max));
			}
		}

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.Common(ItemID.LesserHealingPotion, 1, 10, 10));
			itemLoot.Add(ItemDropRule.Common(ItemID.ManaCrystal, 1, 3, 3));
			itemLoot.Add(ItemDropRule.Common(ItemID.PiggyBank));
			itemLoot.Add(ItemDropRule.Common(ItemID.GrapplingHook));
			itemLoot.Add(ItemDropRule.Common(ItemID.BugNet));
			itemLoot.Add(ItemDropRule.Common(ItemID.Chest, 1, 9, 9));
			itemLoot.Add(ItemDropRule.Common(ItemID.SlimeCrown));
			itemLoot.Add(ItemDropRule.Common(ItemID.SilverPickaxe));
			itemLoot.Add(ItemDropRule.Common(ItemID.SilverAxe));
			itemLoot.Add(ItemDropRule.Common(ItemID.SilverHammer));

			if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
			{
				AddModItemLoot(itemLoot, Calamity, "RoverDrive");
				AddModItemLoot(itemLoot, Calamity, "AncientFossil");
			}

			if (ModLoader.TryGetMod("AmuletOfManyMinions", out Mod AOMM))
			{
				AddModItemLoot(itemLoot, AOMM, "CinderHenMinionItem");
			}

			if (ModLoader.TryGetMod("Fargowiltas", out Mod FargoMutant))
			{
				AddModItemLoot(itemLoot, FargoMutant, "Instavator", 1, 2, 2);
				AddModItemLoot(itemLoot, FargoMutant, "SuperDummy");
				AddModItemLoot(itemLoot, FargoMutant, "BattleCry");
			}

			if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoSouls))
			{
				AddModItemLoot(itemLoot, FargoSouls, "EurusSock");
				AddModItemLoot(itemLoot, FargoSouls, "PuffInABottle");
				AddModItemLoot(itemLoot, FargoSouls, "MutantsPact");
			}

			if (ModLoader.TryGetMod("miningcracks_take_on_luiafk", out Mod LuiAFK))
			{
				AddModItemLoot(itemLoot, LuiAFK, "UnlimitedTorches");
				AddModItemLoot(itemLoot, LuiAFK, "UnlimitedTravel");
			}

			if (ModLoader.TryGetMod("ImproveGame", out Mod ImproveGame))
			{
				AddModItemLoot(itemLoot, ImproveGame, "SpaceWand");
				AddModItemLoot(itemLoot, ImproveGame, "BannerChest");
				AddModItemLoot(itemLoot, ImproveGame, "ExtremeStorage");
			}
		}
	}
}