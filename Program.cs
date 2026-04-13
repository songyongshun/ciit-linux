using System.Threading.Tasks;
using Statiq.App;
using Statiq.Docs;
using Statiq.Common;

namespace MySite
{
  public class Program
  {
    public static async Task<int> Main(string[] args) =>
      await Bootstrapper
        .Factory
        .CreateDocs(args)
        .AddSetting(Keys.Host, "ciit-linux.netlify.app")
        .AddSetting(Keys.LinkRoot, "/")
        .AddSetting("ThemePath", "theme")
        .RunAsync();
  }
}
