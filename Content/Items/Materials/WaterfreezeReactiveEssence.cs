using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Materials
{
    public class WaterfreezeReactiveEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 25;
            ItemID.Sets.ItemNoGravity[Type] = true;
    	}
		public override void SetDefaults()
		{
            Item.rare = ModContent.RarityType<TOTABlue>();
            Item.value = Item.sellPrice(gold: 5);
            Item.maxStack = 9999;
    	}
	}
}