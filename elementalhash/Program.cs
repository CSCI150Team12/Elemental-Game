using System;
using System.Collections;
using System.Threading;

namespace elementalhash
{
    class Program
    {
        static Hashtable elemhash;

        public static void Main(string[] args)
        {
            elemhash = new Hashtable(); // elemhash contains all of our spells + collectible combinations (should be 2 bytes long 
                                        // using the first byte for collectibles, second to hold our 16 or so spells)
            int PintVal = 0 ;                 // input from keys
            int CintVal = 0 ;
            int TempVal = 0; 
            int Total = 0;              // keeps track of total numbers 
            int complexity = 0; // will be used for complexity counter
            ConsoleKeyInfo cki = new ConsoleKeyInfo(); // will be used to read keys 
            //complexity 1
            elemhash.Add(0x0000, "Water");// note this is 00 00 00 00 + 1 byte collectible 
            elemhash.Add(0x0100, "Air");// 00 00 00 01 + collectible
            elemhash.Add(0x0200, "Fire");// 00 00 00 10 + collectible 
            elemhash.Add(0x0300, "Earth");// 00 00  00 11 + collectible 
            // complexity 2 
            elemhash.Add(0x4600, "fireball");
            elemhash.Add(0x4900, "fireball");
            elemhash.Add(0x4700, "Dust");
            elemhash.Add(0x4D00, "Dust");
            elemhash.Add(0x4800, "Steam");
            elemhash.Add(0x4200, "Steam");
            elemhash.Add(0x4B00, "Magma");
            elemhash.Add(0x4E00, "Magma");
            elemhash.Add(0x4300, "Mud");
            elemhash.Add(0x4C00, "Mud");
            elemhash.Add(0x4400, "Ice");// 00 00 01 00 + collectible air + water
            elemhash.Add(0x4100, "Ice"); // water + air 
            // complexity 3 
            elemhash.Add(0xD100, "Snow");// complexity 3 , ice + air
            elemhash.Add(0xC500, "Snow");// ice + air 
            elemhash.Add(0xD900, "2fireball");
            elemhash.Add(0xE500, "2fireball");
            elemhash.Add(0xFD00, "Tornado");
            elemhash.Add(0xF500, "Tornado");
            elemhash.Add(0xE100, "Fog");
            elemhash.Add(0xC900, "Fog");
            elemhash.Add(0xED00, "Stone");
            elemhash.Add(0xF900, "Stone");
            elemhash.Add(0xCD00, "Dirt");
            elemhash.Add(0xF100, "Dirt");


            for (int i = 0; i <0xFFFF; i++)     // ensuring every key contains a value, not sure if necessary 
            {
                if(!elemhash.ContainsKey(i))
                     elemhash.Add(i, "empty");
            }

           /*foreach (DictionaryEntry entry in elemhash) // for checking ALL key/values 
            {
                Console.WriteLine("Key : " + entry.Key + " / Value: " + entry.Value);
            }*/
            do // logic 1 start
            {
                Console.WriteLine("\nPress a key to display; x quits");
                while (Console.KeyAvailable == false)
                {
                   
                    if (complexity == 0)
                    {
                        PintVal = CintVal;
                        Thread.Sleep(5);
                    }
                    else if (complexity == 1)
                    {
                        PintVal = CintVal << 2 | 0x4000;
                        TempVal = PintVal;
                        Thread.Sleep(5);
                    }
                    else if (complexity == 2)
                    {

                        PintVal = CintVal << 4 | 0x8000 | TempVal;
                        Thread.Sleep(5);
                    }
                    else if (complexity == 3)
                    {
                        CintVal = 0;
                        PintVal = 0;
                        complexity = 0;
                        TempVal = 0;
                        Thread.Sleep(5);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        Thread.Sleep(50);
                        complexity = 0;
                    }
                }
                cki = Console.ReadKey(true);
                CintVal = cki.KeyChar;
                CintVal = CintVal - 49;
                CintVal = CintVal << 8;
                Total = CintVal + PintVal;
                complexity++; 
                if (elemhash.ContainsKey(Total))
                Console.WriteLine("Found : " + elemhash[Total] + " total is : " + Total); 
                
            } while (cki.Key != ConsoleKey.X); // end of logic 1

        }
    }
}
