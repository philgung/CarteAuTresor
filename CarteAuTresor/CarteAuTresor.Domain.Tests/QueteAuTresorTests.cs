using CarteAuTresor.Domain.Tests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarteAuTresor.Domain.Tests
{
    public class QueteAuTresorTests
    {
        [Fact]
        public void LorsqueDesAventuriersSInscriveAUneQueteEstDefiniUnOrdreDePassage()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var aventurier1 = new Aventurier("Lara", new Position(1, 0), Orientation.Nord);
            var aventurier2 = new Aventurier("John", new Position(2, 3), Orientation.Est);
            var aventurier3 = new Aventurier("Paul", new Position(0, 0), Orientation.Sud);
            // Act
            quete.SInscrit(aventurier1);
            quete.SInscrit(aventurier2);
            quete.SInscrit(aventurier3);
            // Assert
            quete.OrdreDePassage.First().Value.Should().Be(aventurier1);
            quete.OrdreDePassage.Last().Value.Should().Be(aventurier3);
        }

        

        [Fact]
        public void UnAventurierNePeutEtrePositionnerSurUneMontagne()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var aventurier = new Aventurier("Lara", new Position(1, 1), Orientation.Nord);
            // Act

            // Assert
            quete.Invoking(x => x.SInscrit(aventurier)).Should().Throw<CarteAuTresorDomainException>().WithMessage("Un aventurier ne peut se positionner sur une montagne (1, 1).");
        }

        [Fact]
        public void UnAventurierNePeutSeDeplacerQueDUneCaseALaFoisDansLaDirectionDefinieParSonOrientation()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var initialPosition = new Position(0, 1);
            var aventurier = new Aventurier("Lara", initialPosition, Orientation.Nord);
            quete.SInscrit(aventurier);
            // Act

            quete.LAventurierAvance(aventurier);

            // Assert
            aventurier.Position.Abscisse.Should().Be(0);
            aventurier.Position.Ordonnee.Should().Be(0);
            quete.Carte.Cases.Case(initialPosition).Aventurier.Should().BeNull();
            quete.Carte.Cases.Case(aventurier.Position).Aventurier.Should().NotBeNull();
            quete.Carte.Cases.Case(aventurier.Position).Aventurier.Should().Be(aventurier);

        }

        // Il débute son parcours avec une orientation et une séquence de mouvement prédéfinies
        // Il ne peut traverser une case montagne
        // Si l'aventurier est bloqué par une montagne, il poursuit l'exécution de la séquence
        // Si l'aventurier passe par dessus une case Trésor, il ramasse un trésor présent sur la case. 
        // Si la case contient 2 trésors, l'aventurier devra quitter la case puis revenir sur celle-ci afin de ramasser le 2ème trésor


        // Il ne peut y avoir qu'un aventurier à la fois sur une case
        // Les mouvements des aventuriers sont évalués tour par tour
        // En cas de conflit entre mouvements sur un même tour c'est l'ordre d'apparition de l'aventurier dans le fichier qui donne la priorité des mouvements



    }
}
