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
using CalamityMod.Items.Placeables.DraedonStructures;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Items.Placeables.FurnitureAshen;
using CalamityMod.Items.Placeables.FurnitureVoid;
using CalamityMod.Items.Placeables.FurnitureAbyss;
using CalamityMod.Items.Placeables.FurnitureBotanic;
using CalamityMod.Items.Placeables.FurnitureCosmilite;
using CalamityMod.Items.Placeables.FurnitureEutrophic;
using CalamityMod.Items.Placeables.FurnitureMonolith;
using CalamityMod.Items.Placeables.FurniturePlagued;
using CalamityMod.Items.Placeables.FurnitureProfaned;
using CalamityMod.Items.Placeables.FurnitureStratus;
using CalamityMod.Items.Placeables.FurnitureOtherworldly;
using CalamityMod.Items.Placeables.FurnitureSilva;
using CalamityMod.Items.Placeables.FurnitureStatigel;
using CalamityMod.Items.Placeables.FurnitureExo;
using CalamityMod.Items.Placeables.FurnitureAcidwood;
using CalamityMod.Items.Placeables.FurnitureSacrilegious;
using CalamityMod.Items.Placeables;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs
{
    [AutoloadHead]
	internal class Miner : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 150;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 25;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = -1;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,         
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("矿工大部分时间都在地下深处度过。出于某种原因，他实际上很喜欢采矿。"));
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }
                if (player.inventory.Any(item => item.type == ItemID.IronOre || item.type == ItemID.LeadOre))
                {
                    return ytCalamityConfig.Instance.ytNPCMiner;
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string> { "Gold", "John", "Edward", "Thomas" };
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(5))
            {
                case 0:
                    return "回到地面后，没有什么比喝杯啤酒更好的了！";
                case 1:
                    return "这些闪闪发光的宝石和矿石对我的用处不大，想把它们从我这儿买下来吗？";
                case 2:
                    return "如果你发现有的物块或矿石你挖不动，别担心，不是你的问题，是你手中镐子的问题";
                case 3:
                    return "你说我不应该在Y=11层挖掘是什么意思？";
                default:
                    return "钻石？虽然我不是专家，但我不认为你能用它们制造出一把剑。";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "珍贵物品";
            button2 = "各种宝箱";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Valuables";
            }
            else
            {
                shop = "Chests";
            }

        }

        public override void AddShops()
        {
            #region 灾厄Mod的Boss击败条件
            Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
            Condition DownedCrabulon = new Condition("Crabulon", () => DownedBossSystem.downedCrabulon);
            Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
            Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
            Condition DownedSlimeGod = new Condition("SlimeGod", () => DownedBossSystem.downedSlimeGod);

            Condition DownedCryogen = new Condition("Cryogen", () => DownedBossSystem.downedCryogen);
            Condition DownedAquaticScourge = new Condition("AquaticScourge", () => DownedBossSystem.downedAquaticScourge);
            Condition DownedBrimstoneElemental = new Condition("BrimstoneElemental", () => DownedBossSystem.downedBrimstoneElemental);
            Condition DownedCloneCalamitas = new Condition("CalClone", () => DownedBossSystem.downedCalamitasClone);
            Condition DownedLeviathan = new Condition("Leviathan", () => DownedBossSystem.downedLeviathan);
            Condition DownedAureus = new Condition("Aureus", () => DownedBossSystem.downedAstrumAureus);
            Condition DownedPlague = new Condition("Plague", () => DownedBossSystem.downedPlaguebringer);
            Condition DownedRavager = new Condition("Ravager", () => DownedBossSystem.downedRavager);
            Condition DownedDeus = new Condition("Deus", () => DownedBossSystem.downedAstrumDeus);

            Condition DownedDragonfolly = new Condition("Dragonfolly", () => DownedBossSystem.downedDragonfolly);
            Condition DownedProvidence = new Condition("Providence", () => DownedBossSystem.downedProvidence);
            Condition DownedPolterghast = new Condition("Polterghast", () => DownedBossSystem.downedPolterghast);
            Condition DownedOldDuke = new Condition("OldDuke", () => DownedBossSystem.downedBoomerDuke);
            Condition DownedStormWeaver = new Condition("StormWeaver", () => DownedBossSystem.downedStormWeaver);
            Condition DownedCeaselessVoid = new Condition("CeaselessVoid", () => DownedBossSystem.downedCeaselessVoid);
            Condition DownedSignus = new Condition("Signus", () => DownedBossSystem.downedSignus);
            Condition DownedTheThree = new Condition("Three", () => DownedBossSystem.downedStormWeaver && DownedBossSystem.downedCeaselessVoid && DownedBossSystem.downedSignus);
            Condition DownedDevourerOfGods = new Condition("DoG", () => DownedBossSystem.downedDoG);
            Condition DownedYharon = new Condition("Yharon", () => DownedBossSystem.downedYharon);
            Condition DownedExoMechs = new Condition("ExoMechs", () => DownedBossSystem.downedExoMechs);
            Condition DownedSuperCalamitas = new Condition("SCal", () => DownedBossSystem.downedCalamitas);
            #endregion

            #region 矿物
            var valuables = new NPCShop(Type, "Valuables")
                .Add(new Item(ItemID.Cobweb) { shopCustomPrice = buyPrice(copper: 10) })
                .Add(ItemID.Amethyst)
                .Add(ItemID.Topaz)
                .Add(ItemID.Sapphire)
                .Add(ItemID.Emerald)
                .Add(ItemID.Ruby)
                .Add(ItemID.Diamond)
                .Add(ItemID.Amber)
                .Add(ItemID.FossilOre)
                .Add(ItemID.CopperBar)
                .Add(ItemID.TinBar)
                .Add(ItemID.IronBar)
                .Add(ItemID.LeadBar)
                .Add(ItemID.SilverBar)
                .Add(ItemID.TungstenBar)
                .Add(ItemID.GoldBar)
                .Add(ItemID.PlatinumBar)
                .Add(ItemID.DemoniteBar, Condition.DownedEyeOfCthulhu)
                .Add(ItemID.CrimtaneBar, Condition.DownedEyeOfCthulhu)
                .Add(ItemID.MeteoriteBar, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Obsidian) { shopCustomPrice = buyPrice(silver: 1) } )
                .Add(ItemID.HellstoneBar, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.LifeCrystal) { shopCustomPrice = buyPrice(gold: 3) }, Condition.DownedEyeOfCthulhu)
                .Add(ItemID.CrystalShard, Condition.Hardmode)
                .Add(ItemID.CobaltBar, Condition.Hardmode)
                .Add(ItemID.PalladiumBar, Condition.Hardmode)
                .Add(ItemID.MythrilBar, Condition.Hardmode)
                .Add(ItemID.OrichalcumBar, Condition.Hardmode)
                .Add(ItemID.AdamantiteBar, Condition.Hardmode)
                .Add(ItemID.TitaniumBar, Condition.Hardmode)
                .Add(ItemID.ChlorophyteBar, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.LifeFruit) { shopCustomPrice = buyPrice(gold: 5) }, Condition.DownedPlantera);
            valuables.Register();
            #endregion

            #region 宝箱 (原版55个+模组21个)

            #region 原版宝箱
            //原版宝箱
            var chests = new NPCShop(Type, "Chests");
            chests.Add(CustomPrice(ItemID.Chest, buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GoldChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LivingWoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MushroomChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GlassChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IceChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BorealWoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.DesertChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CactusChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IvyChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RichMahoganyChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BambooChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HoneyChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ShadewoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.EbonwoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PalmWoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CoralChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SkywareChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WaterChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WebCoveredChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GraniteChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MarbleChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AshWoodChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ShadowChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ObsidianChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GolfChest, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BalloonChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.DynastyChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PumpkinChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BlueDungeonChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GreenDungeonChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PinkDungeonChest, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())

                .Add(CustomPrice(ItemID.SlimeChest, buyPrice(0, 0, 5, 0)), new Condition[] { Condition.DownedKingSlime })
                .Add(CustomPrice(ItemID.MeteoriteChest, buyPrice(0, 0, 5, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.BoneChest, buyPrice(0, 0, 5, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.PearlwoodChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.CrystalChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.SpiderChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.GoldenChest, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.DownedPirates })
                .Add(CustomPrice(ItemID.SteampunkChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.FleshChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.LesionChest, buyPrice(0, 0, 10, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.LihzahrdChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.SpookyChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.MartianChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedGolem })

                .Add(CustomPrice(ItemID.CrimsonChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.CorruptionChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.FrozenChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.DungeonDesertChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.JungleChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.HallowedChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedPlantera })

                .Add(CustomPrice(ItemID.SolarChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedCultist })
                .Add(CustomPrice(ItemID.VortexChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedCultist })
                .Add(CustomPrice(ItemID.NebulaChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedCultist })
                .Add(CustomPrice(ItemID.StardustChest, buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedCultist })
                #endregion

            #region 模组宝箱
                //灾厄Mod的宝箱
                .Add(CustomPrice(ItemType<SecurityChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<AgedSecurityChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<EutrophicChest>(), buyPrice(0, 0, 5, 0)), new Condition[] { DownedDesertScourge })
                .Add(CustomPrice(ItemType<AcidwoodChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<RustyChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<AbyssChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<AbyssTreasureChest>(), buyPrice(0, 0, 5, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemType<AshenChest>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<StatigelChest>(), buyPrice(0, 0, 5, 0)), new Condition[] { DownedSlimeGod })
                .Add(CustomPrice(ItemType<MonolithChest>(), buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<VoidChest>(), buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralChest>(), buyPrice(0, 0, 20, 0)), new Condition[] { DownedAureus })
                .Add(CustomPrice(ItemType<PlaguedPlateChest>(), buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedGolem })
                .Add(CustomPrice(ItemType<ProfanedChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedProvidence })
                .Add(CustomPrice(ItemType<BotanicChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedProvidence })
                .Add(CustomPrice(ItemType<StratusChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedPolterghast })
                .Add(CustomPrice(ItemType<OtherworldlyChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedTheThree })
                .Add(CustomPrice(ItemType<CosmiliteChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<SilvaChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<ExoChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedExoMechs })
                .Add(CustomPrice(ItemType<SacrilegiousChest>(), buyPrice(0, 0, 30, 0)), new Condition[] { DownedSuperCalamitas });
        #endregion

            #endregion

            chests.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 50;
            randExtraCooldown = 30;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            item = ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.Minecart).Value;

            itemSize = 30;

            if (NPC.spriteDirection == 1)
            {
                offset.X = -7;
            }

            if (NPC.spriteDirection == -1)
            {
                offset.X = 7;
            }
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 32;
            itemHeight = 32;
        }

        public override bool CanGoToStatue(bool toKingStatue) => true;
    }
}