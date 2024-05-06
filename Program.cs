namespace TravelingSalesmanProblem
{
    internal class Program
    {
        static void Main (string[] args)
        {
            int sum = 0;
            int j = 0, i = 0;
            int counter = 0;
            int min = int.MaxValue;
            int start = i;

            int[,] distances ={
                {  -1, 9 ,10 ,11 , 4 , 2},
                {  9 , -1 ,18 ,13 , 6 , 3},
                { 10 ,18 ,-1,12 ,11 , 6},
                { 11 ,13 ,12 ,-1 ,17 , 9},
                {  4 , 6 ,11 ,17 ,-1 ,15},
                {  2 , 3 , 6 , 9 ,15 ,-1  }
            };

            List<int> visitedRouteList = new List<int>();
            visitedRouteList.Add(0);

            //route is the route of the graph without 0
            int[] route = new int[distances.GetLength(1)];

            //check if i and j still valid parameters
            while (i < distances.GetLength(0) && j < distances.GetLength(1)) {

                if (counter >= distances.GetLength(0) - 1) {
                    break;
                }

                //not the diagonal and unvisited
                if (j != i && !(visitedRouteList.Contains(j))) {
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

            // Started from the node where
            // we finished as well.
            Console.Write("Minimum Cost is : ");
            Console.WriteLine(sum);
            PrintRoute(route, start);


        }

        static public void PrintRoute (int[] route, int start)
        {
            Console.Write("Route is as follows: " + start + " -> ");
            for (int i = 0; i < route.Length - 1; i++) {
                Console.Write(route[i] - 1 + " -> ");
            }
            Console.Write(start);
        }

    }
}

