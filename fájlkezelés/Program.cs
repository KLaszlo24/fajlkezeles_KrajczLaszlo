namespace fájlkezelés
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];
			Beolvasas("karakterek.txt", karakterek);
			//bin --> debug --> net8

			foreach(var item in karakterek)
			{
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("2. feladat");

            Legtobb(karakterek);

            Console.WriteLine();
            Console.WriteLine("3. feladat");

			AtlagSzint(karakterek);


			Console.WriteLine();
			Console.WriteLine("4. feladat");

			EroRendez(karakterek);

			Console.WriteLine();
			Console.WriteLine("5. feladat");

			NagyobbE(karakterek);


			Console.WriteLine();
			Console.WriteLine("6. feladat");

			KarakterStats(karakterek,5);
		}

		static void Beolvasas(string fajlnev, List<Karakter> karakterek )
		{
			StreamReader sr = new(fajlnev);  //be tud olvasni fájlokat, szövegeket

			string[] sorok = File.ReadAllLines(fajlnev);

			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(";");

				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}

			
		}
		static void Legtobb(List<Karakter> karakterek)
		{
			Karakter valtozo = karakterek[0];
			for (int i = 1; i < karakterek.Count; i++)
			{
				if (valtozo.Eletero < karakterek[i].Eletero)
				{
					valtozo = karakterek[i];
				}
			}
				Console.WriteLine($"Legmagasabb életerővel rendelkező karakter: {valtozo.Nev}, {valtozo.Szint}, {valtozo.Ero}");
		}

		static void AtlagSzint(List<Karakter> karakterek)
		{
			float atlag = 0;

			for (int i = 0; i < karakterek.Count; ++i)
			{
				atlag += karakterek[i].Szint;
			}


            Console.WriteLine(atlag/karakterek.Count);
        }

		static void EroRendez(List<Karakter> karakterek)
		{
			for (int i = 0;i < karakterek.Count-1; i++)
			{
				for (int  j = i+1; j<karakterek.Count; j++)
				{
					if (karakterek[i].Ero > karakterek[j].Ero)
					{
						Karakter valt = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = valt;
					}
				}
			}
			foreach(var item in karakterek)
			{
				Console.WriteLine(item);
            }
		}

		static void NagyobbE(List<Karakter> karakterek)
		{
			for (int i =0; i<karakterek.Count; i++)
			{
				if (karakterek[i].Ero > 50)
				{
					Console.WriteLine(karakterek[i]);
                }
			}
		}

		static void KarakterStats(List<Karakter> karakterek, int szint)
		{
            Console.WriteLine($"A nagyobb szintek {szint}-nél: ");

			for (int i = 0; i < karakterek.Count; i++)
			{
				if (karakterek[i].Szint > szint)
				{
                    Console.WriteLine(karakterek[i]);
                }
			}
		}
	}
}

