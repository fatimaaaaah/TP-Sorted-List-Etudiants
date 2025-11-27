using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList listeEtudiants = new SortedList();

            // === Saisie des étudiants ===
            Console.Write("Combien d'étudiants voulez-vous saisir ? ");
            int n = int.Parse(Console.ReadLine());

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
            } while (lignesParPage < 5 || lignesParPage > 15);

            int page = 1;
            int totalPages = (int)Math.Ceiling((double)listeEtudiants.Count / lignesParPage);

            // Calcul de la moyenne globale de la classe
            double moyenneClasse = 0;
            foreach (Etudiant e in listeEtudiants.Values)
                moyenneClasse += e.Moyenne;
            moyenneClasse /= listeEtudiants.Count;

            bool continuer = true;

            // === Boucle de navigation ===
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine($"=== PAGE {page}/{totalPages} ===\n");

                int debut = (page - 1) * lignesParPage;
                int fin = Math.Min(debut + lignesParPage, listeEtudiants.Count);

                // === Affichage du tableau avec en-têtes ===
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,5} | {4,5} | {5,7}",
                    "NO", "Nom", "Prénom", "CC", "Devoir", "Moyenne");
                Console.WriteLine(new string('-', 65));

                // === Affichage des étudiants dans la page ===
                for (int i = debut; i < fin; i++)
                {
                    Etudiant e = (Etudiant)listeEtudiants.GetByIndex(i);

                    Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,5:F1} | {4,5:F1} | {5,7:F2}",
                        e.NO, e.Nom, e.Prenom, e.NoteCC, e.NoteDevoir, e.Moyenne);
                }

                Console.WriteLine("\nMoyenne de la classe : " + moyenneClasse.ToString("F2"));

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
