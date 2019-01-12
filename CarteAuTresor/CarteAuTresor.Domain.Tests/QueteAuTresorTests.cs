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
            var lara = TestsHelpers.CreateLara(new Position(1, 0));
            var aventurier2 = new Aventurier("John", new Position(2, 3), Orientation.Est, "");
            var aventurier3 = new Aventurier("Paul", new Position(0, 0), Orientation.Sud, "");
            // Act
            quete.SInscrit(lara);
            quete.SInscrit(aventurier2);
            quete.SInscrit(aventurier3);
            // Assert
            quete.OrdreDePassage.First().Value.Should().Be(lara);
            quete.OrdreDePassage.Last().Value.Should().Be(aventurier3);
        }

        [Fact]
        public void UnAventurierNePeutEtrePositionnerSurUneMontagne()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var lara = TestsHelpers.CreateLara(new Position(1,1));
            // Act

            // Assert
            quete.Invoking(x => x.SInscrit(lara)).Should().Throw<CarteAuTresorDomainException>().WithMessage("Un aventurier ne peut se positionner sur une montagne (1, 1).");
        }

        [Fact]
        public void UnAventurierNePeutSeDeplacerQueDUneCaseALaFoisDansLaDirectionDefinieParSonOrientation()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var initialPosition = new Position(0, 1);
            var lara = TestsHelpers.CreateLara(initialPosition);
            quete.SInscrit(lara);
            // Act

            quete.LAventurierAvance(lara);

            // Assert
            lara.Position.Abscisse.Should().Be(0);
            lara.Position.Ordonnee.Should().Be(0);
            quete.Carte.Cases.Case(initialPosition).Aventurier.Should().BeNull();
            quete.Carte.Cases.Case(lara.Position).Aventurier.Should().NotBeNull();
            quete.Carte.Cases.Case(lara.Position).Aventurier.Should().Be(lara);

        }

        [Fact]
        public void UnAventurierNePeutPasTraverserUneMontagne()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var initialPosition = new Position(0, 1);
            var lara = TestsHelpers.CreateLara(initialPosition);
            quete.SInscrit(lara);
            lara.TourneADroite();
            // Act
            quete.LAventurierAvance(lara);

            // Assert
            lara.Position.Should().Be(initialPosition);
            lara.Orientation.Should().Be(Orientation.Est);
        }

        [Fact]
        public void UnAventurierDebuteSonParcoursAvecUneOrientationEtUneSequenceDeMouvement()
        {
            // Arrange
            var quete = TestsHelpers.InitDeuxiemeQuete();
            var initialPosition = new Position(1, 1);
            var lili = TestsHelpers.CreateLili(initialPosition);

            quete.SInscrit(lili);

            // Act 
            quete.Debute();
            // Assert
            quete.Carte.ToString().Should().Be(
                ".\tM\t.\n" +
                ".\t.\tM\n" +
                ".\t.\t.\n" +
                "A(Lili)\tT(2)\t.\n");
        }

        [Fact]
        public void DeuxAventuriersDebuteLeurParcoursAvecConflit()
        {
            // Arrange
            var quete = TestsHelpers.InitDeuxiemeQuete();
            var initialPosition = new Position(1, 1);
            var lili = TestsHelpers.CreateLili(initialPosition);

            quete.SInscrit(lili);

            // Act 
            quete.Debute();
            // Assert
            quete.Carte.ToString().Should().Be(
                ".\tM\t.\n" +
                ".\t.\tM\n" +
                ".\t.\t.\n" +
                "A(Lili)\tT(2)\t.\n");
        }

        // Si l'aventurier est bloqué par une montagne, il poursuit l'exécution de la séquence
        // Si l'aventurier passe par dessus une case Trésor, il ramasse un trésor présent sur la case. 
        // Si la case contient 2 trésors, l'aventurier devra quitter la case puis revenir sur celle-ci afin de ramasser le 2ème trésor


        // Il ne peut y avoir qu'un aventurier à la fois sur une case
        // Les mouvements des aventuriers sont évalués tour par tour
        // En cas de conflit entre mouvements sur un même tour c'est l'ordre d'apparition de l'aventurier dans le fichier qui donne la priorité des mouvements



    }
}
