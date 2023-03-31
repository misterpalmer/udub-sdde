using FluentAssertions;
using Sddex = Sdde.Collections.Generic;
using Sdde.DataStructures.Tests.Unit.Data;


namespace Sdde.Collections.Generic.Tests.Unit;

public class PriorityQueueTests
{
    private readonly ITestOutputHelper output;
    public PriorityQueueTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void AirportNames()
    {
        // Arrange
        var items = new List<(PriorityNode Priority, (string Departure, string Destination) Flight)>()
        {
            (new PriorityNode(7),(Departure: "Seattle", Destination: "Bozeman")) ,
            (new PriorityNode(6),(Departure: "Bozeman", Destination: "Denver")),
            (new PriorityNode(20),(Departure: "Bozeman", Destination: "Dallas")),
            (new PriorityNode(3),(Departure: "Bozeman", Destination: "Salt Lake City")),
            (new PriorityNode(14),(Departure: "Denver", Destination: "Dallas")),
            (new PriorityNode(2),(Departure: "Dallas", Destination: "Salt Lake City")),
            (null!, (Departure: "London", Destination: "London"))
        };

        var expect = new List<(string, string)>()
        {
            ( items[6].Flight.Departure, items[6].Flight.Destination ),
            ( items[5].Flight.Departure, items[5].Flight.Destination ),
            ( items[3].Flight.Departure, items[3].Flight.Destination ),
            ( items[1].Flight.Departure, items[1].Flight.Destination ),
            ( items[0].Flight.Departure, items[0].Flight.Destination ),
            ( items[4].Flight.Departure, items[4].Flight.Destination ),
            ( items[2].Flight.Departure, items[2].Flight.Destination ),
        };

        var queue = Sddex.PriorityQueue.Create(items, i => i.Priority, PriorityNode.PriorityNodeComparer.Instance);
        List<(string Departure, string Destination)> result = new();

        // Act
        while (!queue.IsEmpty)
        {
            result.Add(queue.Dequeue().Flight);
        }

        // Assert
        queue.IsEmpty.Should().BeTrue();
        result.Should().BeEquivalentTo(expect);
    }

    public class PriorityNode
    {
        public int Priority { get; set; }
        
        public PriorityNode(int priority)
        {
            this.Priority = priority;
        }

        public class PriorityNodeComparer : Comparer<PriorityNode>
        {
            public static PriorityNodeComparer Instance { get; } = new PriorityNodeComparer(); 
            public override int Compare(PriorityNode x, PriorityNode y)
            {
                var result = (x?.Priority ?? 0) - (y?.Priority ?? 0);
                return result;
            }
        }
    }
}

