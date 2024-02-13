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

// MA - Create a booking frame.
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

string basketId = bookingFrame.Data.Basket.Id;

// MA - Add an item to the basket.
var basket = await api.Shop.Baskets.AddBasketItemAsync(
	basketId,
	new AddBasketItemRequest
	{
		OfferingId = "6372bc492ea8f57d2508fe82",
		OfferingType = "package",
		Date = new(2024, 04, 02),
		Quantity = 1,
		Guests = bookingFrame.Data.Basket.Guests
	});

var guest = basket.Data.Guests[0];
guest.Name = "Matthew Abbott";
guest.IsLeadBooker = true;

await api.Shop.Baskets.UpdateBasketGuestsAsync(
	basketId,
	new UpdateBasketGuestsRequest
	{
		Guests = basket.Data.Guests
	});

await api.Shop.Baskets.SetCustomerAsync(
	basketId,
	new Customer
	{
		FirstName = "Matthew",
		LastName = "Abbott",
		Email = "matt@ingeniumsoftware.dev",
		HasPassword = false,
		Phone = "07944747565"
	});

var response = await api.Shop.Baskets.ReserveBasketAsync(
	basketId);

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
