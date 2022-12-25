namespace AlifTech.Service.Exceptions
{
    internal sealed class EWalletException : Exception
    {
        /// <summary>
        /// Response code.
        /// </summary>
        public int Code { get; set; }

        public EWalletException(int code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
