namespace EX_01_GH;

internal interface IWeatherService
{
    Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync(CancellationToken cancellationToken);
}