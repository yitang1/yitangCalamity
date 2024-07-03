using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace yitangCalamity.CN.CalamityCN.Utils
{
    internal static class ItemHelper
    {
        public static void TranslateTooltip(List<TooltipLine> tooltips, string lineName, Action<TooltipLine> action)
        {
            ApplyTooltipEdits(tooltips, (tooltipLine) => tooltipLine.Name == lineName, action);
        }

        public static void TranslateTooltip(List<TooltipLine> tooltips, Func<TooltipLine, bool> predicate, Action<TooltipLine> action)
        {
            ApplyTooltipEdits(tooltips, predicate, action);
        }

        public static void ReplaceText(this List<TooltipLine> tooltips, string oldValue, string newValue)
        {
            TooltipLine value = tooltips.FirstOrDefault((x) => x.Text.Contains(oldValue));
            if (value != null)
            {
                value.Text = value.Text.Replace(oldValue, newValue);
            }
        }

        private static void ApplyTooltipEdits(List<TooltipLine> lines, Func<TooltipLine, bool> predicate, Action<TooltipLine> action)
        {
            foreach (TooltipLine line in lines.Where(predicate))
            {
                if (line != null)
                {
                    action(line);
                }
            }
        }
    }
}
