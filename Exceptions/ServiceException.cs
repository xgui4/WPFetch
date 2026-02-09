namespace WPFetch.Exceptions
{
    [Serializable]
    public class ServiceException(string? message) : Exception(message)
    {
    }
}