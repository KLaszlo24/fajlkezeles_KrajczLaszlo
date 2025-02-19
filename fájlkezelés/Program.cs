﻿using System.Data;

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


			Console.WriteLine();
			Console.WriteLine("8. feladat");

			LegnagyobbHarom(karakterek.ToList());


			Console.WriteLine();
			Console.WriteLine("9. feladat");
            Console.WriteLine("Rangsorolva életrő és erő alapján");

			RangsorKarak(karakterek);


            Console.WriteLine();
            Console.WriteLine("10. feladat");

            Csata(karakterek,4,30);
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
            Console.WriteLine("Aki elérték az 51es erőt: ");
			bool szinteleres = false;
			for (int i = 0; i < karakterek.Count; i++)
			{
				if (karakterek[i].Ero > 50)
				{
					szinteleres = true;
					Console.WriteLine($"{karakterek[i].Nev} elérte az erősséget");
				}
				else
				{
					szinteleres = false;
                    Console.WriteLine($"{karakterek[i].Nev} nem érte el az erősséget");
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

		//7.feladat nem kell


		static void LegnagyobbHarom(List<Karakter> karakterek)
		{
			for (int i = 0; i < karakterek.Count - 1; i++)
			{
				for (int j = i + 1; j < karakterek.Count; j++)
				{

					
					if (karakterek[i].SzintesEro > karakterek[j].SzintesEro)
					{
						Karakter valt = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = valt;
					}
				}
			}
            Console.WriteLine("A legjobb három: ");
            for (int i = 0;i < 3; i++)
			{
                Console.WriteLine(karakterek[i]);
            }
		}





		static void Kombinacio(List<Karakter> karakterek)
		{
			foreach(var item in karakterek)
			{
                Console.WriteLine(item.Kombinacio);
            }
		}


		static void RangsorKarak(List<Karakter> karakterek)
		{
			for (int i = 0; i < karakterek.Count - 1; i++)
			{
				for (int j = i + 1; j < karakterek.Count; j++)
				{
					if (karakterek[i].Kombinacio > karakterek[j].Kombinacio)
					{
						Karakter valt = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = valt;
					}
				}
			}
			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}
		}

		static void Csata(List<Karakter> karakterek, int ellenszint, int ellenero)
		{
            Console.WriteLine("A csata eredményei:");

			for (int i = 0;	i < karakterek.Count; i++)
			{
				if (karakterek[i].Szint>ellenszint && karakterek[i].Ero > ellenero)
				{
					Console.WriteLine($"{karakterek[i].Nev} sikeresen átvészelte a csatát");
				}
				else
				{
                    Console.WriteLine($"{karakterek[i].Nev} meghalt a csata során");
				}
			}
		}



	}
}

