// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket item validity instance.
/// </summary>
public class BasketItemValidity
{
	/// <summary>
	/// Whether the given basket item is valid.
	/// </summary>
	/// <value>Whether the given basket item is valid.</value>
	[JsonPropertyName("valid")]
	public required bool? Valid { get; set; }

	/// <summary>
	/// The array of error messages.
	/// </summary>
	/// <value>The array of error messages.</value>
	[JsonPropertyName("errors")]
	public List<BasketItemValidityErrors>? Errors { get; set; }
}

/// <summary>
/// A basket item validity error instance.
/// </summary>
public class BasketItemValidityErrors
{
	/// <summary>
	/// A friendly description of the error.
	/// </summary>
	/// <value>A friendly description of the error.</value>
	[JsonPropertyName("message")]
	public required string Message { get; set; }
}
