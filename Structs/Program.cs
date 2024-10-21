namespace Structs
{



    class TwoDimArray
    {
        public int[,] array { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }

        public TwoDimArray(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            array = new int[rows, cols];
        }

        public void FillArray()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rand.Next(1, 100);
                }
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void PrintMaxMinGlobal()
        {
            int globalMax = array[0, 0];
            int globalMin = array[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > globalMax) globalMax = array[i, j];
                    if (array[i, j] < globalMin) globalMin = array[i, j];
                }
            }

            Console.WriteLine($"\nГлобальный Max: {globalMax}");
            Console.WriteLine($"Глобальный Min: {globalMin}");
        }

        public void PrintMaxMinPerRow()
        {
            for (int i = 0; i < rows; i++)
            {
                int rowMax = array[i, 0];
                int rowMin = array[i, 0];

                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > rowMax) rowMax = array[i, j];
                    if (array[i, j] < rowMin) rowMin = array[i, j];
                }

                Console.WriteLine($"Строка {i + 1}: Max = {rowMax}, Min = {rowMin}");
            }
        }
    }

    //2
    class TextModifier
    {
        public string input { get; set; }

        public TextModifier(string input)
        {
            this.input = input;
        }

        public string SwitchCase()
        {
            string result = "";
            foreach (char c in input)
            {
                if (char.IsUpper(c))
                    result += char.ToLower(c);
                else if (char.IsLower(c))
                    result += char.ToUpper(c);
                else
                    result += c;
            }
            return result;
        }
    }

    //3
    class WordSplitter
    {
        public string input { get; set; }

        public WordSplitter(string input)
        {
            this.input = input;
        }

        public void PrintWords()
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Слова в строке:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }

    //4
    class SymbolChecker
    {
        public string input { get; set; }

        public SymbolChecker(string input)
        {
            this.input = input;
        }

        public void CheckFiveConsecutiveSymbols()
        {
            bool found = false;

            for (int i = 0; i < input.Length - 4; i++)
            {
                if (input[i] == input[i + 1] && input[i] == input[i + 2] && input[i] == input[i + 3] && input[i] == input[i + 4])
                {
                    found = true;
                    break;
                }
            }

            if (found)
                Console.WriteLine("Есть пять идущих подряд одинаковых символов.");
            else
                Console.WriteLine("Пять одинаковых символов подряд не найдены.");
        }
    }

   
    // 5
    struct Client
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int OrdersCount { get; set; }
        public decimal TotalOrderAmount { get; set; }

        public Client(int code, string name, string address, string phone, int ordersCount, decimal totalOrderAmount)
        {
            Code = code;
            Name = name;
            Address = address;
            Phone = phone;
            OrdersCount = ordersCount;
            TotalOrderAmount = totalOrderAmount;
        }

        public void Print()
        {
            Console.WriteLine($"Код клиента: {Code}");
            Console.WriteLine($"ФИО: {Name}");
            Console.WriteLine($"Адрес: {Address}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Количество заказов: {OrdersCount}");
            Console.WriteLine($"Общая сумма заказов: {TotalOrderAmount}");
        }
    }

    // 6) Структура Request
    struct Request
    {
        public int OrderCode { get; set; }
        public Client Client ;
        public DateTime OrderDate;
        public string[] OrderedItems  { get; set; }
        public decimal TotalAmount { get; set; }

        public Request(int orderCode, Client client, DateTime orderDate, string[] orderedItems, decimal totalAmount)
        {
            OrderCode = orderCode;
            Client = client;
            OrderDate = orderDate;
            OrderedItems = orderedItems;
            TotalAmount = totalAmount;
        }

        public void Print()
        {
            Console.WriteLine($"Код заказа: {OrderCode}");
            Console.WriteLine($"Дата заказа: {OrderDate.ToShortDateString()}");
            Console.WriteLine($"Клиент:");
            Client.Print();
            Console.WriteLine("Перечень заказанных товаров:");
            foreach (string item in OrderedItems)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Сумма заказа: {TotalAmount}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            // 1
            Console.WriteLine("1) Двумерный массив:");

            TwoDimArray array = new TwoDimArray(5, 4);
            array.FillArray();

            array.PrintArray();
            array.PrintMaxMinGlobal();


            array.PrintMaxMinPerRow();

            //2
            Console.WriteLine("\n2) Изменение регистра букв:");

            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine();
            TextModifier modifier = new TextModifier(inputString);
            Console.WriteLine("Изменённая строка: " + modifier.SwitchCase());

            //3
            Console.WriteLine("\n3) Разделение строки на слова:");
            Console.Write("Введите строку: ");


            string inputWords = Console.ReadLine();
            WordSplitter splitter = new WordSplitter(inputWords);

            splitter.PrintWords();

            // 4
            Console.WriteLine("\n4) Проверка на пять подряд одинаковых символов:");
            Console.Write("Введите текст: ");
            string inputText = Console.ReadLine();
            SymbolChecker checker = new SymbolChecker(inputText);
            checker.CheckFiveConsecutiveSymbols();

            // 5
            Console.WriteLine("\n5) Структура Client:");

            Client client = new Client(1, "Иван Иванов", "Одесса, ул. Пушкина", "+3803492842", 5, 15000m);
            client.Print();

            // 6
            Console.WriteLine("\n6) Структура Request:");

            string[] items = { "Товар 1", "Товар 2", "Товар 3" };
            Request request = new Request(101, client, DateTime.Now, items, 5000m);

            request.Print();
        }
    }
}
