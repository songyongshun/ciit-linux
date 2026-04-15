using System.Threading.Tasks;
using Statiq.App;
using Statiq.Docs;

namespace MySite
{
  public class Program
  {
    public static async Task<int> Main(string[] args) =>
      await Bootstrapper
        .Factory
        .CreateDocs(args)
	      .AddSetting(Keys.Host, "ciit-linux.netlify.app")
        .RunAsync();
  }
}
