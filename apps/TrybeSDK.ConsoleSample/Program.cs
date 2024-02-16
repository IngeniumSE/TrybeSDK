// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;

using TrybeSDK;
using TrybeSDK.Api;
using TrybeSDK.Frontend;

var settings = GetSettings();
var http = CreateHttpClient();
var api = new TrybeApiClient(http, settings);

var response = await api.Shop.Packages.GetPackageAsync("6372bc492ea8f57d2508fe82");
//var response = await api.Shop.ItemAvailability.GetOfferingDates(
//	new GetOfferingDatesRequest
//	{
//		OfferingType = "package",
//		OfferingId = "6372bc492ea8f57d2508fe82",
//		DateFrom = new(2024, 04, 01),
//		DateTo = new(2024, 04, 30),
//		Quantity = 1
//	});

if (response.IsSuccess && response.HasData)
{
	var package = response.Data!;

	string packageJson = package.ToJsonString();

	var package2 = Package.FromJsonString(packageJson);
}

Console.WriteLine(response);

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
