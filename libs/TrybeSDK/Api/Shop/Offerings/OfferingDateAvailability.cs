// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

[DebuggerDisplay("{ToDebuggerString(),nq}")]
public class OfferingDateAvailability : Model<OfferingDateAvailability>
{
	/// <summary>
	/// The date availability is for.
	/// </summary>
	/// <value>The date availability is for.</value>	
	[JsonPropertyName("date")]
	public required DateTime Date { get; set; }

	/// <summary>
	/// Whether there is availability for the offering on this date.
	/// </summary>
	/// <value>Whether there is availability for the offering on this date.</value>	
	[JsonPropertyName("has_availability")]
	public required bool HasAvailability { get; set; }

	public string ToDebuggerString()
		=> $"{Date:yyyy-MM-dd}: ({(HasAvailability ? "available" : "unavailable")})";
}
