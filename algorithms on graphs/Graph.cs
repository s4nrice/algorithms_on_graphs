using System;
using System.Collections.Generic;

namespace algorithms_on_graphs
{
	 class Graph
	 {
			private List<List<char>> matrix = new List<List<char>>();
			public int matrixLength;
			private List<char> dictionary = new List<char>();

			public Graph(int matrixSize, List<char> dictionary)
			{
				 matrixLength = matrixSize + 1;

				 this.dictionary.AddRange(dictionary);

				 matrix.Add(new List<char>());
				 matrix[0].Add(' ');

				 for (int i = 0; i < matrixLength - 1; i++)
				 {
						ADD_V(this.dictionary[i]);
				 }
			}

			// FIRST(v) - возвращает индекс первой вершины, смежной с вершиной v.Если вершина v не имеет смежных вершин, то возвращается "нулевая" вершина .
			public int FIRST(char v)
			{
				 for (int i = 1; i < matrixLength; i++)
				 {
						// Находим подходящую указанную вершину
						if (matrix[i][0] == v)
						{
							 // Находим индекс первой смежной с указанной вершиной вершины
							 for (int j = 1; j < matrixLength; j++)
							 {
									if (matrix[i][j] != '0')
									{
										 return j;
									}
							 }
						}
				 }
				 return 0;
			}

			// NEXT(v, i)- возвращает индекс вершины, смежной с вершиной v,
			// следующий за индексом i. Если i — это индекс последней вершины, смежной с вершиной v, то возвращается .
			public int NEXT(char v, int i)
			{
				 for (int a = 1; a < matrixLength; a++)
				 {
						// Находим подходящую указанную вершину
						if (matrix[a][0] == v)
						{
							 // Находим индекс вершины, смежной с указанной вершиной, идущей после i-того индекса
							 for (int b = i + 1; b < matrixLength; b++)
							 {
									if (matrix[a][b] != '0')
									{
										 return b;
									}
							 }
						}
				 }
				 return 0;
			}

			// VERTEX(v, i) - возвращает вершину с индексом i из множества вершин, смежных с v.
			public char VERTEX(char v, int i)
			{
				 for (int a = 1; a < matrixLength; a++)
				 {
						// Находим подходящую указанную вершину
						if (matrix[a][0] == v)
						{
							 // Находим вершину с индексом i из множества вершин, смежных с v
							 for (int b = 1; b < matrixLength; b++)
							 {
									if (b == i)
									{
										 return matrix[b][0];
									}
							 }
						}
				 }
				 return '0';
			}

			// ADD_V(<имя>,<метка, mark>) - добавить УЗЕЛ 
			public void ADD_V(char name)
			{
				 for (int i = 0; i < matrix.Count; i++)
				 {
						if (i == 0) matrix[0].Add(name);
						else matrix[i].Add('0');
				 }

				 matrix.Add(new List<char>());
				 for (int i = 0; i < matrix.Count; i++)
				 {
						if (i == 0) matrix[matrix.Count - 1].Add(name);
						else matrix[matrix.Count - 1].Add('0');
				 }
			}

			// ADD_Е(v, w, c) - добавить ДУГУ (здесь c — вес, цена дуги (v,w))
			public void ADD_Е(char v, char w, char c)
			{
				 int index_of_first_letter = 0;
				 int index_of_second_letter = 0;

				 for (int i = 1; i < matrixLength; i++)
				 {
						if (matrix[i][0] == v)
						{
							 index_of_first_letter = i;
						}
				 }

				 for (int i = 1; i < matrixLength; i++)
				 {
						if (matrix[0][i] == w)
						{
							 index_of_second_letter = i;
						}
				 }

				 matrix[index_of_first_letter][index_of_second_letter] = c;
			}

			// DEL_V(<имя>) - удалить УЗЕЛ
			public void DEL_V(char name)
			{
				 //matrix.Remove(matrix.Find((array) => array[0] == name));

				 for (int i = 1; i < matrixLength; i++)
				 {
						if (matrix[i][0] == name) {
							 matrix.RemoveAt(i);

							 for (int j = 0; j < matrixLength - 1; j++)
							 {
									matrix[j].RemoveAt(i);
							 }
							 matrixLength--;
							 return;
						}
				 }
			}

			// DEL_Е(v, w) – удалить ДУГУ
			public void DEL_Е(char v, char w)
			{
				 for (int i = 1; i < matrixLength; i++)
				 {
						for (int j = 1; j < matrixLength; j++)
						{
							 if (matrix[i][0] == v && matrix[0][j] == w)
							 {
									matrix[i][j] = '0';
									return;
							 }
						}
				 }
			}

			// EDIT_V(<имя>, <новое значение метки или маркировки>) - изменить метку (маркировку) УЗЛА
			public void EDIT_V(char name, char new_name)
			{
				 for (int i = 1; i < matrixLength; i++)
				 {
						// Находим подходящую указанную вершину
						if (matrix[i][0] == name)
						{
							 matrix[i][0] = new_name;
							 matrix[0][i] = new_name;
							 return;
						}
				 }
			}

			// EDIT_Е(v, w, <новый вес дуги>) - изменить вес ДУГИ
			public void EDIT_Е(char v, char w, char newWeight)
			{
				 for (int i = 0; i < matrixLength; i++)
				 {
						for (int j = 0; j < matrixLength; j++)
						{
							 if (matrix[i][0] == v && matrix[0][j] == w)
							 {
									matrix[i][j] = newWeight;
									return;
							 }
						}
				 }
			}

			public void PrintGraph()
			{
				 for (int i = 0; i < matrixLength; i++)
				 {
						for (int j = 0; j < matrixLength; j++)
						{
							 Console.Write(matrix[i][j] + "    ");
						}
						Console.WriteLine("\n");
				 }
			}
	 }
}
