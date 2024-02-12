// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;

using TrybeSDK;

var settings = GetSettings();
var http = CreateHttpClient();
var api = new TrybeApiClient(http, settings);

var response = await api.Sites.GetSiteAsync("97be0f8c-b78d-4648-b5b9-310d1b3388e2");
if (response.IsSuccess)
{
	Console.WriteLine($"Found site: {response.Data?.Name}");

	response = await api.Sites.UpdateSiteAsync(response.Data.Id, response.Data);
	if (response.IsSuccess)
	{
		Console.WriteLine($"Updated site: {response.Data?.Name}");
	}
	else
	{
		Console.WriteLine($"Error: {response.Error?.Message}");
	}
}
else
{
	Console.WriteLine($"Error: {response.Error?.Message}");
}

TrybeSettings GetSettings()
{
	var configuration = new ConfigurationBuilder()
		.AddJsonFile("./appsettings.json", optional: false)
		.AddJsonFile("./appsettings.env.json", optional: true)
		.Build();

	TrybeSettings settings = new();
	configuration.GetSection(TrybeSettings.ConfigurationSection).Bind(settings);

	settings.Validate();

	return settings;
}

HttpClient CreateHttpClient()
{
	var http = new HttpClient();

	http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

	return http;
}
