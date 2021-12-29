using System;
using System.Collections.Generic;

namespace algorithms_on_graphs
{
	 class Program
	 {
			private static List<char> Names = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
			private static List<string> answers = new List<string>();
			private static List<char> answer = new List<char>();
			private static Graph graph;

			public static void Main()
			{
				 // ГРАФ 1
				 graph = new Graph(5, Names);
				 
				 graph.EDIT_Е('A', 'B', '6');
				 graph.EDIT_Е('A', 'D', '7');
				 graph.EDIT_Е('B', 'C', '2');
				 graph.EDIT_Е('C', 'A', '3');
				 graph.EDIT_Е('C', 'E', '8');
				 graph.EDIT_Е('D', 'B', '2');
				 graph.EDIT_Е('D', 'C', '5');
				 graph.EDIT_Е('D', 'E', '9');
				 graph.EDIT_Е('D', 'A', '8');
				 graph.EDIT_Е('E', 'A', '8');

				 // Вывод введенного графа на консоль
				 graph.PrintGraph();

				 // Нахождение всех простых путей для графа
				 findPaths();

				 // Вывод всех простых путей
				 Console.WriteLine("\tВСЕ ПРОСТЫЕ ПУТИ ДЛЯ ВВЕДЕННОГО ГРАФА\n");
				 for (int i = 0; i < answers.Count; i++)
				 {
						if (i != 0 && answers[i][0] != answers[i - 1][0])
							 Console.WriteLine("\n");
						Console.Write(answers[i] + ", ");
				 }
				 Console.ReadKey();
			}

			public static void findPaths()
			{
				 for (int i = 1; i < graph.matrixLength; i++)
				 {
						adjacentPaths(i, Names, answer);
				 }
			}

			public static void adjacentPaths(int i, List<char> names, List<char> answer)
			{
				 char vertex = Names[i - 1];

				 List<char> names1 = new List<char>();
				 names1.AddRange(names);

				 List<char> answer1 = new List<char>();
				 answer1.AddRange(answer);

				 answer1.Add(vertex);
				 names1.Remove(vertex);

				 int counter = 0;

				 for (int j = graph.FIRST(vertex); j > 0; j = graph.NEXT(vertex, j))
				 {
						if (names1.Contains(graph.VERTEX(vertex, j)))
						{
							 counter ++;
							 adjacentPaths(j, names1, answer1);
						}
				 }

				 // Если все вершины, которые связаны с текущей уже были посещены, но текущая вершина считается последней
				 if (counter == 0)
				 {
						string final_answer = "";
						foreach (char letter in answer1)
						{
							 final_answer += letter;
						}
						answers.Add(final_answer);
				 }
			}
	 }
}
