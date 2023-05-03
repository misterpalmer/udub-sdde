using Sddex = Sdde.Collections.Generic;


namespace Sdde.Collections.Generic.Tests.Unit;

public class FlightPathTests
{
    private readonly ITestOutputHelper output;

    public FlightPathTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void AddPathWithDistance_DequeueWithDuplicate_SortedByShortestPath()
    {
        // Arrange
        var items = new List<(TravelDistance Distance, (string Departure, string Arrival) Flight)>
        {
            (new TravelDistance(7), (Departure: "Seattle", Arrival: "Bozeman")),
            (new TravelDistance(6), (Departure: "Bozeman", Arrival: "Denver")),
            (new TravelDistance(20), (Departure: "Bozeman", Arrival: "Dallas")),
            (new TravelDistance(20), (Departure: "Dallas", Arrival: "New York City")),
            (new TravelDistance(3), (Departure: "Bozeman", Arrival: "Salt Lake City")),
            (new TravelDistance(14), (Departure: "Denver", Arrival: "Dallas")),
            (new TravelDistance(2), (Departure: "Dallas", Arrival: "Salt Lake City")),
            (null!, (Departure: "London", Arrival: "London"))
        };

        var expect = new List<(string, string)>
        {
            (items[7].Flight.Departure, items[7].Flight.Arrival),
            (items[6].Flight.Departure, items[6].Flight.Arrival),
            (items[4].Flight.Departure, items[4].Flight.Arrival),
            (items[1].Flight.Departure, items[1].Flight.Arrival),
            (items[0].Flight.Departure, items[0].Flight.Arrival),
            (items[5].Flight.Departure, items[5].Flight.Arrival),
            (items[2].Flight.Departure, items[2].Flight.Arrival),
            (items[3].Flight.Departure, items[3].Flight.Arrival)
        };

        var queue = PriorityQueue.Create(trip => trip.Distance,
            items,
            TravelDistance.ShortestFlightDistance.Comparer);
        List<(string Departure, string Arrival)> result = new();

        // Act
        while (!queue.IsEmpty) result.Add(queue.Dequeue().Flight);

        // Assert
        queue.IsEmpty.Should().BeTrue();
        result.Should().BeEquivalentTo(expect);
    }

    public class TravelDistance
    {
        public TravelDistance(int distance)
        {
            Distance = distance;
        }

        public int Distance { get; set; }

        public class ShortestFlightDistance : Comparer<TravelDistance>
        {
            public static ShortestFlightDistance Comparer { get; } = new();

            public override int Compare(TravelDistance? x, TravelDistance? y)
            {
                var result = (x?.Distance ?? 0) - (y?.Distance ?? 0);
                return result;
            }
        }
    }
}
