// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

[DebuggerDisplay("{Name,nq} ({Id,nq})")]
public class PackageItemChoice
{
	/// <summary>
	/// The ID of this choice.
	/// </summary>
	/// <value>The ID of this choice.</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// A name for this choice.
	/// </summary>
	/// <value>A name for this choice.</value>	
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// A description of this choice.
	/// </summary>
	/// <value>A description of this choice.</value>	
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The minimum number of options that must be chosen.
	/// </summary>
	/// <value>The minimum number of options that must be chosen.</value>	
	[JsonPropertyName("min_options")]
	public int? MinOptions { get; set; }

	/// <summary>
	/// The maximum number of options that may be chosen.
	/// </summary>
	/// <value>The maximum number of options that may be chosen.</value>	
	[JsonPropertyName("max_options")]
	public int? MaxOptions { get; set; }

	/// <summary>
	/// The budget that this package allows for options in this choice. Each option will use its standalone price, and the overall package price will be increased if the total exceeds the budget. 
	/// </summary>
	/// <value>The budget that this package allows for options in this choice. Each option will use its standalone price, and the overall package price will be increased if the total exceeds the budget. </value>

	[JsonPropertyName("option_budget")]
	public int? OptionBudget { get; set; }

	/// <summary>
	/// Whether a timeslot should be automatically selected for this choice
	/// </summary>
	/// <value>Whether a timeslot should be automatically selected for this choice</value>	
	[JsonPropertyName("auto_select_timeslot")]
	public bool? AutoSelectTimeslot { get; set; }

	/// <summary>
	/// Whether to hide times for this choice from customers
	/// </summary>
	/// <value>Whether to hide times for this choice from customers</value>	
	[JsonPropertyName("hide_times")]
	public bool? HideTimes { get; set; }

	/// <summary>
	/// Whether this item choice should be optional.
	/// </summary>
	/// <value>Whether this item choice should be optional.</value>	
	[JsonPropertyName("optional")]
	public bool? Optional { get; set; }

	/// <summary>
	/// Whether this item choice should be visible to the customer.
	/// </summary>
	/// <value>Whether this item choice should be visible to the customer.</value>	
	[JsonPropertyName("visible")]
	public bool? Visible { get; set; }

	/// <summary>
	/// Allow this choice to overlap with other items when `prevent_choice_overlaps` is enabled on the package.
	/// </summary>
	/// <value>Allow this choice to overlap with other items when `prevent_choice_overlaps` is enabled on the package.</value>	
	[JsonPropertyName("allow_overlaps")]
	public bool? AllowOverlaps { get; set; }

	/// <summary>
	/// The type of offerings included in this choice.
	/// </summary>
	/// <value>The type of offerings included in this choice.</value>	
	[JsonPropertyName("offering_type")]
	public string? OfferingType { get; set; }

	/// <summary>
	/// Gets or Sets Allocation
	/// </summary>	
	[JsonPropertyName("allocation")]
	public OfferingRevenueAllocation? Allocation { get; set; }

	/// <summary>
	/// An array of rules determining the start times that should be allowed for this choice.
	/// </summary>
	/// <value>An array of rules determining the start times that should be allowed for this choice.</value>	
	[JsonPropertyName("start_time_rules")]
	public List<PackageChoiceStartTimeRule>? StartTimeRules { get; set; }

	/// <summary>
	/// An array of options to make up this choice.
	/// </summary>
	/// <value>An array of options to make up this choice.</value>	
	[JsonPropertyName("options")]
	public List<PackageItemChoiceOption>? Options { get; set; }
}
