using System.IO;
using System.Text;

class HelloWorld
{
    static void Main()
    {
        bool exit = true;
        string path = "lo.txt";
        while (exit)
        {
            Console.WriteLine("Выберите действие: \n1)Создать файл и записать данные \n2 прочитать данные из файла \n 3. Записать данные параллельно через потоки \n 4 Удалить файл \n5 Выход");
            Console.WriteLine();
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    try
                    {
                        using (FileStream fs = File.Create(path))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes("Поток 1: " + DateTime.Now + "\n");
                            for (int i = 0; i < 10; i++)
                                fs.Write(info, 0, info.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                    break;
                case '2':
                    try
                    {
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                    break;
                case '3':
                    try
                    {
                        for(int i = 0;i < 5; i++)
                        {
                            using (FileStream fs = File.Create(path))
                            {
                                byte[] info = new UTF8Encoding(true).GetBytes("Поток 1: " + DateTime.Now + "\n");
                                for (int j = 0; j < 5; j++)
                                    fs.Write(info, 0, info.Length);
                                info = new UTF8Encoding(true).GetBytes("Поток 2: " + DateTime.Now + "\n");
                                for (int j = 0; j < 5; j++)
                                    fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                    break;
                case '4':
                    File.Delete(path);
                    break;
                case '5':
                    exit = false;
                    break;
            }
        }
    }
}