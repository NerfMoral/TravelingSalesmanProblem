namespace TravelingSalesmanProblem
{
    enum Mode
    {
        FILE, RANDOM
    }
    internal class GreedyTSP : TSP
    {
        public GreedyTSP (Mode mode)
        {
            switch (mode) {
                //case Mode.FILE:
                //    Init(MatrixFromFile("Resources\\Matrix5.txt"));
                //    break;
                case Mode.RANDOM:
                    Init(MatrixRndSym(5, 15));
                    break;
                default:
                    throw new ArgumentException("No new Matrix Generated");
            }

        }

        private void Init (int[,] matrix)
        {
            int sum = 0;
            int j = 0, i = 0;
            int counter = 0;
            int min = int.MaxValue;
            int start = i;

            //always a matrix with NxN dimensions (Adjacent matrix)
            int[,] distances = matrix;

            List<int> visitedRouteList = new List<int>();
            visitedRouteList.Add(0);

            //route is the route of the graph without the first start vertex
            int[] route = new int[distances.GetLength(1)];

            //check if i and j still valid parameters 
            while (i < distances.GetLength(0) && j < distances.GetLength(1) && !(counter >= distances.GetLength(0) - 1)) {

                //not the diagonal and unvisited
                if (j != i && !visitedRouteList.Contains(j)) {
                    //update min distance from current i to j if smaller than last one
                    if (distances[i, j] < min) {
                        min = distances[i, j];
                        //save OR overwrite the current projected Route with the (at the moment) shortest vertex
                        route[counter] = j + 1;
                    }
                }
                j++;

                // if j is the last vertex then add current min to sum and reset min to max int
                // also add the shortest (not current) vertex to the visited Route List
                if (j == distances.GetLength(0)) {
                    sum += min;
                    min = int.MaxValue;
                    visitedRouteList.Add(route[counter] - 1);
                    //reset j
                    j = 0;
                    // set new starting vertex (i) to the ending vertex from the previous path
                    i = route[counter] - 1;
                    counter++;
                }
            }

            // set to the last vertex
            i = route[counter - 1] - 1;

            // last travel is always back to the beginning
            min = distances[i, 0];
            route[counter] = j + 1;

            #region wrongOriginalCode
            //makes no sense because it looks from the last vertex(5) the shortest path but its supposed to travel back to the beginning (0)
            //for (j = 0; j < distances.GetLength(0); j++) {
            //    if ((i != j) && distances[i, j] < min) {
            //        min = distances[i, j];
            //        route[counter] = j + 1;
            //    }
            //}
            #endregion 

            sum += min;

            PrintTravelingCost(sum);
            PrintRoute(route, start);
        }

    }
}
