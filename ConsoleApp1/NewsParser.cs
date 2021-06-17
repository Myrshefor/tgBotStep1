using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

namespace Awesome
{
    public static class NewsParser
    {
        public static async Task<string> FindNews(string text)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var uri = $"https://dtf.ru/search/v2/content/new?query={text}";
            var document = await context.OpenAsync(uri);
            var selector = "div.content-title.content-title--short.l-island-a";
            var elements = document.QuerySelectorAll(selector);
            var arr = elements.Select(it => it.TextContent);
            var result = string.Join("\n", arr);
           
            return result;
        }
    }
}