using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;
using Statiq.Web.Netlify;

namespace ciit_linux
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper
                .Factory
                .CreateWeb(args)
                .AddHostingCommands()
                .RunAsync();
    }
}
