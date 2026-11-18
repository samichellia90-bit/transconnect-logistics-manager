using Xunit;

namespace TransConnect.Tests
{
    public class TransConnectTests
    {
        private static Graph RoadNetwork()
        {
            Graph graph = new Graph();
            foreach (string city in new[] { "paris", "lyon", "marseille", "bordeaux", "lille" })
            {
                graph.AjouterSommet(city);
            }
            graph.AjouterArete("paris", "lyon", 465);
            graph.AjouterArete("lyon", "marseille", 315);
            graph.AjouterArete("paris", "bordeaux", 584);
            return graph;
        }

        private static Salarie Employee(string nss, string role) =>
            new Salarie(nss, "Nom", "Prenom", new DateTime(1990, 1, 1), "1 rue", "Paris", "a@b.c", "0600000000",
                new DateTime(2020, 1, 1), role, 2500);

        [Fact]
        public void DijkstraSumsEdgesAlongTheShortestPath()
        {
            Graph graph = RoadNetwork();
            Assert.Equal(780, graph.CalculerDistance("paris", "marseille"));
            Assert.Equal(1364, graph.CalculerDistance("marseille", "bordeaux"));
            Assert.Equal(0, graph.CalculerDistance("lyon", "lyon"));
        }

        [Fact]
        public void DijkstraPrefersACheaperDetourOverADirectEdge()
        {
            Graph graph = RoadNetwork();
            graph.AjouterArete("paris", "marseille", 900);
            Assert.Equal(780, graph.CalculerDistance("paris", "marseille"));
        }

        [Fact]
        public void UnreachableCityHasInfiniteDistance()
        {
            Assert.Equal(double.MaxValue, RoadNetwork().CalculerDistance("paris", "lille"));
        }

        [Fact]
        public void OrgChartFindsAndRemovesAnEmployeeBelowTheRoot()
        {
            Organigramme chart = new Organigramme();
            chart.EmbaucherSalarie(Employee("01", "Directeur général"));
            chart.EmbaucherSalarie(Employee("02", "Chef d'équipe"), chart.DirecteurGeneral);
            chart.EmbaucherSalarie(Employee("03", "Chauffeur"), chart.TrouverSalarie(chart.DirecteurGeneral, "02"));

            Assert.Equal("Chauffeur", chart.TrouverSalarie(chart.DirecteurGeneral, "03").Donnee.Poste);

            chart.LicencierSalarie(chart.DirecteurGeneral, "03");
            Assert.Null(chart.TrouverSalarie(chart.DirecteurGeneral, "03"));
        }
    }
}
