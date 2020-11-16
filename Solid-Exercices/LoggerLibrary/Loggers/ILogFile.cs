namespace LoggerLibrary.Loggers
{
    public interface ILogFile
    {
        public int Size{get; }

        void Write(string message);

    }
}
