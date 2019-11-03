using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace prismmod
{
    public class PrismWorld : ModWorld
    {
        public static int waterTown = 0;
        public bool killedGargantuanTortoise;
        public bool downedPrismachine;

        public override void Initialize()
        {
            killedGargantuanTortoise = false;
            downedPrismachine = false;
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = killedGargantuanTortoise;
            flags[1] = downedPrismachine;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            killedGargantuanTortoise = flags[0];
            downedPrismachine = flags[1];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("IRON CUBE", delegate (GenerationProgress progress)
                {
                    progress.Message = "CUBE";
                    int operation;
                    int x;
                    if (Main.rand.NextBool())
                    {
                        x = (int)Main.maxTilesX;
                        operation = -1;
                    }
                    else
                    {
                        x = 0;
                        operation = 1;
                    }
                    
                    int y = (int)WorldGen.waterLine;

                    for (int i = 0; i < 25; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            
                            WorldGen.PlaceTile(x - i + 1, y - j, TileID.Iron);
                        }
                        
                    }

                    /*for (int i = 0; i < 10; i++)
                    {
                        WorldGen.PlaceTile(x, y + i - 30, TileID.Iron);
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        WorldGen.PlaceTile(x + 10, y + i - 30, TileID.Iron);
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        WorldGen.PlaceTile(x + i, y + 10 - 30, TileID.Iron);
                    }

                }));
                
             }*/
             }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
        }
    }


}