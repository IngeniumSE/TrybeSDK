﻿// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PractitionerSummary : Model<PractitionerSummary>
{
	/// <summary>
	/// The ID of the practitioner.
	/// </summary>
	/// <value>The ID of the practitioner.</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The full name of the practitioner.
	/// </summary>
	/// <value>The full name of the practitioner.</value>
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
