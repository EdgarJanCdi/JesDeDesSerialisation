using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    [DataContract]
    public class Entree : IComparable<Entree>
    {
        [DataMember]
        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        [DataMember]
        private int _Score;
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        // Constructeur
        public Entree(string nom, int score)
        {
            this._Nom = nom;
            this._Score = score;
        }
        public Entree()
        {

        }

        public override string ToString()
        {
            return "Le nom : " + _Nom + ", le Score : " + _Score;
        }

        public int CompareTo(Entree other)
        {
            if (other != null)
            {
                // Multiplier par -1 permet de trier par l'ordre decroissant
                return this._Score.CompareTo(other._Score) * -1;
            }
            return 1;
        }
    }
}
