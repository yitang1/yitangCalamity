using System;
using Terraria;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Projectiles.Others
{
    public class ShimmerWaterDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170;
            dust.velocity *= 0.5f;
            dust.velocity.Y = dust.velocity.Y + 1f;
        }
    }
}