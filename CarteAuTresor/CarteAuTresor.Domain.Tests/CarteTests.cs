using CarteAuTresor.Domain.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;


namespace CarteAuTresor.Domain.Tests
{
    public class CarteTests
    {
        const int _nbCasesEnLargeurAttendus = 3;
        const int _nbCasesEnHauteurAttendus = 4;

        [Fact]
        public void LesDimensionsDeLaCarteSontDefiniesDansLeFichierDEntree()
        {
            // Arrange
            var fichierDEntree = TestsHelpers.InitFichierDEntree(_nbCasesEnLargeurAttendus, _nbCasesEnHauteurAttendus);

            // Act
            var carte = new Carte(fichierDEntree);
            // Assert
            carte.NbCasesEnLargeur.Should().Be(_nbCasesEnLargeurAttendus);
            carte.NbCasesEnHauteur.Should().Be(_nbCasesEnHauteurAttendus);
        }

        [Fact]
        public void LaCarteDeLaMadreDeDiosEstDeFormeRectangulaireComposeDeCases()
        {
            // Arrange
            var fichierDEntree = TestsHelpers.InitFichierDEntree(_nbCasesEnLargeurAttendus, _nbCasesEnHauteurAttendus);
            // Act
            var carte = new Carte(fichierDEntree);
            // Assert
            carte.Cases.Length.Should().Be(12);
            carte.Cases[0, 0].Should().BeOfType<Plaine>();
        }

        [Fact]
        public void LesCasesSontNumeroteesDOuestEnEstEtDeNordEnSudEnCommencantParZero()
        {
            // Arrange
            var fichierDEntree = TestsHelpers.InitFichierDEntree(_nbCasesEnLargeurAttendus, _nbCasesEnHauteurAttendus);
            // Act
            var carte = new Carte(fichierDEntree);
            // Assert
            carte.Cases[1, 1].Position.Abscisse.Should().Be(1);
            carte.Cases[1, 1].Position.Ordonnee.Should().Be(1);

            carte.Cases[0, 1].Position.Abscisse.Should().Be(0);
            carte.Cases[0, 1].Position.Ordonnee.Should().Be(1);

            carte.Cases[1, 0].Position.Abscisse.Should().Be(1);
            carte.Cases[1, 0].Position.Ordonnee.Should().Be(0);
        }

        [Fact]
        public void AfficherUneCarte2vs2DePlaines()
        {
            // Arrange
            var fichierDEntree = TestsHelpers.InitFichierDEntree(2, 2);
            var carte = new Carte(fichierDEntree);
            // Act
            var affichage = carte.ToString();
            // Assert
            foreach (var caseCourrante in carte.Cases)
            {
                caseCourrante.Should().BeOfType<Plaine>();
            }
            affichage.Should().Be(".\t.\n.\t.\n");
        }

        [Fact]
        public void AfficherUneCarte3vs4AvecDesMontagnesEtDesTresors()
        {
            // Arrange
            var carte = TestsHelpers.InitCarte();
            // Act
            var affichage = carte.ToString();
            // Assert
            affichage.Should().Be(
                ".\t.\t.\n" + 
                ".\tM\t.\n" +
                ".\t.\tM\n" +
                "T(2)\tT(1)\t.\n");
        }
                
        
    }
}
