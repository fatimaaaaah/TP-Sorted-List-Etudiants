using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList listeEtudiants = new SortedList();

            Console.Write("Combien d'étudiants voulez-vous saisir ? ");
            int n = int.Parse(Console.ReadLine());

            // === Saisie des étudiants ===
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Étudiant {i + 1} ---");

                Console.Write("Numéro d’ordre (NO): ");
                int no = int.Parse(Console.ReadLine());

                Console.Write("Prénom : ");
                string prenom = Console.ReadLine();

                Console.Write("Nom : ");
                string nom = Console.ReadLine();

                Console.Write("Note Contrôle Continu (0–20): ");
                double cc = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir (0–20): ");
                double devoir = double.Parse(Console.ReadLine());

                Etudiant etu = new Etudiant()
                {
                    NO = no,
                    Prenom = prenom,
                    Nom = nom,
                    NoteCC = cc,
                    NoteDevoir = devoir
                };

                listeEtudiants.Add(no, etu);
            }

            // === Choix du nombre de lignes par page ===
            int lignesParPage;
            do
            {
                Console.Write("\nNombre de lignes par page (5 à 15) : ");
                lignesParPage = int.Parse(Console.ReadLine());
            }
            while (lignesParPage < 5 || lignesParPage > 15);

            int page = 1;
            int totalPages = (int)Math.Ceiling((double)listeEtudiants.Count / lignesParPage);

            bool continuer = true;

            // === Boucle de navigation ===
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine($"=== PAGE {page}/{totalPages} ===\n");

                int debut = (page - 1) * lignesParPage;
                int fin = Math.Min(debut + lignesParPage, listeEtudiants.Count);

                double totalMoy = 0;

                // === Affichage des étudiants dans la page ===
                for (int i = debut; i < fin; i++)
                {
                    DictionaryEntry entry = (DictionaryEntry)listeEtudiants[i];
                    Etudiant e = (Etudiant)entry.Value;

                    Console.WriteLine(
                        $"NO: {e.NO} | Nom: {e.Nom} | Prénom: {e.Prenom} | CC: {e.NoteCC} | Devoir: {e.NoteDevoir} | Moyenne: {e.Moyenne:F2}"
                    );

                    totalMoy += e.Moyenne;
                }

                Console.WriteLine("\nMoyenne de la classe : " +
                    (totalMoy / listeEtudiants.Count).ToString("F2"));

                // === Navigation ===
                Console.WriteLine("\nOptions :");
                Console.WriteLine("P - Page précédente");
                Console.WriteLine("S - Page suivante");
                Console.WriteLine("Q - Quitter");
                Console.Write("Votre choix : ");

                string choix = Console.ReadLine().ToUpper();

                switch (choix)
                {
                    case "P":
                        if (page > 1) page--;
                        break;

                    case "S":
                        if (page < totalPages) page++;
                        break;

                    case "Q":
                        continuer = false;
                        break;
                }
            }

            Console.WriteLine("\nProgramme terminé.");
        }
    }
}
