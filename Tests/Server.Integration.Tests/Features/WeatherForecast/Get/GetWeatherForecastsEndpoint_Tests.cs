namespace GetWeatherForecastsEndpoint;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Threading.Tasks;
using TestApp.Api.Features.WeatherForecast;
using TestApp.Server;
using TestApp.Server.Integration.Tests.Infrastructure;

public class Returns : BaseTest
{
  private readonly GetWeatherForecastsRequest GetWeatherForecastsRequest;

  public Returns
  (
    WebApplicationFactory<Startup> aWebApplicationFactory,
    JsonSerializerOptions aJsonSerializerOptions
  ) : base(aWebApplicationFactory, aJsonSerializerOptions)
  {
    GetWeatherForecastsRequest = new GetWeatherForecastsRequest { Days = 10 };
  }

  public async Task _10WeatherForecasts_Given_10DaysRequested()
  {
    GetWeatherForecastsResponse getWeatherForecastsResponse =
      await GetJsonAsync<GetWeatherForecastsResponse>(GetWeatherForecastsRequest.RouteFactory);

    ValidateGetWeatherForecastsResponse(getWeatherForecastsResponse);
  }

  private void ValidateGetWeatherForecastsResponse(GetWeatherForecastsResponse aGetWeatherForecastsResponse)
  {
    aGetWeatherForecastsResponse.CorrelationId.Should().Be(GetWeatherForecastsRequest.CorrelationId);
    aGetWeatherForecastsResponse.WeatherForecasts.Count.Should().Be(GetWeatherForecastsRequest.Days);
    aGetWeatherForecastsResponse.WeatherForecasts.Count.Should().Be(GetWeatherForecastsRequest.Days);
  }

}
