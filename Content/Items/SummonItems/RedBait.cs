using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Materials;

namespace yitangCalamity.Content.Items.SummonItems
{
    public class RedBait : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
				.AddIngredient(ItemID.Worm, 10)
				.AddIngredient<BloodOrb>(10)
				.AddIngredient<EssenceofHavoc>(5)
				.AddTile(TileID.DemonAltar)
				.Register();
        }

        public override bool CanUseItem(Player player) => !NPC.AnyNPCs(NPCID.BloodNautilus) && !Main.dayTime;

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 spawnPosition = player.Center - Vector2.UnitY * 600f;
                NPC.NewNPC(player.GetSource_ItemUse(Item), (int)spawnPosition.X, (int)spawnPosition.Y, NPCID.BloodNautilus);
            }
            return true;
        }
    }
}
