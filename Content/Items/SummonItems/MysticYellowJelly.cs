using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.SummonItems
{
    public class MysticYellowJelly : ModItem
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
				.AddIngredient(ItemID.Frog,20)
				.AddIngredient(ItemID.FallenStar)
				.Register();
        }

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(NPCID.BoundTownSlimeYellow) && !NPC.AnyNPCs(NPCID.TownSlimeYellow);
		}

		public override bool? UseItem(Player player)
        {
            Vector2 spawnPosition = player.Center - Vector2.UnitX * 250f;
            NPC.NewNPC(player.GetSource_ItemUse(Item), (int)spawnPosition.X, (int)spawnPosition.Y, NPCID.BoundTownSlimeYellow);
            return true;
        }
    }
}