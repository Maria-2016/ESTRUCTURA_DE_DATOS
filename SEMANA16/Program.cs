/*
Proyecto: Resolución práctica - Grafos y métricas de centralidad
Lenguaje: C# (Consola .NET 7+)
Archivo: Program.cs
Descripción: Programa que carga grafos desde archivos de texto (dos ejemplos), visualiza la estructura (lista de adyacencia), permite consultas, calcula métricas de centralidad (grado, centralidad de cercanía, centralidad de intermediación via Brandes, PageRank simple), mide tiempos de ejecución y genera reporte por consola.

Formato de archivo de grafo (ejemplo graph1.txt):
Cada línea representa una arista no dirigida "u v" (enteros o nombres sin espacios), líneas vacías y comentarios (#) se ignoran.
Ejemplo:
# graph1.txt
A B
A C
B C
C D

# graph2.txt
1 2
2 3
3 4
4 1
2 4

Instrucciones para compilar y ejecutar:
- Tener .NET SDK 7+ instalado.
- Crear carpeta, colocar Program.cs y archivos graph1.txt, graph2.txt.
- Desde terminal: dotnet new console -n GrafosApp (opcional)
  y reemplazar Program.cs por este archivo.
- dotnet run --project GrafosApp

Salida:
- El programa lista los nodos y la lista de adyacencia para cada grafo, calcula y muestra las métricas para cada nodo, mide y muestra tiempos de ejecución, y guarda un archivo de reporte "reporte_[graphname].txt".

--- Código ---
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Proyecto: Grafos y métricas de centralidad - C#\n");

        // Archivos de ejemplo (puedes modificarlos o añadir más)
        var graphFiles = new List<string> { "graph1.txt", "graph2.txt" };

        foreach (var file in graphFiles)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"Archivo no encontrado: {file} -> creando ejemplo por defecto.");
                File.WriteAllText(file, GetExampleContent(file));
            }

            Console.WriteLine($"\n--- Procesando: {file} ---");
            var sw = Stopwatch.StartNew();

            var graph = Graph.LoadFromEdgeList(file);

            sw.Stop();
            Console.WriteLine($"Carga: {sw.ElapsedMilliseconds} ms");

            // Reportería: mostrar lista de adyacencia
            Console.WriteLine("\nLista de adyacencia:");
            foreach (var node in graph.Nodes.OrderBy(n => n))
            {
                Console.WriteLine($"{node}: {string.Join(", ", graph.GetNeighbors(node))}");
            }

            // Métricas
            var swMetrics = Stopwatch.StartNew();

            var degree = graph.DegreeCentrality();
            var closeness = graph.ClosenessCentrality();
            var betweenness = graph.BetweennessCentrality();
            var pagerank = graph.PageRank(0.85, 100, 1e-6);

            swMetrics.Stop();
            Console.WriteLine($"\nCálculo de métricas: {swMetrics.ElapsedMilliseconds} ms");

            // Mostrar resultados ordenados por grado descendente
            Console.WriteLine("\nResultados (node | degree | closeness | betweenness | pagerank):");
            foreach (var node in graph.Nodes.OrderByDescending(n => degree[n]))
            {
                Console.WriteLine($"{node} | {degree[node]:F3} | {closeness[node]:F6} | {betweenness[node]:F6} | {pagerank[node]:F6}");
            }

            // Guardar reporte
            var reportPath = $"reporte_{Path.GetFileNameWithoutExtension(file)}.txt";
            using (var w = new StreamWriter(reportPath))
            {
                w.WriteLine($"Reporte para {file}");
                w.WriteLine($"Generado: {DateTime.UtcNow.ToString("u", CultureInfo.InvariantCulture)} UTC\n");
                w.WriteLine("Lista de adyacencia:");
                foreach (var node in graph.Nodes.OrderBy(n => n))
                    w.WriteLine($"{node}: {string.Join(", ", graph.GetNeighbors(node))}");

                w.WriteLine("\nMétricas:");
                w.WriteLine("node,degree,closeness,betweenness,pagerank");
                foreach (var node in graph.Nodes)
                {
                    w.WriteLine($"{node},{degree[node]:F6},{closeness[node]:F6},{betweenness[node]:F6},{pagerank[node]:F6}");
                }
            }

            Console.WriteLine($"Reporte guardado en: {reportPath}");
        }

        Console.WriteLine("\nEjecución finalizada. Presiona Enter para salir.");
        Console.ReadLine();
    }

    static string GetExampleContent(string filename)
    {
        if (filename.Contains("graph1"))
        {
            return "A B\nA C\nB C\nC D\nD E\nE F\nF C\n";
        }
        else
        {
            return "1 2\n2 3\n3 4\n4 1\n2 4\n3 5\n5 6\n6 3\n";
        }
    }
}

// Clase Graph y algoritmos
class Graph
{
    // Usamos diccionario de listas (lista de adyacencia)
    private Dictionary<string, HashSet<string>> adj = new Dictionary<string, HashSet<string>>();

    public IEnumerable<string> Nodes => adj.Keys;

    public void AddEdge(string a, string b)
    {
        if (a == b) return; // evitar bucles
        if (!adj.ContainsKey(a)) adj[a] = new HashSet<string>();
        if (!adj.ContainsKey(b)) adj[b] = new HashSet<string>();
        adj[a].Add(b);
        adj[b].Add(a); // no dirigido
    }

    public IEnumerable<string> GetNeighbors(string node)
    {
        if (!adj.ContainsKey(node)) return Enumerable.Empty<string>();
        return adj[node].OrderBy(x => x);
    }

    public static Graph LoadFromEdgeList(string path)
    {
        var g = new Graph();
        foreach (var raw in File.ReadAllLines(path))
        {
            var line = raw.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.StartsWith("#")) continue;
            var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;
            g.AddEdge(parts[0], parts[1]);
        }
        return g;
    }

    // Degree centrality (normalized by n-1)
    public Dictionary<string, double> DegreeCentrality()
    {
        var res = new Dictionary<string, double>();
        var n = adj.Count;
        foreach (var kv in adj)
        {
            res[kv.Key] = (double)kv.Value.Count / Math.Max(1, n - 1);
        }
        return res;
    }

    // Closeness centrality (normalizada según 1 / sum(distances))
    public Dictionary<string, double> ClosenessCentrality()
    {
        var res = new Dictionary<string, double>();
        var nodes = adj.Keys.ToList();
        foreach (var s in nodes)
        {
            var dist = BFS_Distances(s);
            double sum = 0;
            foreach (var d in dist.Values)
                sum += d;
            if (sum > 0)
                res[s] = (dist.Count > 1) ? (dist.Count - 1) / sum : 0.0; // variante común
            else
                res[s] = 0.0;
        }
        return res;
    }

    private Dictionary<string, int> BFS_Distances(string source)
    {
        var dist = new Dictionary<string, int>();
        var q = new Queue<string>();
        dist[source] = 0;
        q.Enqueue(source);
        while (q.Count > 0)
        {
            var v = q.Dequeue();
            foreach (var w in adj[v])
            {
                if (!dist.ContainsKey(w))
                {
                    dist[w] = dist[v] + 1;
                    q.Enqueue(w);
                }
            }
        }
        return dist;
    }

    // Betweenness centrality: Brandes' algorithm (sin pesos)
    public Dictionary<string, double> BetweennessCentrality()
    {
        var CB = adj.Keys.ToDictionary(k => k, k => 0.0);
        var nodes = adj.Keys.ToList();

        foreach (var s in nodes)
        {
            var S = new Stack<string>();
            var P = adj.Keys.ToDictionary(k => k, k => new List<string>());
            var sigma = adj.Keys.ToDictionary(k => k, k => 0.0);
            var dist = adj.Keys.ToDictionary(k => k, k => -1);

            sigma[s] = 1.0;
            dist[s] = 0;
            var Q = new Queue<string>();
            Q.Enqueue(s);

            while (Q.Count > 0)
            {
                var v = Q.Dequeue();
                S.Push(v);
                foreach (var w in adj[v])
                {
                    if (dist[w] < 0)
                    {
                        dist[w] = dist[v] + 1;
                        Q.Enqueue(w);
                    }
                    if (dist[w] == dist[v] + 1)
                    {
                        sigma[w] += sigma[v];
                        P[w].Add(v);
                    }
                }
            }

            var delta = adj.Keys.ToDictionary(k => k, k => 0.0);
            while (S.Count > 0)
            {
                var w = S.Pop();
                foreach (var v in P[w])
                {
                    delta[v] += (sigma[v] / sigma[w]) * (1 + delta[w]);
                }
                if (w != s)
                    CB[w] += delta[w];
            }
        }

        // Normalización opcional para grafos no dirigidos: dividir por 2
        foreach (var k in CB.Keys.ToList()) CB[k] /= 2.0;
        return CB;
    }

    // PageRank (iterativo, sin manejar grafos dirigidos específicamente — tratamos aristas como enlaces bidireccionales)
    public Dictionary<string, double> PageRank(double damping = 0.85, int maxIter = 100, double tol = 1e-6)
    {
        var nodes = adj.Keys.ToList();
        int n = nodes.Count;
        var pr = nodes.ToDictionary(k => k, k => 1.0 / n);
        var tmp = nodes.ToDictionary(k => k, k => 0.0);

        for (int iter = 0; iter < maxIter; iter++)
        {
            foreach (var v in nodes) tmp[v] = (1 - damping) / n;

            foreach (var v in nodes)
            {
                var neighbors = adj[v];
                if (neighbors.Count == 0) continue;
                double share = damping * pr[v] / neighbors.Count;
                foreach (var w in neighbors)
                    tmp[w] += share;
            }

            double err = 0;
            foreach (var v in nodes)
            {
                err += Math.Abs(tmp[v] - pr[v]);
            }

            foreach (var v in nodes) pr[v] = tmp[v];
            if (err < tol) break;
        }
        return pr;
    }
}

