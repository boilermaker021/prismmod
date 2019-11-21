using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace prismmod.Mounts
{
    public class ApatheticCloud : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = BuffType<Buffs.ApatheticCloud>();
            mountData.usesHover = true;
            mountData.heightBoost = 30;
            mountData.fallDamage = 0.5f;
            mountData.runSpeed = 10f;
            mountData.dashSpeed = 10f;
            mountData.flightTimeMax = 600;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 20;
            mountData.acceleration = 0.5f;
            mountData.jumpSpeed = 10f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 5;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 0;
            mountData.bodyFrame = 3;
            mountData.yOffset = 13;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 0;
            mountData.standingFrameDelay = 0;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 5;
            mountData.runningFrameDelay = 22;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 5;
            mountData.flyingFrameDelay = 5;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 5;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 5;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }
    }
}