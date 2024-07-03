//using System;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Microsoft.Xna.Framework;
//using System.Collections.Generic;
//using System.Linq;
//using yitangCalamity.Content.Items.Accessories;

//namespace yitangCalamity.Global
//{
//    public class ytCalamityGlobalItems : GlobalItem
//    {
//        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
//        {
//            TooltipLine nameLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.Mod == "Terraria");
//            if (nameLine != null)
//            {
//                SpecialRarityColor(item, nameLine);
//            }
//        }
//        //自定义物品名字的显示颜色
//        private void SpecialRarityColor(Item item, TooltipLine nameLine)
//        {
//            if (item.type == ModContent.ItemType<SacredNightEnchant>())
//            {
//                nameLine.OverrideColor = new Color(173, 159, 255, 80);
//            }
//            if (item.type == ModContent.ItemType<ProfanedDayEnchant>())
//            {
//                nameLine.OverrideColor = new Color(255, 99, 106, 80);
//            }
//        }

//        //微光永久性能力提升消耗品被禁止使用，因为它们有更好的上级合成
//        public override bool CanUseItem(Item item, Player player)
//        {
//            if (item.type == ItemID.AegisCrystal || item.type == ItemID.ArcaneCrystal || item.type == ItemID.AegisFruit
//                || item.type == ItemID.Ambrosia || item.type == ItemID.GalaxyPearl || item.type == ItemID.GummyWorm
//                || item.type == ItemID.ArtisanLoaf)
//            {
//                return false;
//            }
//            return true;
//        }
//        //public override void UseAnimation(Item item, Player player)
//        //{
//        //    if (item.type is ItemID.MagicMirror or ItemID.CellPhone or ItemID.IceMirror or ItemID.Shellphone
//        //        or ItemID.ShellphoneOcean or ItemID.ShellphoneHell or ItemID.ShellphoneSpawn or ItemID.MagicConch
//        //        or ItemID.DemonConch)
//        //    {
//        //        if (player.itemTime == player.itemTimeMax / 2 + 4)
//        //        {
//        //            player.itemTime = 90;
//        //        }
//        //    }
//        //}
//    }
//}
