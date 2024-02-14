// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OfferingEmailOptions
{
	/// <summary>
	/// Enable to hide prices from customer emails, in cases where the customer didn't purchase the item directly.
	/// </summary>
	/// <value>Enable to hide prices from customer emails, in cases where the customer didn't purchase the item directly.</value>
	[JsonPropertyName("hide_prices")]
	public bool? HidePrices { get; set; }
}
