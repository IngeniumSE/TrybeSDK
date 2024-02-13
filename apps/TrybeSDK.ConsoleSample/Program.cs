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
var frontend = new TrybeFrontendClient(http, settings);

var bookingFrame = await frontend.BookingFrames.CreateBookingFrameAsync(
	new CreateBookingFrameRequest
	{
		PartnerId = settings.PartnerId!,
		ReservationId = "MA-TEST-001",
		DateFrom = new(2024,04,01),
		DateTo = new(2024,04,01),
		NumberOfGuests = 1,
		ConfigureOnlyMode = true,
		HidePrices = true,
		Language = new StringDictionary
		{
			["continue_button"] = "add_to_basket"
		}
	});

Console.WriteLine(bookingFrame);

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
