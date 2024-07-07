using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;

namespace yitangCalamity.Content.Items.SummonItems
{
    public static class MiscMethods
    {
        internal static void WriteText(string text)
        {
            WriteText(text, new Color(255, 0, 0));
        }

        internal static void WriteText(string text, Color c)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), c);
            }
            else
            {
                Main.NewText(text, c);
            }
        }
    }
    public class RainMagic : ModItem
	{
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item4;
            Item.maxStack = 1;
            Item.consumable = false;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.raining)
                {
                    RainOff();
                }
                else if (!Main.raining && !Main.slimeRain)
                {
                    RainOn();
                }
            }
            return true;
        }

        private static void RainOff()
        {
            MiscMethods.WriteText("雨停了！", new Color(0, 128, 255));
            Main.StopRain();
            NetMessage.SendData(MessageID.WorldData);
        }

        private static void RainOn()
        {
            MiscMethods.WriteText("开始下雨！", new Color(0, 128, 255));
            int day = 86400;
            int hour = day / 24;
            Main.rainTime = hour * 12;
            Main.raining = true;
            Main.maxRaining = Main.cloudAlpha = 0.9f;
            NetMessage.SendData(MessageID.WorldData);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BlizzardinaBottle)
                .AddIngredient(ItemID.Cloud, 30)
                .AddIngredient(ItemID.RainCloud, 15)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}