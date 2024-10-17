## About

Just a simple extension to use with a standard ILogger from Microsoft.
<br>
Purpose is to add methods to write log messages with context. Caller class name, caller method name, line number.

## How to

Install package with NuGet package manager or with ```dotnet add package``` command
<br>
A few methods can be used:
- LogWithContext - can write a log message with a LogLevel provided parameter.
- LogExceptionWithContext - will write down an exception.
<br>
A caller class name, method name and line number will be added to log output:
<br>

Code sample:

```csharp
public class LogController : Controller
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpPost]
    public IActionResult InformationalWithContext()
    {
        _logger.LogWithContext(LogLevel.Information, "Test informational message using context");
        return Ok();
    }

    [HttpPost]
    public IActionResult ExceptionWithContext()
    {
        var divider = 0;

        try
        {
            var result = 10 / divider;
        }
        catch (Exception ex)
        {
            _logger.LogExceptionWithContext("Test exception message using context", ex);
        }

        return Ok();
    }
}
```

Log output sample:

```
[INF] Test informational message using context (at LogController.InformationalWithContext, line 60)
```

```
Test exception message using context (at LogController.ExceptionWithContext, line 75)
System.DivideByZeroException: Attempted to divide by zero. at SerilogExtendedWebExample.Controllers.LogController.ExceptionWithContext()
```