using Xunit;
using ClassLibrary1.Services;
using ClassLibrary1.Modeles;
using System;
using Modeles.Classes;

public class RendezVousServiceTests
{
    [Fact]
    public void Add_NullRendezVous_ThrowsException()
    {
        // Arrange
        var service = new RendezVousService();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.Add(null));
    }

    [Fact]
    public void CreateRendezVous_DefaultStatut_IsProgramme()
    {
        // Arrange
        var rdv = new RendezVous(1, 1, DateTime.Now);

        // Assert
        Assert.Equal("Programmé", rdv.Statut);
    }
}
