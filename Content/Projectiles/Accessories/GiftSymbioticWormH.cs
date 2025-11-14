using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalRemix.Content.Projectiles.Accessories
{
    public class GiftSymbioticWormH : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.timeLeft = 450;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 2)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 4)
                Projectile.frame = 0;
            int index = Projectile.FindTargetWithLineOfSight(4800);
            if (!index.WithinBounds(Main.maxNPCs))
                return;
            NPC npc = Main.npc[index];
            if (npc != null)
            {
                Vector2 there = npc.Center - Projectile.Center;
                Vector2 steer = (Vector2)Projectile.DirectionTo(npc.Center) * (float)there.Length() * 0.003f;
                Vector2 velo = (Vector2)Projectile.velocity;
                float veloBig = velo.Length();
                Projectile.velocity = velo + steer;


                if (veloBig > 8.5)
                {
                    Projectile.velocity = Projectile.velocity * 0.99f;
                }
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            /*
                if (Projectile.timeLeft < 400)
                {
                    Projectile.StickyProjAI(10);
                }
            }
            */
            //CalamityUtils.HomeInOnNPC(Projectile, true, 2000, 4, 0);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 60);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) => Projectile.ModifyHitNPCSticky(100);
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Rectangle sourceRectangle = new(0, texture.Height / 4 * Projectile.frame, texture.Width, texture.Height / 4);
            Vector2 origin = sourceRectangle.Size() / 2f;
            Color drawColor = Projectile.GetAlpha(new Color(255, 255, 255, 255));
            Main.spriteBatch.Draw(texture, position, sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}