using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Item;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using CalamityMod.Items.Placeables.Furniture;
using Terraria.GameContent;
using yitangCalamity.Global;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs
{
    [AutoloadHead]
    internal class Tinkerer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Steampunker, AffectionLevel.Love)
                .SetNPCAffection(NPCID.DyeTrader, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("工匠会随着游戏进度提供并出售各种各样的配饰和功能性家具。据说，他是蒸汽朋克人的弟弟。"));
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 40;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            return NPC.downedGoblins && ytCalamityConfig.Instance.ytNPCTinkerer;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string> { "Alexander", "Peter" };
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(7))
            {
                case 0:
                    return "需要一些特别的东西？尽管说……";
                case 1:
                    return "你见过我的姐姐吗？比起工匠，她更像个蒸汽朋克女孩……";
                case 2:
                    return "呦……你想要什么？我的朋友。";
                case 3:
                    return "随着进度的推进，你可能会发现更有价值的东西，攒些钱币来我这里购买更稀有的饰品吧。";
                case 4:
                    return "你有在附近看到什么机械生物吗？";
                case 5:
                    return "如果你加载的Mod比较多时，你可能会发现有的饰品会有不止一个上级配方，所以每次在我这里可以一次多买几个以作备用。";
                default:
                    return "你永远不会知道在哪里可以得到真正有价值的东西，所以耐心探索每一个可能的角落吧。";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "饰品商店";
            button2 = "功能性家具";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Accessories";
            }
            else
            {
                shop = "ArenaShop";
            }

        }

        public override void AddShops()
        {
            var accessories = new NPCShop(Type, "Accessories");
            var arenaShop = new NPCShop(Type, "ArenaShop");

            #region 原版饰品

            #region 机动性相关
                //疾风脚镯↓
            accessories.Add(CustomPrice(ItemID.Aglet, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AnkletoftheWind, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                //靴子系列↓
                .Add(CustomPrice(ItemID.HermesBoots, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WaterWalkingBoots, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SailfishBoots, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlurryBoots, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IceSkates, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlowerBoots, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SandBoots, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlyingCarpet, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FrogLeg, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.TerrasparkBoots, buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedMoonLord })
                //忍者大师装备↓
                .Add(CustomPrice(ItemID.ClimbingClaws, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ShoeSpikes, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BlackBelt, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.Tabi, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                //气瓶和气球↓
                .Add(CustomPrice(ItemID.ShinyRedBalloon, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CloudinaBottle, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BlizzardinaBottle, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SandstorminaBottle, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.TsunamiInABottle, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BalloonPufferfish, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LuckyHorseshoe, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                //熔岩靴系列↓
                .Add(CustomPrice(ItemID.ObsidianSkull, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LavaCharm, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ObsidianRose, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlameWakerBoots, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                //海洋相关↓
                .Add(CustomPrice(ItemID.Flipper, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.DivingHelmet, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.JellyfishNecklace, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FloatingTube, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                //其他类↓
                .Add(CustomPrice(ItemID.DiscountCard, buyPrice(0, 6, 0, 0)), new Condition[] { Condition.DownedPirates })
                .Add(CustomPrice(ItemID.GoldRing, buyPrice(0, 6, 0, 0)), new Condition[] { Condition.DownedPirates })
                .Add(CustomPrice(ItemID.LuckyCoin, buyPrice(0, 6, 0, 0)), new Condition[] { Condition.DownedPirates })
            #endregion

            #region 生命与魔力相关
                //生命恢复类↓
                .Add(CustomPrice(ItemID.BandofRegeneration, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ShinyStone, buyPrice(0, 15, 0, 0)), new Condition[] { Condition.DownedGolem })
                //魔力恢复类↓
                .Add(CustomPrice(ItemID.NaturesGift, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BandofStarpower, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CelestialMagnet, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
            #endregion

            #region 战斗相关
                //伤害类↓
                .Add(CustomPrice(ItemID.WhiteString, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GreenCounterweight, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.YoYoGlove, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.FeralClaws, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MagmaStone, buyPrice(0, 4, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SharkToothNecklace, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WarriorEmblem, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.RangerEmblem, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.SorcererEmblem, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.SummonerEmblem, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.MagicQuiver, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.RifleScope, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.PygmyNecklace, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedQueenBee })
                .Add(CustomPrice(ItemID.HerculesBeetle, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.NecromanticScroll, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.SquireShield, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.ApprenticeScarf, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.MonkBelt, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.HuntressBuckler, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.EyeoftheGolem, buyPrice(0, 15, 0, 0)), new Condition[] { Condition.DownedGolem })
                //防御类↓
                .Add(CustomPrice(ItemID.FrozenTurtleShell, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.PaladinsShield, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedPlantera })
                //宝箱怪掉落物↓
                .Add(CustomPrice(ItemID.TitanGlove, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.PhilosophersStone, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.CrossNecklace, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.StarCloak, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.FleshKnuckles, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.PutridScent, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                //十字章护盾系列↓
                .Add(CustomPrice(ItemID.CobaltShield, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.Bezoar, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AdhesiveBandage, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ArmorPolish, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Vitamins, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.TrifoldMap, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.FastClock, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Nazar, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Megaphone, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Blindfold, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.PocketMirror, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.HandWarmer, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AnkhShield, buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedMoonLord })
                //天界壳系列↓
                .Add(CustomPrice(ItemID.MoonCharm, buyPrice(0, 6, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.NeptunesShell, buyPrice(0, 15, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.MoonStone, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.SunStone, buyPrice(0, 20, 0, 0)), new Condition[] { Condition.DownedGolem })
                //其他类↓
                .Add(CustomPrice(ItemID.CordageGuide, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Shackle, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PanicNecklace, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());

            #endregion

            #endregion

            #region 战斗场地物品
            //战斗场地专用的、放置类物品，包括原版和模组
            arenaShop.Add(CustomPrice(ItemID.ShellphoneDummy, buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedMoonLord })
                .Add(CustomPrice(ItemID.Campfire, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SliceOfCake, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.NpcIsPresent(NPCID.PartyGirl) })
                .Add(CustomPrice(ItemID.WaterBucket, buyPrice(0, 0, 25, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LavaBucket, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HoneyBucket, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HeartLantern, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.StarinaBottle, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                //四个功能性蜡烛(原版和灾厄)↓
                .Add(CustomPrice(ItemID.PeaceCandle, buyPrice(0, 1, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WaterCandle, buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemType<TranquilityCandle>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemType<ChaosCandle>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedPlantera })
                //职业相关(利器站、弹药箱、水晶球等)↓
                .Add(CustomPrice(ItemID.CatBast, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WarTable, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.DownedOldOnesArmyAny })
                .Add(CustomPrice(ItemID.SharpeningStation, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AmmoBox, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GardenGnome, buyPrice(0, 3, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemID.BewitchingTable, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.AlchemyTable, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.CrystalBall, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                //灾厄的三个雕像↓
                .Add(CustomPrice(ItemType<CrimsonEffigy>(), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<CorruptionEffigy>(), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<EffigyOfDecay>(), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());

            #endregion

            accessories.Register();
            arenaShop.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 14;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 16f;
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)
        {
            scale = 1f;
            horizontalHoldoutOffset = 2;
            item = TextureAssets.Item[95].Value;
        }
    }
}