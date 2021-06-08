using Nuke.Common.IO;
using System.Linq;

namespace cangulo.build.Extensions
{
    public static class AbsolutePathExtension
    {
        public static string GetFileName(this AbsolutePath absolutePath)
        {
            var arrayFolders = absolutePath.ToString().Split("\\");
            return arrayFolders.Last() ?? string.Empty;
        }
    }
}
