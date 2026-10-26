using LocalMetaheuristic;

int pocetZakaznikov = 5;
int pocetDistribucnychCentier = 5;
const string cestaSuborFinxneNaklady = "C:\\Users\\Admin\\source\\repos\\LocalMetaheuristic\\LocalMetaheuristic\\Data\\Cvic5_lokHeur_F.txt";
const string cestaSuborVariabilneNaklady = "C:\\Users\\Admin\\source\\repos\\LocalMetaheuristic\\LocalMetaheuristic\\Data\\Cvic5_lokHeur_C.txt";

int[,] variabilneNaklady = new int[pocetZakaznikov, pocetDistribucnychCentier];
List<int> fixneNaklady = new List<int>();

var suborFixneNaklady = new StreamReader(cestaSuborFinxneNaklady);
var suborVariabilneNaklady = new StreamReader(cestaSuborVariabilneNaklady);

for (int i = 0; i < pocetZakaznikov; i++)
{
    for (int j = 0; j < pocetDistribucnychCentier; j++)
    {
        variabilneNaklady[i, j] = int.Parse(suborVariabilneNaklady.ReadLine());
    }
}

for (int i = 0; i < pocetDistribucnychCentier; i++)
{
    fixneNaklady.Add(int.Parse(suborFixneNaklady.ReadLine()));
}

var metaH = new MetaH(pocetZakaznikov, pocetDistribucnychCentier);
metaH.SetFixneNaklady(fixneNaklady);
metaH.SetVariabilneNaklady(variabilneNaklady);

metaH.VyberNahodnehoKandidata();
metaH.VypocitajVariabilneNaklady();
metaH.VypisUcelovuFunkciu();