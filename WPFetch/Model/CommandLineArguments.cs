namespace WPFetch.Model;

/// <summary>
/// The command line arguments
/// </summary>
/// <remarks>
/// Initializes a new instance of the CommandLineArguments class using the specified command line arguments.
/// </remarks>
/// <param name="args">An array of command line arguments.</param>
public class CommandLineArguments(string[] args)
{
    /// <summary>
    /// The list of Command line Arguments
    /// </summary>
    public List<string> Arguments { get; private set; } = [.. args];
}
