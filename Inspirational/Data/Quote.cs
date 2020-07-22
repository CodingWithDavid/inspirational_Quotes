
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspirational
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public static async Task<Quote> Get(List<Quote> data)
        {
            Quote result = new Quote();

            if(data.Any())
            {
                Random r = new Random();
                int index = r.Next(1, data.Count);
                try
                {
                    var t = from a in data
                            where a.Id == index
                            select a;
                    if (t.Any())
                    {
                        result = t.FirstOrDefault();
                    }
                }
                catch
                {
                    result = data.ElementAt(0);
                }
                if (string.IsNullOrEmpty(result.Author))
                {
                    result.Author = "Unknown";
                }
            }
            await Task.CompletedTask;
            return result;
        }
    }
}
