using System;
using System.IO;
using System.Collections.Generic;

namespace Lesson_8_ExternalSort
{
    class Program
    {
        private static void SplitBigFile(string file)
        {
            //Начинаем с первого файла
            int splitNumber = 1;

            StreamWriter writer = new StreamWriter(string.Format(@"C:\ExternalArray\tmp\split{0:d5}.txt", splitNumber));

            using (StreamReader reader = new StreamReader(file))
            {
                while (reader.Peek() >= 0)
                {
                    writer.WriteLine(reader.ReadLine());

                    
                    if (writer.BaseStream.Length > 100000000 && reader.Peek() >= 0)
                    {
                        writer.Close();
                        splitNumber++;
                        writer = new StreamWriter(string.Format(@"C:\ExternalArray\tmp\split{0:d5}.txt", splitNumber));
                    }
                }
            }
            writer.Close();
        }

        private static void SortParts(string tempFiles)
        {
            
            foreach (string path in Directory.GetFiles(tempFiles, "split*.txt"))
            {
                string[] content = File.ReadAllLines(path);

               
                int[] arrayOfNum = new int[content.Length];

                for (int i = 0; i < content.Length; i++)
                {
                    var cont = Convert.ToInt32(content[i]);

                    if (cont != 0)
                    {
                        arrayOfNum[i] = cont;
                    }
                }
                //Использовал для сортировки этот алгоритм 
                MergeSort(arrayOfNum);

                //Обратный процесс для того, чтобы считать стринговый массив
                for (int i = 0; i < arrayOfNum.Length; i++)
                {
                    content[i] = Convert.ToString(arrayOfNum[i]);
                }
                

                //Меняем разделенные файлы на отсортированные
                string newPath = path.Replace("split", "sorted");

                File.WriteAllLines(newPath, content);

                File.Delete(path);

                content = null;
                arrayOfNum = null;

                //Подчищаем мусор
                GC.Collect();
            }
        }

        private static void MergeFiles(string sortedFile, string tempFiles)
        {
            //Читает отсортированные блоки
            string[] paths = Directory.GetFiles(tempFiles, "sorted*.txt");

            int blocks = paths.Length;

            int recordSize = 100;

            //Максимальное использование памяти
            int maxUsage = 500000000;

            //Размер буфера: максимально возможное значение / количество блоков
            int bufferSize = maxUsage / blocks;

            double recordOverHead = 7.5;

            int bufferLength = (int)(bufferSize / recordSize / recordOverHead);

            //Открываем файлы
            StreamReader[] readers = new StreamReader[blocks];
            for (int i = 0; i < blocks; i++)
            {
                readers[i] = new StreamReader(paths[i]);
            }

            //Создаем очереди из расчета количества отсортированных файлов
            Queue<string>[] queues = new Queue<string>[blocks];
            for (int i = 0; i < blocks; i++)
            {
                queues[i] = new Queue<string>(bufferLength);
            }

            //Загружаем в очередь
            for (int i = 0; i < blocks; i++)
            {
                LoadQueue(queues[i], readers[i], bufferLength);
            }

            //Соединяем отсортированные файлы и записываем в один
            StreamWriter writer = new StreamWriter(sortedFile);

            bool isDone = false;

            //Минимальный индекс
            int lowIndex;

            //Минимальное значение
            string lowValue;

            while (!isDone)
            {
                //Ищем блок с минимальным значением
                lowIndex = -1;

                lowValue = "";

                for (int j = 0; j < blocks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowIndex < 0 || String.CompareOrdinal(queues[j].Peek(), lowValue) < 0)
                        {
                            lowIndex = j;
                            lowValue = queues[j].Peek();
                        }
                    }
                }

                //Если больше ничего не нашли в очереди, тогда заканчиваем
                if (lowIndex == -1)
                {
                    isDone = true;
                    break;
                }

                //Вывод значения
                writer.WriteLine(lowValue);

                //Удаление из очереди
                queues[lowIndex].Dequeue();

                //Если ничего нет, то снова загружаем значение
                if (queues[lowIndex].Count == 0)
                {
                    LoadQueue(queues[lowIndex], readers[lowIndex], bufferLength);

                    //Если ничего нет для прочтения
                    if (queues[lowIndex].Count == 0)
                    {
                        queues[lowIndex] = null;
                    }
                }
            }
            writer.Close();

            //Закрываем и удаляем прочитанные блоки
            for (int i = 0; i < blocks; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        private static void LoadQueue(Queue<string> queue, StreamReader file, int bufferLength)
        {
            for (int i = 0; i < bufferLength; i++)
            {
                if (file.Peek() < 0)
                {
                    break;
                }
                queue.Enqueue(file.ReadLine());
            }
        }
        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1]; var index = 0;
            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }
            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex]; array[lowIndex] = array[highIndex]; array[highIndex] = t;
                    }
                }
                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }
            return array;
        }
        private static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
        public static void ExternalSort(string readBigFile, string tempFiles, string sortedFile)
        {
            //Считываем файл и разбиваем его на части
            SplitBigFile(readBigFile);
            Console.WriteLine("Split process is done!");
            Console.WriteLine();
            //Сортируем части
            SortParts(tempFiles);
            Console.WriteLine("SortFilesIsDone");
            Console.WriteLine();
            //Соединяем отсортированные части
            MergeFiles(sortedFile, tempFiles);
            Console.WriteLine("ProcessIsDone");
        }
        static void Main(string[] args)
        {
            //Дополнительное задание к уроку 8 (ExternalSort)
            var test = new TestClass[4];

            test[0] = new TestClass()
            {
                InputA = 1000,
                ExpectedValueA = 1000,
                ExpectedValueB = "Отсортированный файл на 1000 значений",
            };
            test[1] = new TestClass()
            {
                InputA = 5000,
                ExpectedValueA = 5000,
                ExpectedValueB = "Отсортированный файл на 5000 значений",
            };
            test[2] = new TestClass()
            {
                InputA = 9000,
                ExpectedValueA = 9000,
                ExpectedValueB = "Отсортированный файл на 9000 значений",
            };
            test[3] = new TestClass()
            {
                InputA = 15000,
                ExpectedValueA = 15000,
                ExpectedValueB = "Отсортированный файл на 15000 значений",
            };

            for (int i = 0; i < test.Length; i++)
            {
                var readBigFile = @$"C:\ExternalArray\UnsortedArray({test[i].InputA}).txt";
                var tempFiles = @"C:\ExternalArray\tmp";
                var sortedFile = @$"C:\ExternalArray\SortedArray\SortedArray({test[i].ExpectedValueA}).txt";

                ExternalSort(readBigFile, tempFiles, sortedFile);
            }

            Console.ReadKey();
        }
    }
}