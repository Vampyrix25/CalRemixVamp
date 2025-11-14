using Terraria;
using Terraria.ModLoader;

namespace CalRemix.Content.Buffs
{
    public class MeldSkin : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 22;
        }
    }
}
