﻿namespace TravelingSalesmanProblem
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
        //static protected int[,] MatrixFromFile (string relativeFilePath)
        //{

        //    string path = GetFullPathByFilename(relativeFilePath);
        //    using (StreamReader reader = new StreamReader(path)) {

        //        string text = reader.ReadToEnd();
        //        string[] lines = text.Split(Environment.NewLine);
        //        int[,] symMatrix = new int[lines.Length, lines.Length];
        //        for (int i = 0; i < lines.Length; i++) {

        //            for (int j = i; j < lines.Length; j++) {
        //                int tempint = ;
        //                symMatrix[i, j] = randomInt;
        //                symMatrix[j, i] = randomInt;
        //            }
        //        }
        //    }

        //}

        /// <include file="XmlDocs/TSP.xml" path='doc/members/member[@name="GetFullPathByFilename"]/*' />
        static private string GetFullPathByFilename (string fileName)
        {
            //Console.WriteLine("" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\"+fileName);
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\" + fileName;
        }
    }
}
