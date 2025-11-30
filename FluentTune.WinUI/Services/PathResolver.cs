using FluentTune.Services.Abstract;

namespace FluentTune.WinUI.Services;

internal class PathResolver : IPathResolver
{
    static readonly string ApplicationDirectory = Path.Combine(Environment.CurrentDirectory, "Data");

    static readonly string CacheDirectory = Path.Combine(Environment.CurrentDirectory, "Cache");


    public string LogFilePath { get; } = Path.Combine(CacheDirectory, "Logs", ".log");

    public string ConfigFilePath { get; } = Path.Combine(ApplicationDirectory, "Config.json");
}