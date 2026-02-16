namespace WPFetch.Model
{
    public class CommandLineArguments
    {
        public List<string> Arguments { get; private set; }
        public CommandLineArguments(string[] args)
        {
            Arguments = args.ToList();
        }
    }
}
