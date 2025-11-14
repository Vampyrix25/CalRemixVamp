using Terraria;
using Terraria.ModLoader;

namespace CalRemix.Content.Buffs
{
    public class CobaltSkin : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 14;
        }
    }
}
