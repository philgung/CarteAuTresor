using FluentAssertions;
using System;
using System.Linq;
using Xunit;


namespace CarteAuTresor.Domain.Tests
{
    public class CarteTests
    {
        // Carte
        // Une carte est de forme rectangulaire composé de case
        // Une carte est défini par un fichier d'entrée
        // Une carte possède un nombre de case en largeur et un nombre de case en hauteur hauteur
        // Sur une carte, les cases sont numérotées d'ouest en est, et de nord en sud en commençant par zéro

        // Case
        // Sur une case on peut y trouver des plaines, des montagnes, des trésors et des aventuriers
        // Un trésor, un aventurier ne peuvent se situer dans une case occupé par une montagne
        // Une case peut contenir plusieurs trésors
        // Afficher une carte
        
        // Aventurier
        // Un aventurier est caractérisé par sa position sur la carte et son orientation
        // Il ne peut se déplacer que d'une case à la fois dans la direction définie par son orientation
        // Il peut changer d'orientation en pivotant à 90° vers la droite ou vers la gauche
        // Il débute son parcours avec une orientation et une séquence de mouvement prédéfinies
        // Il ne peut traverser une case montagne
        // Si l'aventurier est bloqué par une montagne, il poursuit l'exécution de la séquence
        // Si l'aventurier passe par dessus une case Trésor, il ramasse un trésor présent sur la case. 
        // Si la case contient 2 trésors, l'aventurier devra quitter la case puis revenir sur celle-ci afin de ramasser le 2ème trésor
        // Il ne peut y avoir qu'un aventurier à la fois sur une case
        // Les mouvements des aventuriers sont évalués tour par tour
        // En cas de conflit entre mouvements sur un même tour c'est l'ordre d'apparition de l'aventurier dans le fichier qui donne la priorité des mouvements

        // Parcours
        // Position sur la carte
        // Traverser !
        // Séquence de mouvement

        [Fact]
        public void LesDimensionsDeLaCarteSontDefiniesDansLeFichierDEntree()
        {
            // Arrange
            int nbCasesEnLargeurAttendus = 3, nbCasesEnHauteurAttendus = 4;

            var fichierDEntree = new FichierDEntree
            {
                NbCasesEnLargeurDeLaCarte = nbCasesEnLargeurAttendus,
                NbCasesEnHauteurDeLaCarte = nbCasesEnHauteurAttendus
            };

            // Act
            var carte = new Carte(fichierDEntree);
            // Assert
            carte.NbCasesEnLargeur.Should().Be(nbCasesEnLargeurAttendus);
            carte.NbCasesEnHauteur.Should().Be(nbCasesEnHauteurAttendus);
        }

        [Fact]
        public void LaCarteDeLaMadreDeDiosEstDeFormeRectangulaireComposeDeCases()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void LesCasesSontNumeroteesDOuestEnEstEtDeNordEnSudEnCommencantParZero()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
