using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Jeu2Des
{
    [DataContract]
    [Serializable]
    public class ClassementJson : Classement
    {
        public override void Load()
        {
            if (File.Exists("sauveJson.json"))
            {
                // Désérialisation en JSON
                Stream fichierJson = File.OpenRead("sauveJson.json");
                DataContractJsonSerializer serializerJson = new DataContractJsonSerializer(typeof(ClassementJson));
                Object objJson = serializerJson.ReadObject(fichierJson);// ReadObject permet la désérialisation en JSON
                this.listDEntrees = ((Classement)objJson).listDEntrees;
                fichierJson.Close();
            }
        }

        public override void Save()
        {
            // Sérialisation en JSON
            Stream fichierJson = File.Create("sauveJson.json");
            DataContractJsonSerializer serializerJson = new DataContractJsonSerializer(typeof(ClassementJson));
            serializerJson.WriteObject(fichierJson, this);
            fichierJson.Close();
        }
    }
}
