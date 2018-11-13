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
                Stream fichier = File.OpenRead("sauveBinary.txt");
                BinaryFormatter serializerBinary = new BinaryFormatter();
                Object objBinary = serializerBinary.Deserialize(fichier);

                //L'objet récupéré doit être casté dans sa classe pour qu'on puisse accéder à ces méthodes
                // Je prend que l'atribut listDEntrees d'objet et je l'affect à this.listDEntrees
                this.listDEntrees = ((Classement)objBinary).listDEntrees;
                fichier.Close();
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
