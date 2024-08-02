using System;
using System.Collections.Generic;
using yitangCalamity.Content.Buffs;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Buffs.StatDebuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace yitangCalamity.Common
{
    public static class ytCalamityUtils
    {
        public static void DrawInventoryCustomScale(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale, float wantedScale = 1f, Vector2 drawOffset = default)
        {
            wantedScale = Math.Max(scale, wantedScale * Main.inventoryScale);
            position += drawOffset * wantedScale;
            spriteBatch.Draw(texture, position, new Rectangle?(frame), drawColor, 0f, origin, wantedScale, 0, 0f);
        }

		/*拓展方法，在另一个地方对某一个类(yitangCalamityPlayer)创建一个方法(yitangCalamity)，
		但对那个类的代码没有做任何涉及和改动。在其他地方可以直接去调用实例( player.yitangCalamity() )，
		看起来就像是在调用那个类的实例方法一样，但实际上不是那个类的。(๑•̀ㅂ•́)و✧*/
		public static yitangCalamityPlayer yitangCalamity(this Player player)
        {
            return player.GetModPlayer<yitangCalamityPlayer>();
        }

        //public static yitangCalamityGlobalProjectile yitangCalamity(this Projectile proj)
        //{
        //    return proj.GetGlobalProjectile<yitangCalamityGlobalProjectile>();
        //}
    }
}