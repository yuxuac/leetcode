namespace leetcode
{
    // UNION-FIND : Check graph connectivity fast
    // https://en.wikipedia.org/wiki/Disjoint-set_data_structure
    public class UF
    {
        // # of nodes
        private int count;
        // record each node's parent
        private int[] parents;
        // record # of child nodes of each node
        private int[] size;

        public UF(int n)
        {
            this.count = n;

            // initialize parents, for each node, set its parent to itself
            this.parents = new int[n];
            this.size = new int[n];
            for(int i = 0; i < n; i++)
            {
                this.parents[i] = i;
                this.size[i] = 1;
            }
                
        }

        // Time: O(1)
        // connect p and q
        public void Union(int p, int q)
        {
            // find root nodes
            int rootP = FindRoot(p);
            int rootQ = FindRoot(q);

            // same root - p and q are connected
            if(rootP == rootQ) return;

            // q as root
            if(this.size[rootQ] > this.size[rootP])
            {
                // set rootQ as rootP's parent
                this.parents[rootP] = rootQ;
                // add rootQ(# of nodes) and rootP(# of nodes)
                this.size[rootQ] += this.size[rootP];
            }
            // p as root
            else
            {
                // set rootP as rootQ's parent
                this.parents[rootQ] = rootP;
                // add rootQ(# of nodes) and rootP(# of nodes)
                this.size[rootP] += this.size[rootQ];
            }
           
            // reduce # of trees
            this.count--;
        }

        // Time: O(1)
        // check if p and q are connected
        public bool Connected(int p, int q)
        {
            return FindRoot(p) == FindRoot(q);
        }

        // Time: O(1)
        // return # of connected components
        public int Count()
        {
            return this.count;
        }

        // Time: O(1) - Constant
        private int FindRoot(int x)
        {
            while(parents[x] != x)
            {
                // compress path - set x's parent to x' grandparent
                parents[x] = parents[parents[x]];
                x = parents[x];
            }
                
            return x;
        }
    }
}