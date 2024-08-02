using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

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
            itemLoot.Add(ItemDropRule.Common(ItemID.LesserHealingPotion, 1, 15, 15));

            if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
            {
                itemLoot.Add(ItemDropRule.Common(Calamity.Find<ModItem>("RoverDrive").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(Calamity.Find<ModItem>("AncientFossil").Type, 1, 1, 1)); 
            }

            if (ModLoader.TryGetMod("AmuletOfManyMinions", out Mod AOMM))
            {
                itemLoot.Add(ItemDropRule.Common(AOMM.Find<ModItem>("CinderHenMinionItem").Type, 1, 1, 1));
            }

            if (ModLoader.TryGetMod("Fargowiltas", out Mod FargoMutant))
            {
                itemLoot.Add(ItemDropRule.Common(FargoMutant.Find<ModItem>("Instavator").Type, 1, 2, 2));
                itemLoot.Add(ItemDropRule.Common(FargoMutant.Find<ModItem>("SuperDummy").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(FargoMutant.Find<ModItem>("BattleCry").Type, 1, 1, 1));
            }

            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoSouls))
            {
                itemLoot.Add(ItemDropRule.Common(FargoSouls.Find<ModItem>("EurusSock").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(FargoSouls.Find<ModItem>("PuffInABottle").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(FargoSouls.Find<ModItem>("MutantsPact").Type, 1, 1, 1));
            }

            if (ModLoader.TryGetMod("miningcracks_take_on_luiafk", out Mod LuiAFK))
            {
                itemLoot.Add(ItemDropRule.Common(LuiAFK.Find<ModItem>("UnlimitedTorches").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(LuiAFK.Find<ModItem>("UnlimitedTravel").Type, 1, 1, 1));
            }

            if (ModLoader.TryGetMod("ImproveGame", out Mod ImproveGame))
            {
                itemLoot.Add(ItemDropRule.Common(ImproveGame.Find<ModItem>("SpaceWand").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(ImproveGame.Find<ModItem>("BannerChest").Type, 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(ImproveGame.Find<ModItem>("ExtremeStorage").Type, 1, 1, 1));
            }
        }
    }
}