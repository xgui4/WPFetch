namespace WPFetch.Exceptions
{
    [Serializable]
    internal class ServiceException : Exception
    {
        public ServiceException(string? message) : base(message)
        {
        }
    }
}