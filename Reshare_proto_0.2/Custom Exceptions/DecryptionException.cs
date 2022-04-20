using System;
using System.Runtime.Serialization;

namespace Reshare_proto_0._2.Custom_Exceptions
{
    public class DecryptionException : Exception
    {
        public DecryptionException()
        {
        }

        public DecryptionException(string message) : base(message)
        {
        }

        public DecryptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DecryptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

