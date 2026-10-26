using System;
using System.Collections.Generic;
using System.Text;

namespace LocalMetaheuristic
{
    internal class MetaH
    {
        public List<int> fixneNaklady = new List<int>(); //fi
        public int[,] variabilné = new int[0, 0]; //cij
        public int[,] ucelovaFunkcia = new int[0, 0]; //fij + cij
        public int aktualnaHodnotaUcelovejFunkcie = 0;
        public int teplota;

        public int[] kandidatyNaUmiestnenie = new int[0]; 

        public MetaH(int pocetZakaznikov, int pocetDistribucnychCentier)
        {
            variabilné = new int[pocetZakaznikov, pocetDistribucnychCentier];
            ucelovaFunkcia = new int[pocetZakaznikov, pocetDistribucnychCentier];
            this.teplota = Random.Shared.Next(1, 100);
            kandidatyNaUmiestnenie = new int[pocetDistribucnychCentier];
        }   
        
        public void SetFixneNaklady(List<int> noveFixneNaklady)
        {
            fixneNaklady = noveFixneNaklady;
        }

        public void SetVariabilneNaklady(int[,] noveVariabilneNaklady)
        {
            variabilné = noveVariabilneNaklady;
        }

        public void SetTeplota(int novaTeplota)
        {
            teplota = novaTeplota;
        }

        public void VyberNahodnehoKandidata()
        {
            Random random = new Random();
            int index = random.Next(kandidatyNaUmiestnenie.Length);
            int vybranyKandidat = kandidatyNaUmiestnenie[index];
            Console.WriteLine($"Vybraný kandidát na umiestnenie: {vybranyKandidat}");
        }

        public void VypisUcelovuFunkciu()
        {
            Console.WriteLine("Účelová funkcia:");
            for (int i = 0; i < ucelovaFunkcia.GetLength(0); i++)
            {
                for (int j = 0; j < ucelovaFunkcia.GetLength(1); j++)
                {
                    Console.Write(ucelovaFunkcia[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void VypocitajVariabilneNaklady()
        {
            for (int i = 0; i < fixneNaklady.Count; i++)
            {
                for (int j = 0; j < variabilné.GetLength(1); j++)
                {
                    ucelovaFunkcia[i, j] = fixneNaklady[i] + variabilné[i, j];
                }
            }
        }


    }
}
