using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Projectiles.Others;

namespace yitangCalamity.Content.Projectiles.Others
{
    public class ShimmerWater : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly || target.friendly;
        }

        public override void AI()
        {
            if (Main.windPhysics)
            {
                Projectile.velocity.X = Projectile.velocity.X + Main.windSpeedCurrent * Main.windPhysicsStrength;
            }
            Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.04f * (float)Projectile.direction;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 10f)
            {
                Projectile.velocity.Y += 0.1f;
                Projectile.velocity.X *= 0.998f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, new Vector2?(new Vector2((float)((int)Projectile.position.X), (float)((int)Projectile.position.Y))), null);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 13, 0f, 0f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 30; j++)
            {
                int index = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ShimmerWaterDust>(), 0f, -2f, 0, default(Color), 1.1f);
                Main.dust[index].alpha = 100;
                Dust dust = Main.dust[index];
                dust.velocity.X = dust.velocity.X * 1.5f;
                Main.dust[index].velocity *= 3f;
            }
            if (Projectile.owner == Main.myPlayer)
            {
                int num = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
                int k = (int)(Projectile.position.Y + (float)(Projectile.height / 2)) / 16;
                WorldGen.Convert(num, k, 0, 4);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Shimmer, 100);
        }
    }
}