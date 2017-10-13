using Xunit;

namespace Dijkstra.Tests
{
    
    public class HeapTests
    {
        [Fact]
        public void GivenRandomEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Entity>();
            var entity1 = new Entity {Id = 1};
            var entity2 = new Entity {Id = 2};
            var entity3 = new Entity {Id = 3};
            var entity5 = new Entity {Id = 5};
            var entity10 = new Entity {Id = 10};
            var entity20 = new Entity {Id = 20};
            var entity40 = new Entity {Id = 40};
            
            heap.Insert(entity3);
            heap.Insert(entity40);
            heap.Insert(entity2);
            heap.Insert(entity10);
            heap.Insert(entity5);
            heap.Insert(entity1);
            heap.Insert(entity20);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Id == entity1.Id);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Id == entity2.Id);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Id == entity3.Id);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Id == entity5.Id);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Id == entity10.Id);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Id == entity20.Id);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Id == entity40.Id);
        }

        [Fact]
        public void GivenDescendingEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Entity>();
            var entity1 = new Entity { Id = 1 };
            var entity2 = new Entity { Id = 2 };
            var entity3 = new Entity { Id = 3 };
            var entity5 = new Entity { Id = 5 };
            var entity10 = new Entity { Id = 10 };
            var entity20 = new Entity { Id = 20 };
            var entity40 = new Entity { Id = 40 };

            heap.Insert(entity40);
            heap.Insert(entity20);
            heap.Insert(entity10);
            heap.Insert(entity5);
            heap.Insert(entity3);
            heap.Insert(entity2);
            heap.Insert(entity1);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Id == entity1.Id);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Id == entity2.Id);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Id == entity3.Id);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Id == entity5.Id);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Id == entity10.Id);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Id == entity20.Id);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Id == entity40.Id);
        }

        [Fact]
        public void GivenAscendingEntity_Heap_CorrectlySievesUp()
        {
            var heap = new Heap<Entity>();
            var entity1 = new Entity { Id = 1 };
            var entity2 = new Entity { Id = 2 };
            var entity3 = new Entity { Id = 3 };
            var entity5 = new Entity { Id = 5 };
            var entity10 = new Entity { Id = 10 };
            var entity20 = new Entity { Id = 20 };
            var entity40 = new Entity { Id = 40 };

            heap.Insert(entity1);
            heap.Insert(entity2);
            heap.Insert(entity3);
            heap.Insert(entity5);
            heap.Insert(entity10);
            heap.Insert(entity20);
            heap.Insert(entity40);

            var min1 = heap.ExtractMin();
            Assert.True(min1.Id == entity1.Id);
            var min2 = heap.ExtractMin();
            Assert.True(min2.Id == entity2.Id);
            var min3 = heap.ExtractMin();
            Assert.True(min3.Id == entity3.Id);
            var min5 = heap.ExtractMin();
            Assert.True(min5.Id == entity5.Id);
            var min10 = heap.ExtractMin();
            Assert.True(min10.Id == entity10.Id);
            var min20 = heap.ExtractMin();
            Assert.True(min20.Id == entity20.Id);
            var min40 = heap.ExtractMin();
            Assert.True(min40.Id == entity40.Id);
        }
    }
}
