// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket item option budget instance.
/// </summary>
public class BasketItemOptionBudget
{
	/// <summary>
	/// The ID of the choice this option budget belongs to.
	/// </summary>
	/// <value>The ID of the choice this option budget belongs to.</value>
	[JsonPropertyName("choice_id")]
	public required string ChoiceId { get; init; }

	/// <summary>
	/// The amount of the budget, in the smallest denomination.
	/// </summary>
	/// <value>The amount of the budget, in the smallest denomination.</value>
	[JsonPropertyName("budget")]
	public required string Budget { get; init; }

	/// <summary>
	/// The amount spent towards the budget, in the smallest denomination.
	/// </summary>
	/// <value>The amount spent towards the budget, in the smallest denomination.</value>
	[JsonPropertyName("spent")]
	public string? Spent { get; init; }

	/// <summary>
	/// The amount of the budget remaining to be spent, in the smallest denomination.
	/// </summary>
	/// <value>The amount of the budget remaining to be spent, in the smallest denomination.</value>
	[JsonPropertyName("remaining")]
	public string? Remaining { get; init; }
}
