namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Enums;
    using LoggerLibrary.Layots;

    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
