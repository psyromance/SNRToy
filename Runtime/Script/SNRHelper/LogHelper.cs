namespace SNRLogHelper
{
    public static class LogHelper
    {
        public static void easyLog(params object[] arguments)
        {
            string logMessage = string.Join("", arguments);
            System.Diagnostics.Debug.WriteLine(logMessage);
        }
    }


}