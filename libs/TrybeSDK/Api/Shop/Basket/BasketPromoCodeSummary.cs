// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class BasketPromoCodeSummary : Model<BasketPromoCodeSummary>
{
	/// <summary>
	/// The ID of the applied promo code.
	/// </summary>
	/// <value>The ID of the applied promo code.</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The code of the applied promo code.
	/// </summary>
	/// <value>The code of the applied promo code.</value>	
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// The discount value of the applied promo code.
	/// </summary>
	/// <value>The discount value of the applied promo code.</value>	
	[JsonPropertyName("percentage")]
	public int? Percentage { get; set; }
}
