using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class AmbulancePriorityQueue
    {
        private List<(AmbulanceBL amb, double dist)> heap = new List<(AmbulanceBL, double)>();

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        public void Enqueue(AmbulanceBL amb, double dist)
        {
            heap.Add((amb, dist));
            int i = heap.Count - 1;
            while (i > 0 && heap[Parent(i)].dist > heap[i].dist)
            {
                var temp = heap[i];
                heap[i] = heap[Parent(i)];
                heap[Parent(i)] = temp;
                i = Parent(i);
            }
        }

        public (AmbulanceBL amb, double dist) Dequeue()
        {
            if (heap.Count == 0) return (null, double.PositiveInfinity);

            var root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            Heapify(0);
            return root;
        }

        private void Heapify(int i)
        {
            int l = Left(i), r = Right(i), smallest = i;
            if (l < heap.Count && heap[l].dist < heap[smallest].dist) smallest = l;
            if (r < heap.Count && heap[r].dist < heap[smallest].dist) smallest = r;

            if (smallest != i)
            {
                var temp = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = temp;
                Heapify(smallest);
            }
        }
        public (AmbulanceBL amb, double dist) ExtractMin()
        {
            if (heap.Count == 0) return (null, double.PositiveInfinity); 
            var root = heap[0]; 
            heap[0] = heap[heap.Count - 1]; 
            heap.RemoveAt(heap.Count - 1); 
            Heapify(0); 
            return root; 
        }
        public bool IsEmpty() => heap.Count == 0;
    }
}

