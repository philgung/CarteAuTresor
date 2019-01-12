using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor.Domain
{
    public class Carte
    {
        public int NbCasesEnLargeur { get; internal set; }
        public int NbCasesEnHauteur { get; internal set; }
        public Case[,] Cases { get; set; }

        public Carte(FichierDEntree fichierDEntree)
        {
            NbCasesEnLargeur = fichierDEntree.NbCasesEnLargeurDeLaCarte;
            NbCasesEnHauteur = fichierDEntree.NbCasesEnHauteurDeLaCarte;
            Cases = new Case[fichierDEntree.NbCasesEnLargeurDeLaCarte, fichierDEntree.NbCasesEnHauteurDeLaCarte];

            PlacerPlaines(fichierDEntree);
            PlacerMontagnes(fichierDEntree.Montagnes);
            PlacerTresors(fichierDEntree.Tresors);
        }

        private void PlacerPlaines(FichierDEntree fichierDEntree)
        {
            for (int ordonnee = 0; ordonnee < fichierDEntree.NbCasesEnHauteurDeLaCarte; ordonnee++)
            {
                for (int abscisse = 0; abscisse < fichierDEntree.NbCasesEnLargeurDeLaCarte; abscisse++)
                {
                    Cases[abscisse, ordonnee] = new Plaine(new Position(abscisse, ordonnee));
                }
            }
        }

        public bool DeplacementAutorise(Aventurier aventurier, Position prochainePosition)
        {
            return prochainePosition.Abscisse >= 0 && prochainePosition.Ordonnee >= 0 &&
                prochainePosition.Abscisse < NbCasesEnLargeur && prochainePosition.Ordonnee < NbCasesEnHauteur &&
                !Cases.EstUneMontagne(prochainePosition) && Cases.Case(prochainePosition).Aventurier == null;
        }

        private void PlacerTresors(IList<Tresor> tresors)
        {
            foreach (var tresor in tresors)
            {
                Cases[tresor.Position.Abscisse, tresor.Position.Ordonnee] = tresor;
            }
        }

        private void PlacerMontagnes(IList<Montagne> montagnes)
        {
            foreach (var montagne in montagnes)
            {
                Cases[montagne.Position.Abscisse, montagne.Position.Ordonnee] = montagne;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            for (int ordonnee = 0; ordonnee < NbCasesEnHauteur; ordonnee++)
            {
                for (int abscisse = 0; abscisse < NbCasesEnLargeur; abscisse++)
                {
                    var caseCourante = Cases[abscisse, ordonnee];
                    sb.Append($"{caseCourante.ToString()}");
                    if (abscisse < NbCasesEnLargeur - 1)
                        sb.Append("\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }

    public static class CarteExtensions
    {
        public static Case Case(this Case[,] cases,  Position position)
        {
            return cases[position.Abscisse, position.Ordonnee];
        }
        public static bool EstUneMontagne(this Case[,] cases, Position position)
        {
            return cases.Case(position) is Montagne;
        }
    }
}