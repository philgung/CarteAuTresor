using CarteAuTresor.Domain;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CarteAuTresor.Infrastructure.Tests
{
    public class ParserTests
    {

        [Fact]
        public void ParseUneCarte()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] { "C​ - 3 - 4" });
            // Assert
            fichierDEntree.NbCasesEnLargeurDeLaCarte.Should().Be(3);
            fichierDEntree.NbCasesEnHauteurDeLaCarte.Should().Be(4);
        }

        [Fact]
        public void ParseUneMontagne()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] { "M - 1 - 0" });
            // Assert
            fichierDEntree.Montagnes.Should().HaveCount(1);
            fichierDEntree.Montagnes.First().Position.Abscisse.Should().Be(1);
            fichierDEntree.Montagnes.First().Position.Ordonnee.Should().Be(0);
        }

        [Fact]
        public void ParseDeuxMontagnes()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] { "M - 1 - 0", "M​ - 2 - 1" });
            // Assert
            fichierDEntree.Montagnes.Should().HaveCount(2);
            fichierDEntree.Montagnes.First().Position.Abscisse.Should().Be(1);
            fichierDEntree.Montagnes.First().Position.Ordonnee.Should().Be(0);
            fichierDEntree.Montagnes.Last().Position.Abscisse.Should().Be(2);
            fichierDEntree.Montagnes.Last().Position.Ordonnee.Should().Be(1);
        }

        [Fact]
        public void ParseDeuxTresors()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] { "T​ - 0 - 3 - 2", "T​ - 1 - 3 - 3" });
            // Assert
            fichierDEntree.Tresors.Should().HaveCount(2);
            fichierDEntree.Tresors.First().Position.Abscisse.Should().Be(0);
            fichierDEntree.Tresors.First().Position.Ordonnee.Should().Be(3);
            fichierDEntree.Tresors.First().NombreDeTresors.Should().Be(2);
            fichierDEntree.Tresors.Last().Position.Abscisse.Should().Be(1);
            fichierDEntree.Tresors.Last().Position.Ordonnee.Should().Be(3);
            fichierDEntree.Tresors.Last().NombreDeTresors.Should().Be(3);
        }

        [Fact]
        public void ParseUnAventurier()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] { "A​ - Lara - 1 - 1 - S - AADADAGGA" });
            // Assert
            fichierDEntree.Aventuriers.Should().HaveCount(1);
            fichierDEntree.Aventuriers.First().Position.Abscisse.Should().Be(1);
            fichierDEntree.Aventuriers.First().Position.Ordonnee.Should().Be(1);
            fichierDEntree.Aventuriers.First().Orientation.ToString().Should().Be("Sud");
            fichierDEntree.Aventuriers.First().Nom.Should().Be("Lara");
            fichierDEntree.Aventuriers.First().Parcours.Should().BeEquivalentTo(new char[] { 'A', 'A', 'D', 'A', 'D', 'A', 'G', 'G', 'A' });
        }

        [Fact]
        public void ParseUneQueteComplete()
        {
            // Arrange
            var parser = new Parser();
            // Act
            var fichierDEntree = parser.Parse(new string[] {"# Début fichier d'entrée", "C​ - 3 - 4", "M​ - 1 - 0", "M​ - 2 - 1", "T​ - 0 - 3 - 2", "T​ - 1 - 3 - 3", "A​ - Lara - 1 - 1 - S - AADADAGGA" });
            // Assert
            fichierDEntree.NbCasesEnLargeurDeLaCarte.Should().Be(3);
            fichierDEntree.NbCasesEnHauteurDeLaCarte.Should().Be(4);
            fichierDEntree.Montagnes.Should().HaveCount(2);
            fichierDEntree.Tresors.Should().HaveCount(2);
            fichierDEntree.Aventuriers.Should().HaveCount(1);
            
        }
    }
}
