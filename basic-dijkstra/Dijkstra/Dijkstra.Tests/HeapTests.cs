using Xunit;

namespace Dijkstra.Tests
{
    
    public class HeapTests
    {
        [Fact]
        public void GivenRandomEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Node>();
            var entity1 = new Node {Distance = 1};
            var entity2 = new Node {Distance = 2};
            var entity3 = new Node {Distance = 3};
            var entity5 = new Node {Distance = 5};
            var entity10 = new Node {Distance = 10};
            var entity20 = new Node {Distance = 20};
            var entity40 = new Node {Distance = 40};
            
            heap.Insert(entity3);
            heap.Insert(entity40);
            heap.Insert(entity2);
            heap.Insert(entity10);
            heap.Insert(entity5);
            heap.Insert(entity1);
            heap.Insert(entity20);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Distance == entity1.Distance);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Distance == entity2.Distance);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Distance == entity3.Distance);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Distance == entity5.Distance);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Distance == entity10.Distance);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Distance == entity20.Distance);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Distance == entity40.Distance);
        }

        [Fact]
        public void GivenDescendingEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Node>();
            var entity1 = new Node { Distance = 1 };
            var entity2 = new Node { Distance = 2 };
            var entity3 = new Node { Distance = 3 };
            var entity5 = new Node { Distance = 5 };
            var entity10 = new Node { Distance = 10 };
            var entity20 = new Node { Distance = 20 };
            var entity40 = new Node { Distance = 40 };

            heap.Insert(entity40);
            heap.Insert(entity20);
            heap.Insert(entity10);
            heap.Insert(entity5);
            heap.Insert(entity3);
            heap.Insert(entity2);
            heap.Insert(entity1);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Distance == entity1.Distance);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Distance == entity2.Distance);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Distance == entity3.Distance);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Distance == entity5.Distance);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Distance == entity10.Distance);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Distance == entity20.Distance);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Distance == entity40.Distance);
        }

        [Fact]
        public void GivenAscendingEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Node>();
            var entity1 = new Node { Distance = 1 };
            var entity2 = new Node { Distance = 2 };
            var entity3 = new Node { Distance = 3 };
            var entity5 = new Node { Distance = 5 };
            var entity10 = new Node { Distance = 10 };
            var entity20 = new Node { Distance = 20 };
            var entity40 = new Node { Distance = 40 };

            heap.Insert(entity1);
            heap.Insert(entity2);
            heap.Insert(entity3);
            heap.Insert(entity5);
            heap.Insert(entity10);
            heap.Insert(entity20);
            heap.Insert(entity40);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Distance == entity1.Distance);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Distance == entity2.Distance);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Distance == entity3.Distance);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Distance == entity5.Distance);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Distance == entity10.Distance);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Distance == entity20.Distance);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Distance == entity40.Distance);
        }
    }
}
