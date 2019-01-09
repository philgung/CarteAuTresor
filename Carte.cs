namespace CarteAuTresor.Domain
{
    public class Carte
    {
        public Carte(FichierDEntree fichierDEntree)
        {
            NbCasesEnLargeur = fichierDEntree.NbCasesEnLargeurDeLaCarte;
            NbCasesEnHauteur = fichierDEntree.NbCasesEnHauteurDeLaCarte;
        }

        public object NbCasesEnLargeur { get; internal set; }
        public object NbCasesEnHauteur { get; internal set; }
    }
}