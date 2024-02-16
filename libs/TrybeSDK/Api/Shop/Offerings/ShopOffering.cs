// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

[DebuggerDisplay("{ToDebuggerString(),nq}")]
public class ShopOffering : ShopOffering<ShopOffering> { }

[DebuggerDisplay("{ToDebuggerString(),nq}")]
public class ShopOffering<T> : Model<T>
	where T : ShopOffering<T>
{
	/// <summary>
	/// The ID of the offering
	/// </summary>
	/// <value>The ID of the offering</value>	
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The name of the offering
	/// </summary>
	/// <value>The name of the offering</value>	
	[JsonPropertyName("name")]
	public string Name { get; set; }

	/// <summary>
	/// The name of the offering
	/// </summary>
	/// <value>The name of the offering</value>	
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The minimum price of the offering on the given date
	/// </summary>
	/// <value>The minimum price of the offering on the given date</value>	
	[JsonPropertyName("price_from")]
	public int? PriceFrom { get; set; }

	/// <summary>
	/// The maximum price of the offering on the given date
	/// </summary>
	/// <value>The maximum price of the offering on the given date</value>	
	[JsonPropertyName("price_to")]
	public int? PriceTo { get; set; }

	/// <summary>
	/// If set, a discounted 'price from' that applies to the current customer
	/// </summary>
	/// <value>If set, a discounted 'price from' that applies to the current customer</value>	
	[JsonPropertyName("discounted_price_from")]
	public int? DiscountedPriceFrom { get; set; }

	/// <summary>
	/// The currency code for the price
	/// </summary>
	/// <value>The currency code for the price</value>	
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The duration of the offering in minutes
	/// </summary>
	/// <value>The duration of the offering in minutes</value>	
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// Gets or Sets Durations
	/// </summary>

	[JsonPropertyName("durations")]
	public List<int>? Durations { get; set; }

	/// <summary>
	/// Identifies the type of this model
	/// </summary>
	/// <value>Identifies the type of this model</value>	
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Whether there is availability for the offering on the requested date.
	/// </summary>
	/// <value>Whether there is availability for the offering on the requested date.</value>	
	[JsonPropertyName("has_availability")]
	public bool? HasAvailability { get; set; }

	/// <summary>
	/// The next available date if there is no availability on the given date
	/// </summary>
	/// <value>The next available date if there is no availability on the given date</value>	
	[JsonPropertyName("next_available_date")]
	public DateTime? NextAvailableDate { get; set; }

	/// <summary>
	/// An array of choices for items which may be included in this package
	/// </summary>
	/// <value>An array of choices for items which may be included in this package</value>	
	[JsonPropertyName("item_choices")]
	public List<PackageItemChoice>? ItemChoices { get; set; }

	/// <summary>
	/// The minimum guests this offering is for
	/// </summary>
	/// <value>The minimum guests this offering is for</value>

	[JsonPropertyName("min_guests")]
	public int? MinGuests { get; set; }

	/// <summary>
	/// The maximum guests this offering is for
	/// </summary>
	/// <value>The maximum guests this offering is for</value>

	[JsonPropertyName("max_guests")]
	public int? MaxGuests { get; set; }

	/// <summary>
	/// Gets or Sets Categories
	/// </summary>	
	[JsonPropertyName("categories")]
	public List<ShopOfferingCategories>? Categories { get; set; }

	public string ToDebuggerString() => $"{Name} ({Id})";
}
