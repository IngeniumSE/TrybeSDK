﻿// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

using TrybeSDK.Primitives;

namespace TrybeSDK.Frontend;

/// <summary>
/// A booking frame object.
/// </summary>
public class BookingFrame
{
	/// <summary>
	/// If true, the booking frame will not allow optional upsells to be configured.
	/// </summary>
	[JsonPropertyName("configure_only_mode")]
	public required bool ConfigureOnlyMode { get; set; }

	/// <summary>
	/// The minimum date for offerings.
	/// </summary>
	[JsonPropertyName("date_from")]
	public required DateTime DateFrom { get; set; }

	/// <summary>
	/// The maximum date for offerings.
	/// </summary>
	[JsonPropertyName("date_to")]
	public required DateTime DateTo { get; set; }

	/// <summary>
	/// If true, the booking frame will not display any prices.
	/// </summary>
	[JsonPropertyName("hide_prices")]
	public required bool HidePrices { get; set; }

	/// <summary>
	/// The ID of the booking frame.
	/// </summary>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The number of guests.
	/// </summary>
	[JsonPropertyName("num_guests")]
	public required int NumberOfGuests { get; set; }

	/// <summary>
	/// The ID of the partner that requested the booking frame.
	/// </summary>
	[JsonPropertyName("partner_id")]
	public required string PartnerId { get; set; }

	/// <summary>
	/// The ID of the reservation, as provided by the partner.
	/// </summary>
	[JsonPropertyName("reservation_id")]
	public required string ReservationId { get; set; }

	/// <summary>
	/// The URL for the booking frame.
	/// </summary>
	[JsonPropertyName("url")]
	public required string Url { get; set; }
}

/// <summary>
/// A request to create a new booking frame object.
/// </summary>
public class CreateBookingFrameRequest
{
	/// <summary>
	/// If true, the booking frame will not allow optional upsells to be configured.
	/// </summary>
	[JsonPropertyName("configure_only_mode")]
	public required bool ConfigureOnlyMode { get; set; }

	/// <summary>
	/// The minimum date for offerings.
	/// </summary>
	[JsonPropertyName("date_from"), JsonConverter(typeof(DateFormatJsonConverter))]
	public required DateTime DateFrom { get; set; }

	/// <summary>
	/// The maximum date for offerings.
	/// </summary>
	[JsonPropertyName("date_to"), JsonConverter(typeof(DateFormatJsonConverter))]
	public required DateTime DateTo { get; set; }

	/// <summary>
	/// If true, the booking frame will not display any prices.
	/// </summary>
	[JsonPropertyName("hide_prices")]
	public required bool HidePrices { get; set; }

	/// <summary>
	/// The number of guests.
	/// </summary>
	[JsonPropertyName("num_guests")]
	public required int NumberOfGuests { get; set; }

	/// <summary>
	/// The ID of the partner that requested the booking frame.
	/// </summary>
	[JsonPropertyName("partner_id")]
	public required string PartnerId { get; set; }

	/// <summary>
	/// The ID of the reservation, as provided by the partner.
	/// </summary>
	[JsonPropertyName("reservation_id")]
	public string? ReservationId { get; set; }
}