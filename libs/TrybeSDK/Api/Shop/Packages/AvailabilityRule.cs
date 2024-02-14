// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class AvailabilityRule
{
	/// <summary>
	/// The ID of the availability rule.
	/// </summary>
	/// <value>The ID of the availability rule.</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The start of the rule period.
	/// </summary>
	/// <value>The start of the rule period.</value>	
	[JsonPropertyName("date_from")]
	public DateTime? DateFrom { get; set; }

	/// <summary>
	/// The end of the rule period.
	/// </summary>
	/// <value>The end of the rule period.</value>	
	[JsonPropertyName("date_to")]
	public DateTime? DateTo { get; set; }

	/// <summary>
	/// The daily start time of the time period, in 24 hour format.
	/// </summary>
	/// <value>The daily start time of the time period, in 24 hour format.</value>	
	[JsonPropertyName("time_from")]
	public string? TimeFrom { get; set; }

	/// <summary>
	/// The daily end time of the time period, in 24 hour format.
	/// </summary>
	/// <value>The daily end time of the time period, in 24 hour format.</value>	
	[JsonPropertyName("time_to")]
	public string? TimeTo { get; set; }

	/// <summary>
	/// The weekday this rule applies to.
	/// </summary>
	/// <value>The weekday this rule applies to.</value>	
	[JsonPropertyName("weekday")]
	public string? Weekday { get; set; }

	/// <summary>
	/// The weekdays this rule applies to.
	/// </summary>
	/// <value>The weekdays this rule applies to.</value>	
	[JsonPropertyName("weekdays")]
	public List<string>? Weekdays { get; set; }

	/// <summary>
	/// Whether the resource is available during this period. Any `false` rules will override `true` rules.
	/// </summary>
	/// <value>Whether the resource is available during this period. Any `false` rules will override `true` rules.</value>	
	[JsonPropertyName("is_available")]
	public bool? IsAvailable { get; set; }
}
