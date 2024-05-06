namespace TravelingSalesmanProblem
{
    /// <summary>
    /// test
    /// </summary>
    internal class TSP
    {

        public TSP () { }

        /// <include file="XmlDocs/TSP.xml" path='doc/members/member[@name="PrintRoute"]/*' />
        static protected void PrintRoute (int[] route, int start)
        {
            Console.Write("Route is as follows: " + start + " -> ");
            for (int i = 0; i < route.Length - 1; i++) {
                Console.Write(route[i] - 1 + " -> ");
            }
            Console.Write(start);
        }
        static protected void PrintTravelingCost (int cost)
        {
            Console.Write("Minimum Travel-Cost is : " + cost + "\n");
        }
        /// <include file="XmlDocs/TSP.xml" path='doc/members/member[@name="MatrixRndSym"]/*' />
        static protected int[,] MatrixRndSym (int n, int range)
        {
            int randomInt;
            Random rnd = new Random();
            int[,] symMatrix = new int[n, n];
            for (int i = 0; i < n; i++) {
                for (int j = i; j < n; j++) {
                    randomInt = rnd.Next(1, range);
                    symMatrix[i, j] = randomInt;
                    symMatrix[j, i] = randomInt;
                }
            }
            return symMatrix;
        }
    }
}
