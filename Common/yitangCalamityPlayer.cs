using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using tModPorter;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent;
using Microsoft.CodeAnalysis.CodeStyle;
using CalamityMod;
using CalamityMod.Items.Potions.Alcohol;
using CalamityMod.Cooldowns;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Tiles.Furniture;
using CalamityMod.CalPlayer;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Buffs.Potions;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Buffs.StatDebuffs;
using yitangCalamity.Global.Config;
//using yitangCalamity.Global.Keybind;
using yitangCalamity.Content.Items.Others;
using yitangCalamity.Content.Buffs;
using yitangCalamity.Content.Items;
using yitangCalamity.Content.Buffs.Potions;
using yitangCalamity.Content.Items.Potions;
//using yitangCalamity.Content.Items.Accessories;
using yitangCalamity.Global.GlobalItems.FuckCalamity;

namespace yitangCalamity.Common
{
    public class yitangCalamityPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            if (cadence)
            {
				/*同样是提升最大生命值的25%，但是有两个公式可以实现：
				线性提升：Player.statLifeMax2 += (int)(Player.statLifeMax * 0.25);
				非线性提升：Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 25;

				这里的公式最终采用了和原版Terraria的生命力药水相似的非线性公式去计算，而不是固定地去乘以25%。
				目的是为了平衡，线性公式的情况下，无论玩家的最大生命值是多少，增加的量始终是statLifeMax的25%，
				而非线性公式，增加的生命值是基于当前生命值的一个比例，但这个比例会因为向下取整的操作而逐渐减小。
				最终这会导致在低生命值时增加的百分比较高，而在高生命值时增加的百分比较低，
				即随着玩家的最大生命值越来越高，这个药水提高的最大生命值反而会越小，这也就是所谓的像原版那样的平衡。*/
				Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 25;
            }
            triumph = false;
            contactDamageReduction = 0.0;
            cadence = false;
            yPower = false;
            revivify = false;
            tScale = false;
            magicHat = false;
            //ExoChair = false;
            draconicSurge = false;
            babywaterclone = false;
            cloudmini = false;
            rarebrimling = false;
            raresandmini = false;
            sandmini = false;
            //betterPStone = 1f;
            //starReacher = false;
            //sacredCross = false;
            //starAdventurer = false;
            sunshine = false;
            fortitude = false;
            longInvincible = false;
            blurring = false;
            ninjaSkill = false;
            //if (!Main.mapFullscreen)
            //{
            //    delay = 0;
            //}
            //GlobalTeleporter = false;
            //GlobalTeleporterUp = false;
            //holyMinions = false;
        }

        public override void UpdateDead()
        {
            cadence = false;
            triumph = false;
            yPower = false;
            revivify = false;
            tScale = false;
            titanBoost = 0;
            //ExoChair = false;
            draconicSurge = false;
            sunshine = false;
            fortitude = false;
            longInvincible = false;
            blurring = false;
            ninjaSkill = false;
        }

        public override void UpdateLifeRegen()
        {
            if (cadence)
            {
                Player.lifeRegen += 5;
                /*原版TR生命再生的公式里最后要除以2。每2秒增加n点生命值，
                也就是说如果lifeRegen += 5; 那么游戏里实际显示和应用的生命再生速度为增加2.5点。*/
            }
        }

		//public override void PreUpdateMovement()
		//{
		//    if (Player.whoAmI == Main.myPlayer && ExoChair)
		//    {
		//        float speed = 12f;
		//        if (Player.controlLeft)
		//        {
		//            Player.velocity.X = -speed;
		//            Player.direction = -1;
		//        }
		//        else if (Player.controlRight)
		//        {
		//            Player.velocity.X = speed;
		//            Player.direction = 1;
		//        }
		//        else
		//        {
		//            Player.velocity.X = 0f;
		//        }
		//        if (Player.controlUp || Player.controlJump)
		//        {
		//            Player.velocity.Y = -speed;
		//        }
		//        else if (Player.controlDown)
		//        {
		//            Player.velocity.Y = speed;
		//            if (Collision.TileCollision(Player.position, Player.velocity, Player.width, Player.height, true, false, (int)Player.gravDir).Y == 0f)
		//            {
		//                Player.velocity.Y = 0.5f;
		//            }
		//        }
		//        else
		//        {
		//            Player.velocity.Y = 0f;
		//        }
		//        if (yitangCalamityKeybind.ExoChairSpeedupHotkey.Current)
		//        {
		//            Player.velocity *= 2f;
		//        }
		//    }
		//}

		public override void OnHurt(Player.HurtInfo info)
        {
            if (revivify)
            {
                int revivifyNum = (int)(info.Damage / 15.0);
                Player.statLife += revivifyNum;
                Player.HealEffect(revivifyNum, true);
            }
        }

        //public override void PostHurt(Player.HurtInfo hurtInfo)
        //{
        //    if (Player.whoAmI == Main.myPlayer)
        //    {
        //        if (starReacher)
        //        {
        //            Player.AddImmuneTime(hurtInfo.CooldownCounter, 40);
        //        }
        //        if (sacredCross)
        //        {
        //            Player.AddImmuneTime(hurtInfo.CooldownCounter, 60);
        //        }
        //        if (starAdventurer)
        //        {
        //            Player.AddImmuneTime(hurtInfo.CooldownCounter, 90);
        //        }
        //    }
        //}

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            if (triumph)
            {
				/*分子(npc.life)越小，整体分数的值(npc.life / (double)npc.lifeMax)就越小
				所以1.0减去这个分数得到的值，反而就会越大
				因此这个公式意思是 敌怪血量越少，contactDamageReduction的值越大*/
				contactDamageReduction += 0.15 * (1.0 - npc.life / (double)npc.lifeMax);
            }

			if (contactDamageReduction > 0.0)
			{
				//用1去除以这个值，使其伤害减免百分比将永远不会超过100%
				contactDamageReduction = 1.0 / (1.0 + contactDamageReduction);

				//最终计算
				modifiers.SourceDamage *= (float)contactDamageReduction;
			}
		}

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player.yitangCalamity().titanBoost = 600;

			//if (Player.whoAmI != Main.myPlayer)
			//	return;

			//NPCDebuffs(target, item.CountsAsClass<MagicDamageClass>(),
			//	item.CountsAsClass<SummonDamageClass>(),
			//	item.CountsAsClass<SummonMeleeSpeedDamageClass>());
		}

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (proj.IsTrueMelee())
            {
                titanBoost = 600;
            }

            //if (Player.whoAmI != Main.myPlayer)
            //    return;

            //if (!proj.npcProj && !proj.trap && proj.friendly)
            //{
            //    NPCDebuffs(target, proj.CountsAsClass<MagicDamageClass>(),
            //        proj.CountsAsClass<SummonDamageClass>(),
            //        proj.CountsAsClass<SummonMeleeSpeedDamageClass>(), true, proj.noEnchantments);
            //}
        }

        //public void NPCDebuffs(NPC target, bool magic, bool summon, bool whip, bool proj = false, bool noFlask = false)
        //{
        //    if (summon)
        //    {
        //        if (holyMinions)
        //        {
        //            target.AddBuff(ModContent.BuffType<HolyFlames>(), 180);
        //        }
        //    }
        //}

        public override void PostUpdateMiscEffects()
        {
			if (cadence)
			{
				//生命拾心的药水效果
				Player.lifeMagnet = true;
			}

			if (tScale)
            {
                Player.endurance += 0.05f;
                Player.statDefense += 5;
                Player.kbBuff = true;
                if (titanBoost > 0)
                {
                    Player.statDefense += 25;
                    Player.endurance += 0.1f;
                }
            }
			else
			{
				titanBoost = 0;
			}

            if (titanBoost > 0)
            {
                titanBoost--;
            }

            double flightTimeMult = 1f + (draconicSurge ? 0.2f : 0f);

            if (Player.wingTimeMax > 0)
            {
                Player.wingTimeMax = (int)(Player.wingTimeMax * flightTimeMult);
            }
            if (draconicSurge)
            {
                //Player.accRunSpeed += 0.1f;
                //Player.runAcceleration += 0.1f;
                Player.statDefense += 16;
            }

            if (Player.HasCooldown(SilvaRevive.ID))
            {
                draconicSurge = false;
                if (Player.FindBuffIndex(ModContent.BuffType<DraconicSurgeBuff>()) > -1)
                {
                    Player.ClearBuff(ModContent.BuffType<DraconicSurgeBuff>());
                }
            }
        }

        public override void UpdateEquips()
        {
            //Player.potionDelayTime = (int)(Player.potionDelayTime - Player.potionDelayTime * (double)betterPStone);
            //Player.restorationDelayTime = (int)(Player.restorationDelayTime - Player.restorationDelayTime * (double)betterPStone);
            //Player.mushroomDelayTime = (int)(Player.mushroomDelayTime - Player.mushroomDelayTime * (double)betterPStone);

            if (yPower)
            {
                Player.GetDamage(DamageClass.Generic) += 0.05f;
                Player.GetCritChance(DamageClass.Generic) += 2f;
                Player.endurance += 0.04f;
                Player.statDefense += 10;
                Player.pickSpeed -= 0.1f;
                Player.GetKnockback(DamageClass.Summon) += 1f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.075f;
                Player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.075f;
                Player.moveSpeed += 0.075f;
            }
            if (sunshine)
            {
                Lighting.AddLight((int)(Player.position.X + (double)(Player.width / 2)) / 16, (int)(Player.position.Y + (double)(Player.height / 2)) / 16, 3f, 3f, 3f);
            }
            if (fortitude)
            {
                Player.noKnockback = true;
            }
            if (longInvincible)
            {
                Player.longInvince = true;
            }
            if (blurring)
            {
                Player.onHitDodge = true;
                if (Player.onHitDodge && ShadowDodgeCooldown <= 0)
                {
					Player.AddBuff(BuffID.ShadowDodge, 900, true);
					ShadowDodgeCooldown = 2100;
				}
            }
            if (ninjaSkill)
            {
                Player.GetDamage(DamageClass.Generic) += 0.05f;
                Player.GetCritChance(DamageClass.Generic) += 5;
                Player.blackBelt = true;
                Player.spikedBoots = 2;
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            CalamityPlayer calamityPlayer = Player.Calamity();
            if (calamityPlayer.silvaSet && calamityPlayer.silvaCountdown > 0)
            {
                if (calamityPlayer.silvaCountdown == CalamityPlayer.silvaReviveDuration && draconicSurge && !Player.HasCooldown(SilvaRevive.ID))
                {
                    Player.statLife += Player.statLifeMax2 / 2;
                    Player.HealEffect(Player.statLifeMax2 / 2, true);
                    if (Player.statLife > Player.statLifeMax2)
                    {
                        Player.statLife = Player.statLifeMax2;
                    }
                    if (Player.FindBuffIndex(ModContent.BuffType<DraconicSurgeBuff>()) > 0)
                    {
                        Player.ClearBuff(ModContent.BuffType<DraconicSurgeBuff>());
                        Player.AddCooldown(SilvaRevive.ID, CalamityUtils.SecondsToFrames(60), true);
                        int additionalTime = 0;
                        for (int i = 0; i < Player.MaxBuffs; i++)
                        {
                            if (Player.buffType[i] == BuffID.PotionSickness)
                            {
                                additionalTime = Player.buffTime[i];
                            }
                        }
                        float seconds = 30f + (float)Math.Ceiling(additionalTime / 60.0);
                        Player.AddBuff(BuffID.PotionSickness, CalamityUtils.SecondsToFrames(seconds), true, false);
                    }
                }
                return false;
            }
            return true;
        }

		//public override void ProcessTriggers(TriggersSet triggersSet)
		//{
		//    if (GlobalTeleporter || GlobalTeleporterUp)
		//    {
		//        if (Main.mapFullscreen)
		//        {
		//            delay++;
		//            if (delay > 19 && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
		//            {
		//                bool allow = true;
		//                for (int v = 0; v < 200; ++v)
		//                {
		//                    NPC npc = Main.npc[v];
		//                    if (npc.active && npc.boss)
		//                    {
		//                        allow = false;
		//                        break;
		//                    }
		//                }
		//                if (allow)
		//                {
		//                    int mapWidth = Main.maxTilesX * 16;
		//                    int mapHeight = Main.maxTilesY * 16;
		//                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

		//                    cursorPosition.X -= Main.screenWidth / 2;
		//                    cursorPosition.Y -= Main.screenHeight / 2;

		//                    Vector2 mapPosition = Main.mapFullscreenPos;
		//                    Vector2 cursorWorldPosition = mapPosition;

		//                    cursorPosition /= 16;
		//                    cursorPosition *= 16 / Main.mapFullscreenScale;
		//                    cursorWorldPosition += cursorPosition;
		//                    cursorWorldPosition *= 16;

		//                    cursorWorldPosition.Y -= Player.height;
		//                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
		//                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
		//                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
		//                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

		//                    Player.Teleport(cursorWorldPosition, 0, 0);
		//                    NetMessage.SendData(65, -1, -1, null, 0, Player.whoAmI, cursorWorldPosition.X, cursorWorldPosition.Y, 1, 0, 0);
		//                    Main.mapFullscreen = false;

		//                    for (int index = 0; index < 120; ++index)
		//                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;

		//                    if (GlobalTeleporter)
		//                    {
		//                        Item[] inventory = Player.inventory;
		//                        for (int k = 0; k < inventory.Length; k++)
		//                        {
		//                            if (inventory[k].type == ModContent.ItemType<GlobalTeleporter>())
		//                            {
		//                                inventory[k].stack--;
		//                                break;
		//                            }
		//                        }
		//                    }
		//                    delay = 0;
		//                }
		//            }
		//        }
		//    }
		//}

		public override void PreUpdate()
		{
			if (ShadowDodgeCooldown > 0)
			{
				ShadowDodgeCooldown--;
			}
		}

		public bool triumph;
        public double contactDamageReduction;
        public bool cadence;
        public bool yPower;
        public bool revivify;
        public bool tScale;
        public int titanBoost;
        public bool magicHat;
        //public bool ExoChair;
        public bool draconicSurge;
        public bool babywaterclone;
        public bool cloudmini;
        public bool rarebrimling;
        public bool raresandmini;
        public bool sandmini;
        //public float betterPStone;
        //public bool starReacher;
        //public bool sacredCross;
        //public bool starAdventurer;
        public bool sunshine;
        public bool fortitude;
        public bool longInvincible;
        public bool blurring;
		public int ShadowDodgeCooldown;
		public bool ninjaSkill;
        //public int delay = 0;
        //public bool GlobalTeleporter = false;
        //public bool GlobalTeleporterUp = false;
        //public bool holyMinions = false;
    }
}