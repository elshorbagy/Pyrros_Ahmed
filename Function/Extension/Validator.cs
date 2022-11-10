using System;

namespace SftpClient.Extension
{
    public static class Validator
    {
        public static void ValidateString(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Request is not valid");
            }
        }
    }
}
