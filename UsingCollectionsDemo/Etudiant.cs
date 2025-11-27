using System;

namespace UsageCollections
{
    public class Etudiant
    {
        public int NO { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir { get; set; }

        // Propriété calculée
        public double Moyenne
        {
            get
            {
                return (NoteCC * 0.33) + (NoteDevoir * 0.67);
            }
        }
    }
}
