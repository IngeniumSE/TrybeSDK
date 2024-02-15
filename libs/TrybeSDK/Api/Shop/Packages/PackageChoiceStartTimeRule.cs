// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PackageChoiceStartTimeRule : Model<PackageChoiceStartTimeRule>
{
	/// <summary>
	/// The type of the rule.
	/// </summary>
	/// <value>The type of the rule.</value>	
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The base time that a relative start time should be calculated from.
	/// </summary>
	/// <value>The base time that a relative start time should be calculated from.</value>	
	[JsonPropertyName("relative_to")]
	public string? RelativeTo { get; set; }

	/// <summary>
	/// The minimum number of minutes from the relative base point that should be allowed.
	/// </summary>
	/// <value>The minimum number of minutes from the relative base point that should be allowed.</value>	
	[JsonPropertyName("relative_mins_from")]
	public int? RelativeMinsFrom { get; set; }

	/// <summary>
	/// The maximum number of minutes from the relative base point that should be allowed.
	/// </summary>
	/// <value>The maximum number of minutes from the relative base point that should be allowed.</value>	
	[JsonPropertyName("relative_mins_to")]
	public int? RelativeMinsTo { get; set; }

	/// <summary>
	/// The earliest allowed start time.
	/// </summary>
	/// <value>The earliest allowed start time.</value>	
	[JsonPropertyName("absolute_time_from")]
	public string? AbsoluteTimeFrom { get; set; }

	/// <summary>
	/// The latest allowed start time.
	/// </summary>
	/// <value>The latest allowed start time.</value>	
	[JsonPropertyName("absolute_time_to")]
	public string? AbsoluteTimeTo { get; set; }
}
