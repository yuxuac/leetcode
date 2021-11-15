using System;

namespace LEETCODE
{
    public class MaxHeap
    {
        private int[] data;

        public MaxHeap(int size)
        {
            this.data = new int[size + 1];
        }

        public MaxHeap(int size, int[] array)
        {
            this.data = new int[size + 1];
            this.data[0] = array.Length;
            Array.Copy(array, 0, this.data, 1, array.Length);
            Heapify (array);
        }

        public void Heapify(int[] array)
        {
            int firstNonLeafNodeIdx = this.Size() / 2;
            while (firstNonLeafNodeIdx > 0)
            {
                SiftDown (firstNonLeafNodeIdx);
                firstNonLeafNodeIdx--;
            }
        }

        public void Insert(int val)
        {
            if (this.Size() < this.data.Length)
            {
                // Put the val in the end
                this.data[0]++;
                int currIdx = this.Size();
                this.data[currIdx] = val;

                // adjust the heap
                SiftUp (currIdx);
            }
        }

        public void Swap(int[] array, int idx1, int idx2)
        {
            int temp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = temp;
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

        public void SiftUp(int idx)
        {
            int currIdx = idx / 2;
            while (currIdx > 0)
            {
                int largerChildIdx = GetLargerChildIdx(currIdx);

                if (this.data[currIdx] < this.data[largerChildIdx])
                {
                    Swap(this.data, currIdx, largerChildIdx);
                    currIdx = currIdx / 2;
                }
                else
                    break;
            }
        }

        public void SiftDown(int idx)
        {
            if (this.Size() > 0)
            {
                int currIdx = idx;
                while (currIdx <= this.Size() && !IsLeafNode(currIdx))
                {
                    int largerChildIdx = GetLargerChildIdx(currIdx);

                    if (this.data[currIdx] < this.data[largerChildIdx])
                    {
                        Swap(this.data, currIdx, largerChildIdx);
                        currIdx = largerChildIdx;
                    }
                    else
                        break;
                }
            }
        }

        private int GetLargerChildIdx(int currIdx)
        {
            int leftChildIdx = GetLeftChildIdx(currIdx);
            int rightChildIdx = GetRightChildIdx(currIdx);

            int leftChildVal =
                leftChildIdx <= this.Size()
                    ? this.data[leftChildIdx]
                    : int.MinValue;
            int rightChildVal =
                rightChildIdx <= this.Size()
                    ? this.data[rightChildIdx]
                    : int.MinValue;

            int LargerChildIdx = -1;

            if (leftChildVal > rightChildVal)
                LargerChildIdx = leftChildIdx;
            else
                LargerChildIdx = rightChildIdx;

            return LargerChildIdx;
        }

        private bool IsLeafNode(int idx) => idx > this.Size() / 2;

        private int GetLeftChildIdx(int idx) => idx * 2;

        private int GetRightChildIdx(int idx) => idx * 2 + 1;

        public int Top() => this.data[1];

        public int Size() => this.data[0];
    }
}
