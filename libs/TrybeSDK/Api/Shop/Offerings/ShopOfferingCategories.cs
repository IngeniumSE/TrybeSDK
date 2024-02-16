// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

[DebuggerDisplay("{Name,nq} ({Id,nq})")]
public class ShopOfferingCategories : Model<ShopOfferingCategories>
{
	/// <summary>
	/// The ID of the category
	/// </summary>
	/// <value>The ID of the category</value>	
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The name of the category
	/// </summary>
	/// <value>The name of the category</value>	
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
