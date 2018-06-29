using NativeLibrary.Sample.Core.Services.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeLibrary.Sample.Core
{
    public class NativeOperationsService : INativeOperationsService
    {
        [DllImport("NativeLibrary", EntryPoint = "NativeLibrary_PassString")]
        private static extern void passString(StringBuilder str, int len);

        public string GetStringFromNative()
        {
            try
            {
                StringBuilder sb = new StringBuilder(40);
                sb.Append("Xamarin");
                passString(sb, sb.Capacity);
                return sb.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
