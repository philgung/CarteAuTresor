using CarteAuTresor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Infrastructure
{
    public class Parser
    {
        public FichierDEntree Parse(string[] tableauTexte)
        {
            var fichierDEntree = new FichierDEntree();
            foreach (var texte in tableauTexte)
            {
                if (texte.StartsWith("C"))
                {
                    var texteSplite = texte.Trim().Split('-');
                    int largeur, hauteur;
                    if (int.TryParse(texteSplite[1], out largeur))
                        fichierDEntree.NbCasesEnLargeurDeLaCarte = largeur;
                    if (int.TryParse(texteSplite[2], out hauteur))
                        fichierDEntree.NbCasesEnHauteurDeLaCarte = hauteur;

                }
                else if (texte.StartsWith("M"))
                {
                    var texteSplite = texte.Trim().Split('-');
                    int largeur, hauteur;
                    if (int.TryParse(texteSplite[1], out largeur) && int.TryParse(texteSplite[2], out hauteur))
                        fichierDEntree.AjouterMontagne(new Montagne(new Position(largeur, hauteur)));
                }
                else if (texte.StartsWith("T"))
                {
                    var texteSplite = texte.Trim().Split('-');
                    int largeur, hauteur, nombreDeTresors;
                    if (int.TryParse(texteSplite[1], out largeur) && int.TryParse(texteSplite[2], out hauteur) && int.TryParse(texteSplite[3], out nombreDeTresors))
                        fichierDEntree.AjouterTresor(new Tresor(new Position(largeur, hauteur), nombreDeTresors));
                }
                else if (texte.StartsWith("A"))
                {
                    var texteSplite = texte.Trim().Split('-');
                    int largeur, hauteur;
                    Orientation orientation;
                    switch (texteSplite[4].Trim())
                    {
                        case "N":
                            orientation = Orientation.Nord;
                            break;
                        case "S":
                            orientation = Orientation.Sud;
                            break;
                        case "O":
                            orientation = Orientation.Ouest;
                            break;
                        default:
                        case "E":
                            orientation = Orientation.Est;
                            break;
                    }
                    
                    if (int.TryParse(texteSplite[2], out largeur) && int.TryParse(texteSplite[3], out hauteur))
                        fichierDEntree.AjouterAventurier(new Aventurier(texteSplite[1].Trim(), new Position(largeur, hauteur), orientation, texteSplite[5].Trim()));
                }
            }
            
           

            return fichierDEntree;
        }
    }
}
