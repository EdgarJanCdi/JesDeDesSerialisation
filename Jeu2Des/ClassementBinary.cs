using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    public class ClassementBinary : Classement
    {
        public override void Load()
        {
            if (File.Exists("sauveBinary.txt"))
            {
                // Désérialisation en Binary
                // Pour désérialiser on a la méthode Deserialize de la class BinaryFormatter qui a besoin un objet Stream

                Stream fichierBinary = File.OpenRead("sauveBinary.txt"); // Creation de l'objet Stream
                BinaryFormatter deserializerBinary = new BinaryFormatter(); // Creation de l'objet BinaryFormatter pour poivoir acceder a ses méthodes
                Object objBinary = deserializerBinary.Deserialize(fichierBinary); // Récuperation de deserialisation dans un objet type Object

                //L'objet récupéré doit être casté dans sa classe pour qu'on puisse accéder à ces méthodes
                this.listDEntrees = ((Classement)objBinary).listDEntrees;// Je prend que l'atribut listDEntrees d'objet et je l'affect à this.listDEntrees
                fichierBinary.Close();
            }
        }

        public override void Save()
        {
            // Sérialisation en Binary
            Stream fichierBinary = File.Create("sauveBinary.txt");
            BinaryFormatter serializerBinary = new BinaryFormatter();
            serializerBinary.Serialize(fichierBinary, this);
            fichierBinary.Close();
        }
    }
}
