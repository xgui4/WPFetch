namespace WPFetch.Exceptions;

/// <summary>
/// Represent a service exception
/// </summary>
/// <param name="message">The message of why the exception was throwed.</param>
[Serializable]
public class ServiceException(string? message) : Exception(message)
{
}