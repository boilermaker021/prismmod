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
            /*int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("Reserved Prismmod Test Space", delegate (GenerationProgress progress)
                {
                    progress.Message = "Test Code Here ;)";


                }));
            }*/

            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("Generate  Structures", delegate (GenerationProgress progress)
                {
                    progress.Message = "Importing Fish People";
                    //int operation;
                    int x;
                    //if (Main.rand.NextBool())
                    //{
                    x = 60;
                    //operation = -1;
                    //}
                    /*else
                    {
                        x = 0;
                        operation = 1;
                    }*/

                    int activeBlock = TileID.Glass;

                    for (int xCoord = 59; xCoord < 72; xCoord++)
                    {
                        for (int yCoord = Main.spawnTileY-80; yCoord < Main.spawnTileY + 120; yCoord++)
                        {
                            Tile tile = Framing.GetTileSafely(xCoord, yCoord);
                            tile.ClearTile();
                            if ((xCoord == 59 || xCoord == 71) && (Framing.GetTileSafely(58, yCoord).liquid <=2 || Framing.GetTileSafely(72, yCoord).liquid <= 2))
                            {
                                WorldGen.PlaceTile(xCoord, yCoord, activeBlock);
                            }
                        }
                    }

                        activeBlock = ModContent.TileType<Tiles.Blox.MoistChiseledStone>();

                        int y = (int)Main.spawnTileY + 109;


                        for (int i = 0; i < 10; i++)
                        {
                            WorldGen.PlaceTile(x + i + 1, y, activeBlock);
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            WorldGen.PlaceTile(x, y + i, activeBlock);
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            WorldGen.PlaceTile(x + 10, y + i, activeBlock);
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            WorldGen.PlaceTile(x + i, y + 10, activeBlock);
                        }

                    
                }));
                
                
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            waterTown = tileCounts[ModContent.TileType<Tiles.Blox.MoistChiseledStone>()]; //update with custom mod block
        }
    }


}