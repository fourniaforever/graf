using System;
using System.IO;

namespace grafy
{
    class Program
    {
        static void DemonstrationWorkingWithClass()
        {
            Graph Graf = new Graph("input.txt");
            object[] Names = { "Techologicheskiy", "Narvskaya" };
            int[] Weights = { 120, 120 };

            object[] NewStops = { "Sadovaya/Sennaya/Spasskaya" };
            //Graf.AddEdgeWeight("Baltiyskaya", Names, Weights);

            //Graf.AddVertex("Baltiyskaya", "Baltiyskaya");
            Graf.AddEdge("Teatralnaya", NewStops);
          //  Graf.AddVertex("Frunzenskaya", Names[0]);

            Graf.DeleteVertex("Pushkinskaya/Zvenigorovskaya", "Vitebskiy_vokzal");

            Graf.PrintToFile("output.txt");
        }
        static void TheAdjacencyListLA1()
        {
            Graph gr = new Graph("input.txt");
            //   var v1 = gr.GetInwardNeighbours("Sadovaya/Sennaya/Spasskaya");
            var v2 = gr.GetInwardNeighbours("Pushkinskaya/Zvenigorovskaya");
            using (StreamWriter output = new StreamWriter("newoutput.txt"))
            {
                foreach (var item in v2)
                {
                    output.WriteLine("{0}", item.Key);
                }
            }
        }
        static void TheAdjacencyListLA2()
        {
            Graph gr = new Graph("input.txt");
            var v1 = gr.GetInwardNeighbours("Sadovaya/Sennaya/Spasskaya");
            var v2 = gr.GetInwardNeighbours("Pushkinskaya/Zvenigorovskaya");
            using (StreamWriter output = new StreamWriter("newoutput.txt"))
            {
                output.WriteLine("Полустепень захода данной вершины = {0}", v1.Count);
                output.WriteLine("Полустепень захода данной вершины = {0}", v2.Count);
            }
        }
        static void TheAdjacencyListLB()
        {
            Graph gr1 = new Graph("input.txt");
            Graph gr2 = new Graph("input2.txt");
            gr1.Merger(gr1, gr2);
        }
        static void Going1()
        {
            Graph gr = new Graph("input.txt");
            var nodes = gr.GetNodeNames();
            object start = "Sadovaya/Sennaya/Spasskaya";
            foreach (var node in nodes)
            {
                int temp = gr.FindPaths(start, node).Count;
                if(!Equals(start,node))
                { 
                    Console.WriteLine(node.ToString() + " " + temp.ToString());
                }
            }
            Console.ReadKey();
        }
        static void Going2()
        {
            Graph graph = new Graph("input.txt");
            var gr = graph.FindPathLengthsBFS("Sadovaya/Sennaya/Spasskaya");
            
            foreach (var node in gr)
            {
               
                Console.WriteLine("{0} {1}(ребер)", node.Key, node.Value);
            }
        }
        static void Boruvka()
        {
            Graph gr = new Graph("input.txt");
            Graph T = gr.BuildSpanningTree();
            T.PrintToFile("newnewoutput.txt");
        }
        static void Going2Dijk()
        {
            Graph graph = new Graph("input.txt");
            var gr = graph.DoDijkstra("Sadovaya/Sennaya/Spasskaya");
            foreach (var node in gr)
            {
                Console.WriteLine("{0} {1}", node.Key, node.Value);
            }
        }
        static void task4b()
        {
            Graph gr1 = new Graph("input.txt");
            foreach (object name in gr1.GetNodeNames())
            {
                var temp = gr1.DoBellman(name);
                foreach (var item in temp)
                {
                    Console.WriteLine("{0}  {1}  {2}",name.ToString(),item.Key ,item.Value);
                }
            }
        }
        static void task4c()
        {
            Graph gr1 = new Graph("input.txt");

            var temp = gr1.DoBellman("Sadovaya/Sennaya/Spasskaya");
            var temp1 = gr1.DoBellman("Pushkinskaya/Zvenigorovskaya");
         
            Console.WriteLine("{0}",temp["Techologicheskiy"]);
            Console.WriteLine("{0}", temp1["Techologicheskiy"]);       
        }
        static void Flow()
        {
            Graph gr = new Graph("input.txt");
            Console.WriteLine( "{0}",Graph.DoEdmondsKarp(gr, "Sadovaya/Sennaya/Spasskaya", "Pushkinskaya/Zvenigorovskaya"));
        }
        static void Main()
        {
            //DemonstrationWorkingWithClass();
            //TheAdjacencyListLA1();
            //TheAdjacencyListLA2();
            //TheAdjacencyListLB();
            //Going1();
            //Going2();
            //Boruvka();
            //Going2Dijk();
            //task4b();
            //task4c();
            Flow();
          
        }
    }
}
