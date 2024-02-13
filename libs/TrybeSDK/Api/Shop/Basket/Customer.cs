// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class Customer
{
	/// <summary>
	/// The ID of the customer.
	/// </summary>
	/// <value>The ID of the customer.</value>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The first name of the customer.
	/// </summary>
	/// <value>The first name of the customer.</value>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// The last name of the customer.
	/// </summary>
	/// <value>The last name of the customer.</value>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// The customer's full name
	/// </summary>
	/// <value>The customer's full name</value>
	[JsonPropertyName("full_name")]
	public string? FullName { get; set; }

	/// <summary>
	/// The customer's phone number
	/// </summary>
	/// <value>The customer's phone number</value>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// Whether the user has a password
	/// </summary>
	/// <value>Whether the user has a password</value>
	[JsonPropertyName("has_password")]
	public bool? HasPassword { get; set; }

	/// <summary>
	/// The customer's date of birth
	/// </summary>
	/// <value>The customer's date of birth</value>
	[JsonPropertyName("dob")]
	public DateTime? Dob { get; set; }

	/// <summary>
	/// The ID of the brand this customer belongs to
	/// </summary>
	/// <value>The ID of the brand this customer belongs to</value>
	[JsonPropertyName("brand_id")]
	public string? BrandId { get; set; }

	/// <summary>
	/// The ID of the site this customer belongs to
	/// </summary>
	/// <value>The ID of the site this customer belongs to</value>
	[JsonPropertyName("site_id")]
	public string? SiteId { get; set; }

	/// <summary>
	/// The Stripe Customer ID for this customer
	/// </summary>
	/// <value>The Stripe Customer ID for this customer</value>
	[JsonPropertyName("stripe_id")]
	public string? StripeId { get; set; }

	/// <summary>
	/// The Stripe Customer ID for this customer if they also exist in Trybe's legacy Stripe integration
	/// </summary>
	/// <value>The Stripe Customer ID for this customer if they also exist in Trybe's legacy Stripe integration</value>
	[JsonPropertyName("express_stripe_id")]
	public string? ExpressStripeId { get; set; }

	/// <summary>
	/// The email address of the customer.
	/// </summary>
	/// <value>The email address of the customer.</value>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// The preferred locale of the customer
	/// </summary>
	/// <value>The preferred locale of the customer</value>
	[JsonPropertyName("preferred_locale")]
	public string? PreferredLocale { get; set; }

	/// <summary>
	/// The datetime which the customer was locked, or null if it has not been locked.
	/// </summary>
	/// <value>The datetime which the customer was locked, or null if it has not been locked.</value>
	[JsonPropertyName("locked_at")]
	public DateTime? LockedAt { get; set; }

	/// <summary>
	/// The datetime which the customer was created
	/// </summary>
	/// <value>The datetime which the customer was created</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The datetime which the customer was last updated
	/// </summary>
	/// <value>The datetime which the customer was last updated</value>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The datetime which the customer was anonymised, or null if it has not been.
	/// </summary>
	/// <value>The datetime which the customer was anonymised, or null if it has not been.</value>
	[JsonPropertyName("deleted_at")]
	public DateTime? DeletedAt { get; set; }

	/// <summary>
	/// The datetime which the customer was last active
	/// </summary>
	/// <value>The datetime which the customer was last active</value>
	[JsonPropertyName("last_active_at")]
	public DateTime? LastActiveAt { get; set; }

	/// <summary>
	/// The datetime which the customer verified their email address
	/// </summary>
	/// <value>The datetime which the customer verified their email address</value>
	[JsonPropertyName("email_verified_at")]
	public DateTime? EmailVerifiedAt { get; set; }

	/// <summary>
	/// An external reference for this customer.
	/// </summary>
	/// <value>An external reference for this customer.</value>
	[JsonPropertyName("external_ref")]
	public string? ExternalRef { get; set; }
}
