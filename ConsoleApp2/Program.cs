using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 補充：不用HttpClient，直接使用AngleSharp取得資料
            // 使用AngleSharp時的前置設定
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            //將我們用httpclient拿到的資料放入res.Content中())

            var document = await context.OpenAsync("https://dannyliu.me");
            // Console.WriteLine(response);

            //QuerySelector("head")找出<head></head>元素
            var head = document.QuerySelector("head");
            Console.WriteLine(head.ToHtml());

            //QuerySelector(".entry-content")找出class="entry-content"的所有元素
            var contents = document.QuerySelectorAll(".entry-content");

            foreach (var c in contents)
            {
                //取得每個元素的TextContent
                Console.WriteLine(c.TextContent);
            }


            Console.ReadKey();
        }
    }
}
