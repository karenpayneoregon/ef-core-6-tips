namespace LoggingOptionsApp.Models;

public class Logging
{
    public Loglevel LogLevel { get; set; }
    public EntityFrameWorkLogging EntityFrameWorkLogging { get; set; }
}
public class Loglevel
{
    public string Type { get; set; }
}

public class EntityFrameWorkLogging
{
    public string Type { get; set; }
}