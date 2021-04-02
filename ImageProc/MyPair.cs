namespace Velociraptor
{
    class MyPair
    {
        int start = 0;
        int end = 0;
        int bound_pos=0;
        bool is_estimated = false;
        public MyPair() { }
        public MyPair(int s, int e, int pos)
        {
            start = s;
            end = e;
            bound_pos = pos;
        }
        public void SetPair(int x1, int x2)
        {
            start = x1;
            end = x2;
        }
        public void SetPairS(int x)
        {
            start = x;
        }
        public void SetPairE(int x)
        {
            end = x;
        }
        public void SetBoundPos(int p)
        {
            bound_pos = p;
        }
        public void SetEstimated()
        {
            is_estimated = true;
        }
        public int GetWidth()
        {
            return end - start;
        }
        public int GetPairS() {
            return start; 
        }
        public int GetPairE()
        {
            return end;
        }
        public int GetBoundPos()
        {
            return bound_pos;
        }
        public bool IsEstimated()
        {
            return is_estimated;
        }
        public override string ToString()
        {
            return start.ToString() + "-" + bound_pos.ToString() + "-" + end.ToString();
        }
    }
}
