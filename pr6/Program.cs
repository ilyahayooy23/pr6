using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
namespace Practical_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            wwf figure1 = new wwf();
            figure1.Name = "Клавиатура";
            figure1.Height = 100;
            figure1.Width = 100;
            wwf figure2 = new wwf();
            figure2.Name = "Мышка";
            figure2.Height = 50;
            figure2.Width = 25;


            List<wwf> figure = new List<wwf>();
            figure.Add(figure1);
            figure.Add(figure2);


            Console.WriteLine("Введите путь до файла:");
            Console.WriteLine("------------------------------------------------");
            string put = Console.ReadLine();

            if (File.Exists(put))
            {
                Console.Clear();


                string txt = File.ReadAllText(put);
                Console.WriteLine(txt);


                Console.WriteLine("Сохранить файл в один из форматов(xml, json, txt) - F1.Закрыть программу - Escape.");


                ConsoleKeyInfo klav = Console.ReadKey();
                while (klav.Key != ConsoleKey.Escape)
                {
                    if (klav.Key == ConsoleKey.F1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите путь до файла (с названием) куда вы хотите его сохранить");
                        string path = Console.ReadLine();

                        if (path.Contains("json"))
                        {
                            if (put.Contains("txt"))
                            {
                                SerialandDeserial.JsonSerial(figure, path);
                            }
                            else
                            {
                                SerialandDeserial.JsonDeserial(path);
                            }
                        }
                        else if (path.Contains("xml"))
                        {
                            if (put.Contains("txt"))
                            {
                                SerialandDeserial.XmlSerial(figure, path);
                            }
                            else
                            {
                                SerialandDeserial.JsonDeserial(path);
                            }
                        }

                    }
                    else if (klav.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    klav = Console.ReadKey();
                }
            }
        }
    }
}