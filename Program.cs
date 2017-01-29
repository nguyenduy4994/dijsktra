using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dijsktra
{
    class Program
    {
        static int MAX = 100000;
        static int[,] graph;
        static int[] prev;
        static int[] dist;
        static int[] visited;
        static int source, des;

        static void Main(string[] args)
        {
            Program.Read();

            Console.WriteLine("Start Dijstra");
            Program.Dijsktra();

            Console.ReadLine();
        }

        static void Read()
        {
            StreamReader reader = new StreamReader("F:/solution/Old/dijsktra/dijsktra/graph.txt");
            string _str = reader.ReadLine();

            int n = int.Parse(_str);
            graph = new int[n, n];
            prev = new int[n];
            dist = new int[n];
            visited = new int[n];

            _str = reader.ReadLine();
            string[] _tmp = _str.Split(' ');

            source = int.Parse(_tmp[0]);
            des = int.Parse(_tmp[1]);

            int i = 0;
            while (!reader.EndOfStream)
            {
                _str = reader.ReadLine();
                _tmp = _str.Split(' ');
                for (int j = 0; j < n; j++)
                {
                        graph[i, j] = int.Parse(_tmp[j]);
                }
                i++;
            }

            for (i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Dijsktra()
        {   
            int n = graph.GetLength(0);
            int i;

            for (i = 0; i < n; i++)
            {
                dist[i] = MAX;
                prev[i] = source;
                visited[i] = 0;
            }

            dist[source] = 0;
            visited[source] = 1;

            int start = source;
            while (start != des)
            {
                for (i = 0; i < n; i++)
                {
                    if(visited[i] == 0 && graph[start, i] > 0 && dist[i] > graph[start, i] + dist[start])
                    {
                        dist[i] = graph[start, i] + dist[start];
                        prev[i] = start;
                    }
                }

                int min = MAX;
                for (i = 0; i < n; i++)
                {
                    if (dist[i] < min && visited[i] == 0)
                    {
                        min = dist[i];
                        start = i;
                    }
                }

                visited[start] = 1;
            }

            int dinh = des;
            Console.Write("{0} <- ", dinh);

            while (dinh != source)
            {
                dinh = prev[dinh];
                Console.Write("{0} <- ", dinh);
            }
        }
    }
}
