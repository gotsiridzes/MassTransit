public record WeatherForecastCreated
{
	public WeatherForecastCreated(Guid Id, DateOnly Date, int TemperatureC, string? Summary)
	{
		this.Id = Id;
		this.Date = Date;
		this.TemperatureC = TemperatureC;
		this.Summary = Summary;
	}

	public Guid Id { get; init; }
	public DateOnly Date { get; init; }
	public int TemperatureC { get; init; }
	public string? Summary { get; init; }
}