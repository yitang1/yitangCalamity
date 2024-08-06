using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using yitangCalamity.Content.Items.Others;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent;
using Terraria.ModLoader.Config;
using yitangCalamity.Global.Config;

namespace yitangCalamity.Global
{
	internal class ytCalamityWorld : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int LocatorArrowIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (LocatorArrowIndex != -1)
            {
                layers.Insert(LocatorArrowIndex, new LegacyGameInterfaceLayer("yitangCalamity: Locator Arrow",
                    delegate
                    {
                        Player player = Main.LocalPlayer;
                        ytCalamityConfig config = ModContent.GetInstance<ytCalamityConfig>();
                        if (player.accCritterGuide && config.LifeformAnalyzer)
                        {
                            for (int m = 0; m < Main.maxNPCs; ++m)
                            {
                                NPC npc = Main.npc[m];
                                if (npc.active && npc.rarity >= 1 && !config.DisabledLocatorNpcs.Contains(new NPCDefinition(npc.type)))
                                {
                                    Vector2 playerCenter = Main.LocalPlayer.Center + new Vector2(0, Main.LocalPlayer.gfxOffY);
                                    var vector = npc.Center - playerCenter;
                                    var distance = vector.Length();
                                    if (distance > 40 && distance <= config.LocatorRange)
                                    {
                                        var offset = Vector2.Normalize(vector) * Math.Min(70, distance - 20);
                                        float rotation = vector.ToRotation() + (float)(Math.PI / 2);
                                        var drawPosition = playerCenter - Main.screenPosition + offset;
                                        float fade = Math.Min(1f, (distance - 20) / 70);
                                        Main.spriteBatch.Draw(ModContent.Request<Texture2D>("yitangCalamity/Content/Projectiles/Others/LocatorProjectile").Value, drawPosition, null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                    }
                                }
                            }
                        }
                        return true;
                    }, InterfaceScaleType.Game)
                );
            }
        }
    }
}