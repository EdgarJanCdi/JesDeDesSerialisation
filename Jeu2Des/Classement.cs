using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    // On a sortie la class Classement pour déléguer les tâches et sérialiser
    [DataContract]
    [Serializable]
    public abstract class Classement
    {
        [DataMember]
        public List<Entree> listDEntrees;

        public Classement()
        {
            listDEntrees = new List<Entree>();
        }

        public void AjouterEntree(string nom, int score)
        {
            listDEntrees.Add(new Entree(nom, score));
        }

        public void TopN()
        {
            listDEntrees.Sort();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(listDEntrees[i]); 
            }
        }

        public abstract void Load();
       

        public abstract void Save();
       

        public override string ToString()
        {
            return "Le classemenet " + listDEntrees;
        }
    }
}
