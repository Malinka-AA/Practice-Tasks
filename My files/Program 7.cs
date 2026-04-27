using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Home
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _review;


        public string Name => _name;
        public int Duration => _duration;
        public int[] Review => _review.ToArray();    
        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
        }

        public void Add(int rev)
        {
            Array.Resize(ref _review, _review.Length+1);
            _review[_review.Length-1] = rev;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // получение путей к папкам

            Movie Inception = new Movie("Inception", 120);

            Inception.Add(8);
            Inception.Add(9);
            // --сериализация
            var temp = new
            {
                MovieType=Inception.GetType().Name,
                Inception.Name,
                Inception.Duration,
                Inception.Review
            };

           


            // абсолютный путь

            // относительный путь
            //"dataset/data.txt"

            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FilePath = Path.Combine(FolderPath, "Test", "example.json");

            string json = JsonConvert.SerializeObject(temp);

            Console.WriteLine(json);

            string FolderPath1 = Path.Combine(FolderPath, "Test");
            string FilePath1 = Path.Combine(FolderPath, "example.txt");


            // --Десериализация
            string content = File.ReadAllText(FilePath);
            var contentInJson = JsonConvert.DeserializeObject<dynamic>(content);

            Movie mov = new Movie((string)contentInJson.Name, (int )contentInJson.Duration);
            foreach(var n in contentInJson)
            {
                mov.Add((int)n);
            }
            Console.WriteLine(Compare(Inception,mov));




            if (!Directory.Exists(FolderPath1))
                Directory.CreateDirectory(FolderPath1);

            if (!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Close();
            }

            //string str = Path.GetFullPath("example.txt");



            File.WriteAllText(FilePath, "Здарова" + "\n" + "How are u"); // записвывает в файл строку, если - файла не было он создает и записывает, а если файл был - перезаписывает содержимое
            File.WriteAllLines(FilePath, new string[] { "so", "si", "s", "ki" });
            File.AppendAllLines(FilePath, new string[] {"\n","s","Ket","chup","mmm","vkusno" });


            string cont = File.ReadAllText(FilePath);
            string[] lines = File.ReadAllLines(FilePath);

            for (int i=0;i<lines.Length;i++)
            {
                Console.WriteLine(lines[i]);
            }

            File.Delete(FilePath);
            Directory.Delete(FolderPath1);


        }


        private bool Compare(Movie m1, Movie m2)
        {
            if (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Review.Length !=  m2.Review.Length) return false;
            for (int i=0;i < m1.Review.Length;i++)
            {
                if (m1.Review[i] != m2.Review[i]) return false;
            }
            return true;
        }
    }
}