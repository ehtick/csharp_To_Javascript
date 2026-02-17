namespace H5.Fuzzer.Models
{
    public class FuzzerOptions
    {
        public int MinutesToRun { get; set; }
        public int? Seed { get; set; }
        public string OutputPath { get; set; }
    }
}
