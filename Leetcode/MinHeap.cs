using System;
namespace Leetcode
{
    /// <summary>
    /// Top item will always be the minimum
    /// </summary>
    public class MinHeap
    {
        private readonly int[] data;

        public MinHeap(int size)
        {
            this.data = new int[size + 1];
        }

        public MinHeap(int size, int[] array)
        {
            this.data = new int[size + 1];
            this.data[0] = array.Length;
            Array.Copy(array, 0, this.data, 1, array.Length);
            Heapify();
        }

        public void Insert(int val)
        {
            if (this.Size() < this.data.Length)
            {
                // put the val in the end
                this.data[0]++;
                int currIdx = this.Size();
                this.data[currIdx] = val;

                // adjust the heap
                SiftUp (currIdx);
            }
        }

        private void Heapify()
        {
            int firstNonLeafNodeIdx = this.Size() / 2;
            while (firstNonLeafNodeIdx > 0)
            {
                SiftDown(firstNonLeafNodeIdx);
                firstNonLeafNodeIdx--;
            }
        }

        public int? Delete()
        {
            int? result = null;

            if (this.Size() > 0)
            {
                result = this.data[1];

                // swap top and last items
                Swap(this.data, 1, this.data[0]);

                // delete the last item
                this.data[this.Size()] = 0;
                this.data[0]--;

                // adjust the heap
                SiftDown(1);
            }
            return result;
        }

        public int Top() => this.data[1];

        public int Size() => this.data[0];

        private void Swap(int[] array, int idx1, int idx2)
        {
            int temp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = temp;
        }

        private void SiftUp(int idx)
        {
            int currIdx = idx / 2;
            while (currIdx > 0)
            {
                int smallerChildIdx = GetSmallerChildIdx(currIdx);

                if (this.data[currIdx] > this.data[smallerChildIdx])
                {
                    Swap(this.data, currIdx, smallerChildIdx);
                    currIdx /= 2;
                }
                else
                    break;
            }
        }

        private void SiftDown(int idx)
        {
            if (this.Size() > 0)
            {
                int currIdx = idx;
                while (currIdx <= this.Size() && !IsLeafNode(currIdx))
                {
                    int smallerChildIdx = GetSmallerChildIdx(currIdx);

                    if (this.data[currIdx] > this.data[smallerChildIdx])
                    {
                        Swap(this.data, currIdx, smallerChildIdx);
                        currIdx = smallerChildIdx;
                    }
                    else
                        break;
                }
            }
        }

        private int GetSmallerChildIdx(int currIdx)
        {
            int leftChildIdx = GetLeftChildIdx(currIdx);
            int rightChildIdx = GetRightChildIdx(currIdx);

            int leftChildVal =
                leftChildIdx <= this.Size()
                    ? this.data[leftChildIdx]
                    : int.MaxValue;
            int rightChildVal =
                rightChildIdx <= this.Size()
                    ? this.data[rightChildIdx]
                    : int.MaxValue;

            int smallerChildIdx;

            if (leftChildVal < rightChildVal)
                smallerChildIdx = leftChildIdx;
            else
                smallerChildIdx = rightChildIdx;

            return smallerChildIdx;
        }

        private bool IsLeafNode(int idx) => idx > this.Size() / 2;

        private int GetLeftChildIdx(int idx) => idx * 2;

        private int GetRightChildIdx(int idx) => idx * 2 + 1;
    }
}
