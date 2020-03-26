using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using prismmod.NPCs.WaterTown;
using prismmod.Tiles.Blox;
using prismmod.Walls;
using static prismmod.PrismHelper;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;

namespace prismmod
{
    internal class PrismWorld : ModWorld
    {
        public static int moistChiseledStoneCount = 0;
        public bool downedGargantuanTortoise;
        public bool downedPrismachine;
        public bool accessedWaterTown;
        public int gatesY;
        public int gatesX;
        public int bsb;

        public override void Initialize()
        {
            downedGargantuanTortoise = false;
            downedPrismachine = false;
            accessedWaterTown = false;
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedPrismachine = downed.Contains("Prismachine");
            downedGargantuanTortoise = downed.Contains("GargantuanTortoise");

            var accessed = tag.GetList<string>("accessed");
            accessedWaterTown = accessed.Contains("WaterTown");
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedPrismachine)
                downed.Add("Prismachine");
            if (downedGargantuanTortoise)
            {
                downed.Add("GargantuanTortoise");
            }

            var accessed = new List<string>();
            if (accessedWaterTown)
                accessed.Add("WaterTown");
            return new TagCompound
            {
                ["downed"] = downed,
                ["accessed"] = accessed
            };
        }


        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedGargantuanTortoise;
            flags[1] = downedPrismachine;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedGargantuanTortoise = flags[0];
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

            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Pots"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("Generate  Water Town", delegate (GenerationProgress progress)
                {

                    int operation=1;
                    bool wtRight;
                    int startXTunnel;
                    int endXBiome;
                    if (WorldGen.dungeonX < Main.maxTilesX / 2)
                    {
                        wtRight = true;
                        operation = -1;
                        startXTunnel = Main.maxTilesX-75;

                    }
                    else
                    {
                        wtRight = false;
                        operation = 1;
                        startXTunnel = 69;
                    }
                    progress.Message = "Finding some Sand";
                    int baseSandBlock = 0;
                    for (int y = 0; y < Main.maxTilesY;y++)
                    {
                        Tile tile = Framing.GetTileSafely(startXTunnel,y);
                        if (tile.active() && tile.liquid == 0)
                        {
                            baseSandBlock = y;
                            break;
                        }
                    }

                    bsb = baseSandBlock;
                    

                    int gateBlock = ModContent.TileType<UnbreakableGate>();
                    bool placedGate = false;//used to check if gateX and gateY should be set
                    int gateY = 0;
                    int gateX;

                    progress.Message = "Tunneling";
                    int activeBlock = ModContent.TileType<CityWall>();

                    /*
                     Step 1- Create Initial Tunnel
                     Step 2- Create gate
                     Step 3- Create Main Biome body
                     Notes:
                     - operation stores left or right (+1 on left, -1 on right), controls direction easily
                     */
                    int tunnelDepth = 35;
                    int tunnelWidth = 9;
                    int endXTunnel = startXTunnel + (operation * tunnelWidth);

                    for (int y = bsb; y<=(bsb+tunnelDepth);y++)//start at base sand block and go until desired tunnel depth has been reached
                    {
                        for (int x = (startXTunnel-operation-operation); x != (endXTunnel+operation); x += operation) 
                        {
                            Framing.GetTileSafely(x, y).ClearTile();
                        }
                        for (int x = (startXTunnel - operation - operation); x != (endXTunnel + operation); x += operation)
                        {
                            if (x == startXTunnel || x == endXTunnel)
                            {
                                WorldGen.PlaceTile(x, y, activeBlock);
                                WorldGen.PlaceTile(x - 1, y, activeBlock);
                                WorldGen.PlaceTile(x + 1, y, activeBlock);
                            }
                        }
                    }

                    for (int x = startXTunnel; x != endXTunnel; x += operation)
                    {
                        WorldGen.PlaceTile(x, bsb, ModContent.TileType<UnbreakableGate>());
                    }



                    List<Point> spawnPoints = new List<Point>();

                    //house drawing
                    /*spawnPoints.Add(PrismHelper.drawBaseFishHouse(leftX+3, topY+30, 15, 15, ModContent.TileType<MoistChiseledStone>(), 'l'));
                    PrismHelper.drawGroundFromWall(leftX + 2, topY + 30, 5, 25, TileID.Stone, 'l');

                    progress.Message = "Importing Fish People";
                    NPC.NewNPC((startXTunnel+endXBiome/2)*16, (Main.spawnTileY + 130)*16,ModContent.NPCType<FishBlue>());*/

                }));
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            moistChiseledStoneCount = tileCounts[ModContent.TileType<Tiles.Blox.CityWall>()]; //Change back to chiseled stone
        }
    }
}