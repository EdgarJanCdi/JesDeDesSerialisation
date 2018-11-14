using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{

    /* Le Patern Fabrique/Factory method permet de rendre la class jeu indepandant de ClassepmentXlm, ClassepmentJson, ClassepmentBinary
       la class jeu n'instincie plus les sous-clases de la class Classement */

    public static class FabriqueClassement
    {
        public static Classement CreatClassement(string typeSauvgared)
        {
            string typeMajuscule = typeSauvgared.ToUpper();

            if (typeMajuscule == "XML")
            {
                return new ClassementXml();
            }
            else if (typeMajuscule == "BINARY")
            {
                return new ClassementBinary();
            }
            else if (typeMajuscule == "JSON")
            {
                return new ClassementJson();
            }
            else
            {
                throw new ArgumentException("Impossible de créer un classement en " + typeSauvgared);
            }
        }
    }
}
