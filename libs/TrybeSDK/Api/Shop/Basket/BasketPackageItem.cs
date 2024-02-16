// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket package item.
/// </summary>
public class BasketPackageItem : Model<BasketPackageItem>
{
	/// <summary>
	/// A unique ID for the basket package item
	/// </summary>
	/// <value>A unique ID for the basket package item</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The ID of the package choice this item relates to.
	/// </summary>
	/// <value>The ID of the package choice this item relates to.</value>
	[JsonPropertyName("choice_id")]
	public string? ChoiceId { get; set; }

	/// <summary>
	/// The ID of the package option this item relates to.
	/// </summary>
	/// <value>The ID of the package option this item relates to.</value>
	[JsonPropertyName("option_id")]
	public string? OptionId { get; set; }

	/// <summary>
	/// The type of offering this item represents.
	/// </summary>
	/// <value>The type of offering this item represents.</value>
	[JsonPropertyName("offering_type")]
	public string? OfferingType { get; set; }

	/// <summary>
	/// The ID of the offering this item represents.
	/// </summary>
	/// <value>The ID of the offering this item represents.</value>
	[JsonPropertyName("offering_id")]
	public string? OfferingId { get; set; }

	/// <summary>
	/// The name of the offering this item represents.
	/// </summary>
	/// <value>The name of the offering this item represents.</value>
	[JsonPropertyName("offering_name")]
	public string? OfferingName { get; set; }

	/// <summary>
	/// The chosen start time for this item.
	/// </summary>
	/// <value>The chosen start time for this item.</value>
	[JsonPropertyName("time")]
	public DateTime? Time { get; set; }

	/// <summary>
	/// The duration of this item.
	/// </summary>
	/// <value>The duration of this item.</value>
	[JsonPropertyName("duration")]
	public string? Duration { get; set; }

	/// <summary>
	/// The date and time that the item is reserved until.
	/// </summary>
	/// <value>The date and time that the item is reserved until.</value>
	[JsonPropertyName("reserved_until")]
	public DateTime? ReservedUntil { get; set; }

	/// <summary>
	/// Gets or Sets BookingSummary
	/// </summary>
	[JsonPropertyName("booking_summary")]
	public BookingSummary? BookingSummary { get; set; }
}
