using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.NPCs;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;

namespace yitangCalamity.Global.Recipes
{
    public class ShimmerGlobalItems : GlobalItem
    {
        //微光嬗变，直接扔进微光转化物品，方括号内是要扔进微光的物品，等号后输出的结果是转化后的物品。
        public override void SetStaticDefaults()
        {
            //地牢金锁箱开出来的武器和配饰(地牢匣)，按照职业和武器顺序。
            ItemID.Sets.ShimmerTransformToItem[ItemID.Muramasa] = ItemID.Valor;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Valor] = ItemID.BlueMoon;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BlueMoon] = ItemID.Handgun;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Handgun] = ItemID.AquaScepter;
            ItemID.Sets.ShimmerTransformToItem[ItemID.AquaScepter] = ItemID.MagicMissile;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MagicMissile] = ItemID.CobaltShield;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CobaltShield] = ItemID.Muramasa;

            //地狱暗影箱开出来的武器和配饰(黑曜石锁盒)，按照职业顺序。
            ItemID.Sets.ShimmerTransformToItem[ItemID.DarkLance] = ItemID.Sunfury;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Sunfury] = ItemID.HellwingBow;
            ItemID.Sets.ShimmerTransformToItem[ItemID.HellwingBow] = ItemID.FlowerofFire;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FlowerofFire] = ItemID.Flamelash;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Flamelash] = ItemID.TreasureMagnet;
            ItemID.Sets.ShimmerTransformToItem[ItemID.TreasureMagnet] = ItemID.DarkLance;

            //整蛊坐垫 => 僵尸臂
            ItemID.Sets.ShimmerTransformToItem[ItemID.WhoopieCushion] = ItemID.ZombieArm;

            //哥布林术士掉落的武器和配饰，按照职业顺序。
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShadowFlameKnife] = ItemID.ShadowFlameBow;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShadowFlameBow] = ItemID.ShadowFlameHexDoll;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShadowFlameHexDoll] = ModContent.ItemType<BurningStrife>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<BurningStrife>()] = ModContent.ItemType<TheFirstShadowflame>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<TheFirstShadowflame>()] = ItemID.ShadowFlameKnife;

            //花后地牢的装甲骷髅掉落的物品
            ItemID.Sets.ShimmerTransformToItem[ItemID.Keybrand] = ItemID.Kraken;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Kraken] = ItemID.MagnetSphere;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MagnetSphere] = ItemID.MaceWhip;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MaceWhip] = ItemID.BoneFeather;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BoneFeather] = ItemID.WispinaBottle;
            ItemID.Sets.ShimmerTransformToItem[ItemID.WispinaBottle] = ItemID.Keybrand;

			//灾厄的三个雕像
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CrimsonEffigy>()] = ModContent.ItemType<CorruptionEffigy>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CorruptionEffigy>()] = ModContent.ItemType<EffigyOfDecay>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<EffigyOfDecay>()] = ModContent.ItemType<CrimsonEffigy>();

			//肉后血月钓鱼敌怪
			ItemID.Sets.ShimmerTransformToItem[ItemID.DripplerFlail] = ItemID.SharpTears;
			ItemID.Sets.ShimmerTransformToItem[ItemID.SharpTears] = ItemID.SanguineStaff;
			ItemID.Sets.ShimmerTransformToItem[ItemID.SanguineStaff] = ItemID.DripplerFlail;

			//双足翼龙掉落武器
			if (ModLoader.HasMod("FargowiltasSouls"))
			{
				ItemID.Sets.ShimmerTransformToItem[ItemID.DD2SquireBetsySword] = ItemID.MonkStaffT3;
				ItemID.Sets.ShimmerTransformToItem[ItemID.MonkStaffT3] = ItemID.DD2BetsyBow;
				ItemID.Sets.ShimmerTransformToItem[ItemID.DD2BetsyBow] = ModContent.Find<ModItem>("FargowiltasSouls", "DragonBreath").Type;
				ItemID.Sets.ShimmerTransformToItem[ModContent.Find<ModItem>("FargowiltasSouls", "DragonBreath").Type] = ItemID.ApprenticeStaffT3;
				ItemID.Sets.ShimmerTransformToItem[ItemID.ApprenticeStaffT3] = ItemID.DD2SquireBetsySword;
			}

			//灾厄Mod和灾劫Mod星流巨械的掉落武器互相转化。
			if (ModLoader.HasMod("CatalystMod"))
			{
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<PhotonRipper>()] = ModContent.ItemType<SpineOfThanatos>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<SpineOfThanatos>()] = ModContent.ItemType<SurgeDriver>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<SurgeDriver>()] = ModContent.ItemType<TheJailor>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<TheJailor>()] = ModContent.Find<ModItem>("CatalystMod", "Plasmilegion").Type;
				ItemID.Sets.ShimmerTransformToItem[ModContent.Find<ModItem>("CatalystMod", "Plasmilegion").Type] = ModContent.ItemType<AresExoskeleton>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<AresExoskeleton>()] = ModContent.ItemType<AtlasMunitionsBeacon>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<AtlasMunitionsBeacon>()] = ModContent.ItemType<RefractionRotor>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RefractionRotor>()] = ModContent.ItemType<TheAtomSplitter>();
				ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<TheAtomSplitter>()] = ModContent.ItemType<PhotonRipper>();
			}
		}
    }
}