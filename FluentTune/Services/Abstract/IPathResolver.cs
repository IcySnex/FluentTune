namespace FluentTune.Services.Abstract;

public interface IPathResolver
{
    string LogFilePath { get; }

    string ConfigFilePath { get; }
}