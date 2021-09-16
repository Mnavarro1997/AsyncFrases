using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncFrases
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var task = new List<Task>();
            Console.WriteLine("La fuente será elegida aleatoriamente cada vez.");
            //Console.WriteLine("Buenas, cuantas frases vas a querer escribir?");
            //string number = Console.ReadLine();

            //Console.WriteLine("Escriba las palabras");
            //string w = Console.ReadLine();

            var font = await GetType();
            task.Add(GetAscii("Vivan los gatos", font));
            //task.Add(GetAscii(w, GetType().Result));

            //task.Add(GetAscii("Vivan las clases"));
            //task.Add(GetAscii("Empezamos "));

            await Task.WhenAll(task);

            //cuantas frases quieres meter
            //en que fuente quieres introducirlo
            //peticion asincrona q tengamos q esperar y cuadno tengamos esa
        }

        private static async Task GetAscii(string words, string font)
        {
            string _url = "https://artii.herokuapp.com/make?text=";
            using (var http = new HttpClient())
            {
                
                string url = $"{_url}{words}{words.Replace(" ", "+")}&font={font}";
                var result = await http.GetStringAsync(url);
                Console.WriteLine(result);
            }
        }

        private static async Task<string> GetType()
        {
            string t = "https://artii.herokuapp.com/fonts_list";
            List<string> listFont = new List<string>();
            using (var http = new HttpClient())
            {
                var result = await http.GetStringAsync(t);
                listFont = result.Split("\n").ToList();
            }
            Random r = new Random();
            int random_number = r.Next(listFont.Count);
            string font = listFont[random_number];
            return font;
        }
    }
}