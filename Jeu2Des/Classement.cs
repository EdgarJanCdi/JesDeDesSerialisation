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
        //{
        //    if (File.Exists("sauveBinary.txt") && File.Exists("sauveXML.xml"))
        //    {
        //        // Désérialisation en Binary
        //        Stream fichier = File.OpenRead("sauveBinary.txt");
        //        BinaryFormatter serializerBinary = new BinaryFormatter();
        //        Object objBinary = serializerBinary.Deserialize(fichier);

        //        //L'objet récupéré doit être casté dans sa classe pour qu'on puisse accéder à ces méthodes
        //        Console.WriteLine(objBinary);
        //        // Je prend que l'atribut listDEntrees d'objet et je l'affect à this.listDEntrees
        //        this.listDEntrees = ((Classement)objBinary).listDEntrees;
        //        fichier.Close();


        //        // Désérialisation en XML
        //        Stream FichierXml = File.OpenRead("sauveXML.xml");
        //        XmlSerializer serializXml = new XmlSerializer(typeof(Classement));
        //        Object objXml = serializXml.Deserialize(FichierXml);
        //        Console.WriteLine("Objet récupéré par désérialisation Xml " + objXml);
        //        this.listDEntrees = ((Classement)objXml).listDEntrees;
        //        FichierXml.Close();


        //        // Désérialisation en JSON
        //        Stream fichierJson = File.OpenRead("sauveJson.json");
        //        DataContractJsonSerializer serializerJson = new DataContractJsonSerializer(typeof(Classement));
        //        Object objJson = serializerJson.ReadObject(fichierJson);// ReadObject permet la désérialisation en JSON
        //        this.listDEntrees = ((Classement)objJson).listDEntrees;
        //        fichierJson.Close();

        //    }
        //}

        public abstract void Save();
        //{
        //        // Sérialisation en Binary
        //        Stream fichierBinary = File.Create("sauveBinary.txt");
        //        BinaryFormatter serializerBinary = new BinaryFormatter();
        //        serializerBinary.Serialize(fichierBinary, this);
        //        fichierBinary.Close();

        //        // Sérialisation en XML
        //        // Pour serialisé en XML les propriétés doivent être public
        //        Stream FichierXml = File.Create("sauveXML.xml");
        //        XmlSerializer serializerXml = new XmlSerializer(typeof(Classement));
        //        serializerXml.Serialize(FichierXml, this);
        //        FichierXml.Close();

        //        // Sérialisation en JSON
        //        Stream fichierJson = File.Create("sauveJson.json");
        //        DataContractJsonSerializer serializerJson = new DataContractJsonSerializer(typeof(Classement));
        //        serializerJson.WriteObject(fichierJson, this);
        //        fichierJson.Close();


        //}

        public override string ToString()
        {
            return "Le classemenet " + listDEntrees;
        }
    }
}
