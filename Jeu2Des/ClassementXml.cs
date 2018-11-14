using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    [Serializable]
    public class ClassementXml : Classement
    {
        public override void Load()
        {
            if (File.Exists("sauveXML.xml"))
            {
                // Désérialisation en XML
                Stream FichierXml = File.OpenRead("sauveXML.xml");
                XmlSerializer deserializXml = new XmlSerializer(typeof(ClassementXml));
                Object objXml = deserializXml.Deserialize(FichierXml);
                Console.WriteLine("Objet récupéré par désérialisation Xml " + objXml);

                // On ne peut pas modifier la classe dans la class même(peut pas écrir this tout court) 
                this.listDEntrees = ((Classement)objXml).listDEntrees; // L'objet recupéré on cast en Clasement et on prend le propriété listEntrees
                FichierXml.Close();
            }
        }

        public override void Save()
        {
            // Sérialisation en XML
            // Pour serialisé en XML les propriétés doivent être public
            Stream FichierXml = File.Create("sauveXML.xml");
            XmlSerializer serializerXml = new XmlSerializer(typeof(ClassementXml));
            serializerXml.Serialize(FichierXml, this);
            FichierXml.Close();
        }
    }
}
