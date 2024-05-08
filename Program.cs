using ClassLibraryLab10;
using System;
using System.Collections;
namespace lab12_2
{
    internal class Program
    {
        /// <summary>
        /// Создание хэш-таблицы
        /// </summary>
        /// <param name="hashTable"></param>
        /// <returns></returns>
        static MyHashTable<MusicalInstrument> MakeTable(MyHashTable<MusicalInstrument> hashTable)
        {
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();

            hashTable = new MyHashTable<MusicalInstrument>(10);
            hashTable.AddItem(m1);
            hashTable.AddItem(m2);
            hashTable.AddItem(g1);
            hashTable.AddItem(g2);
            hashTable.AddItem(e1);
            hashTable.AddItem(e2);
            hashTable.AddItem(p1);
            hashTable.AddItem(p2);
            return hashTable;
        }

        static void Add(MyHashTable<MusicalInstrument> hashTable)
        {
            MusicalInstrument m = new MusicalInstrument();
            m.IRandomInit();
            int checkAdd = hashTable.AddItem(m);
            if (checkAdd == 0)
                Console.WriteLine("Таблица пустая");
            else if (checkAdd == -1)
                Console.WriteLine("Такой элемент уже есть");
            else
                Console.WriteLine($" Элемент {m} добавлен на место: {hashTable.GetIndex(m) + 1}");
        }

        /// <summary>
        /// Поиск элемента в таблице
        /// </summary>
        /// <param name="elementToSearch"></param>
        /// <param name="hashTable"></param>
        static void SearchElement(MyHashTable<MusicalInstrument> hashTable)
        {
            string name;
            Console.WriteLine("Введите название инструмента: ");
            name = Console.ReadLine();

            Point<MusicalInstrument> item = hashTable.FindName(name);
            int isExist = hashTable.SearchItem(item);
            if (isExist == 0)
            {
                Console.WriteLine($"   Таблица пустая  ");
            }
            else if (isExist == -1)
            {
                Console.WriteLine($"  Элемента с названием ' {name} ' нет в таблице   ");
            }
            else
            {
                Console.WriteLine($"Элемент с названием '{name}' есть в таблице: ' {item} ' находится под индексом: {hashTable.GetIndex(item.Data) + 1}");
            }
        }

        static void DeleteElement(MyHashTable<MusicalInstrument> hashTable)
        {
            string name;
            Console.WriteLine("Введите название инструмента: ");
            name = Console.ReadLine();

            Point<MusicalInstrument> item = hashTable.FindName(name);
            int isExist = hashTable.RemoveItem(item);
            if (isExist == 0)
            {
                Console.WriteLine($"   Таблица пустая  ");
            }
            else if (isExist == -1)
            {
                Console.WriteLine($"  Элемента с названием ' {name} ' нет в таблице    ");
            }
            else
            {
                Console.WriteLine($"Элемент с названием '{name}': {item} удален");
            }
        }

        /// <summary>
        /// Печать и проверка на правильность клонирования
        /// </summary>
        /// <param name="cloneTable"></param>
        static void PrintAndCheckClone(MyHashTable<MusicalInstrument> cloneTable, MyHashTable<MusicalInstrument> hashTable)
        {
            if (hashTable.Clone(hashTable) == null)
            {
                Console.WriteLine(" Исходная хэш-таблица пуста  ");
            }
            else
            {
                cloneTable.PrintTable();
                Console.WriteLine();
                Console.WriteLine("=== Клон таблицы с добавленным элементом ===");
                cloneTable.AddItem(new MusicalInstrument("NEW ITEM", 555));
                cloneTable.ChangeItem(new MusicalInstrument("CHANGED ITEM", 44));
                cloneTable.PrintTable();
            }
        }

        static void Main(string[] args)
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MyHashTable<MusicalInstrument> cloneTable = new MyHashTable<MusicalInstrument>();
            int ans;
            bool isConvert;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Создание хэш-таблицы");
                Console.WriteLine("2. Поиск элемента по ключу");
                Console.WriteLine("3. Удаление элемента по ключу");
                Console.WriteLine("4. Печать хэш-таблицы");
                Console.WriteLine("5. Добавление элемента в хэш-таблицу");
                Console.WriteLine("6. Клонирование элементов хэш-таблицы");
                Console.WriteLine("7. Печать и проврка правильности клонирования");
                Console.WriteLine("0. Закончить работу");
                Console.WriteLine();

                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                    Console.WriteLine();
                    if (!isConvert)
                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                } while (!isConvert);

                switch(ans)
                {
                    case 1: //Создание хэш-таблицы
                        {
                            hashTable = MakeTable(hashTable);
                            Console.WriteLine("Хэш-таблица сформирована");
                            break;
                        }
                    case 2: //Поиск элемента по ключу
                        {
                            Console.WriteLine("==== Поиск элемента по ключу ===");
                            SearchElement(hashTable);
                            break;
                        }

                    case 3: //Удаление элемента по ключу
                        {
                            Console.WriteLine("=== Удаление элемента по ключу ===");
                            DeleteElement(hashTable);
                            break;
                        }
                          
                    case 4: //Печать хэш-таблицы
                        {
                            try
                            {
                                if (hashTable.Count == 0)
                                    Console.WriteLine("В таблице нет элементов");
                                else hashTable.PrintTable();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($" Исключение: {ex.Message}");
                            }
                            break;
                        }

                    case 5: //Добавление
                        {
                            Console.WriteLine("=== Добавление элемента ===");
                            Add(hashTable);
                            break;
                        }
                    case 6: //Клонироавние
                        {
                            cloneTable = hashTable.Clone(hashTable);
                            if (hashTable.Clone(hashTable) == null)
                                Console.WriteLine(" Исходная хэш-таблица пуста  ");
                            else
                                Console.WriteLine($"Хэш-таблица склонирована");
                            break;
                        }

                    case 7: //Печать клона
                        {
                            Console.WriteLine("=== Клонирование элементов хэш-таблицы ===");
                            PrintAndCheckClone(cloneTable, hashTable);
                            break;
                        }

                }

            } while (ans != 0);
        }
    }
}
