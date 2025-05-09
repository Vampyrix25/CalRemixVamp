﻿using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace CalRemix.UI.ElementalSystem
{
    public class ElementDisplay : InfoDisplay
	{
		public override bool Active() 
		{
			return Main.LocalPlayer.GetModPlayer<ElementPlayer>().EDisplay;
		}
		public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
		{
            ElementPlayer player = Main.LocalPlayer.GetModPlayer<ElementPlayer>();
			NPC npc = Main.LocalPlayer.GetModPlayer<ElementPlayer>().ETrack;
			if (npc is null)
			{
				displayColor = InactiveInfoTextColor;
                return CalRemixHelper.LocalText("UI.Element.None").Value;
            }
            if (!npc.TryGetGlobalNPC(out ElementNPC _))
            {
                displayColor = InactiveInfoTextColor;
                return CalRemixHelper.LocalText("UI.Element.NoInfo").Value;
            }
            if (npc.GetGlobalNPC<ElementNPC>().weak is null && npc.GetGlobalNPC<ElementNPC>().resist is null || Main.LocalPlayer.GetModPlayer<ElementPlayer>().noElement)
            {
                displayColor = InactiveInfoTextColor;
                return CalRemixHelper.LocalText("UI.Element.NoInfo").Value;
            }
            string s = CalRemixHelper.LocalText("UI.Element.NoInfo").Value;
            if (player.weakened > player.resisted)
            {
                s = CalRemixHelper.LocalText("UI.Element.Vulnerable").Format(player.weakened);
                s += (player.weakened > 1) ? "s" : string.Empty;
                displayColor = Color.Cyan;
            }
            else if (player.weakened < player.resisted)
            {
                s = CalRemixHelper.LocalText("UI.Element.Resistant").Format(player.resisted);
                s += (player.resisted > 1) ? "s" : string.Empty;
                displayColor = Color.OrangeRed;
            }
            else if (player.weakened == player.resisted && player.weakened > 0 && player.resisted> 0)
            {
                s = CalRemixHelper.LocalText("UI.Element.Equilibrium").Value;
                displayColor = Color.White;
            }
            else
                displayColor = Color.White;
            return s;
		}
	}
	public class ElementPlayer : ModPlayer
    {
        public NPC ETrack;
        public bool EDisplay;
        public bool noElement = true;
        public int weakened = 0;
        public int resisted = 0;
		public override void ResetEffects() 
		{
            EDisplay = false;
        }
		public override void UpdateEquips() 
		{
            EDisplay = true;
		}
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            ETrack = target;
            if (item.GetGlobalItem<ElementItem>().element is null)
            {
                noElement = true;
                return;
            }
            noElement = false;

            int weak = 0;
            Element[] e = item.GetGlobalItem<ElementItem>().element;
            if (target.GetGlobalNPC<ElementNPC>().weak != null)
            {
                foreach (Element w in target.GetGlobalNPC<ElementNPC>().weak)
                {
                    if (e.Contains(w))
                        weak++;
                }
            }
            weakened = weak;

            int resist = 0;
            if (target.GetGlobalNPC<ElementNPC>().resist != null)
            {
                foreach (Element r in target.GetGlobalNPC<ElementNPC>().resist)
                {
                    if (e.Contains(r))
                        resist++;
                }
            }
            resisted = resist;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            ETrack = target;
            if (proj.GetGlobalProjectile<ElementProj>().element is null)
            {
                noElement = true;
                return;
            }
            noElement = false;

            int weak = 0;
            Element[] e = proj.GetGlobalProjectile<ElementProj>().element;
            if (target.GetGlobalNPC<ElementNPC>().weak != null)
            {
                foreach (Element w in target.GetGlobalNPC<ElementNPC>().weak)
                {
                    if (e.Contains(w))
                        weak++;
                }
            }
            weakened = weak;

            int resist = 0;
            if (target.GetGlobalNPC<ElementNPC>().resist != null)
            {
                foreach (Element r in target.GetGlobalNPC<ElementNPC>().resist)
                {
                    if (e.Contains(r))
                        resist++;
                }
            }
            resisted = resist;
        }
	}
}
