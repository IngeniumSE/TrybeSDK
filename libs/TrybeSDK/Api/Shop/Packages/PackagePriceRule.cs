// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PackagePriceRule
{
	/// <summary>
	/// The ID of the price rule.
	/// </summary>
	/// <value>The ID of the price rule.</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The ID of the package the price rule relates to.
	/// </summary>
	/// <value>The ID of the package the price rule relates to.</value>	
	[JsonPropertyName("package_id")]
	public required string PackageId { get; set; }

	/// <summary>
	/// The rule should apply to packages starting on or after this date.
	/// </summary>
	/// <value>The rule should apply to packages starting on or after this date.</value>	
	[JsonPropertyName("date_from")]
	public DateTime? DateFrom { get; set; }

	/// <summary>
	/// The rule should not apply to packages starting after this date.
	/// </summary>
	/// <value>The rule should not apply to packages starting after this date.</value>	
	[JsonPropertyName("date_to")]
	public DateTime? DateTo { get; set; }

	/// <summary>
	/// The rule should apply to packages starting on any of these weekdays.
	/// </summary>
	/// <value>The rule should apply to packages starting on any of these weekdays.</value>	
	[JsonPropertyName("weekdays")]
	public List<string>? Weekdays { get; set; }

	/// <summary>
	/// The price of the package.
	/// </summary>
	/// <value>The price of the package.</value>	
	[JsonPropertyName("price")]
	public int? Price { get; set; }
}
