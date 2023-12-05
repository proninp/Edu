namespace CodeWars._7kyu
{
    public class SimpleFun42AreSimilar
    {
        public static bool AreSimilar(int[] A, int[] B)
        {
            if (A.Length != B.Length)
                return false;

            int[] p1 = null;
            int[] p2 = null;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    if (p1 is null)
                        p1 = new int[] { A[i], B[i] };
                    else if (p2 is null)
                        p2 = new int[] { A[i], B[i] };
                    else
                        return false;

                    if (p1 != null && p2 != null)
                    {
                        if (p1[0] != p2[1] || p1[1] != p2[0])
                            return false;
                    }
                }
            }
            if (p1 is null ^ p2 is null)
                return false;
            return true;
        }
    }
}
