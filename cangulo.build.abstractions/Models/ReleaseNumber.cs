namespace cangulo.build.abstractions.Models
{
    public class ReleaseNumber
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
        public string Extra { get; set; }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}{Extra}";
        }
    }
}