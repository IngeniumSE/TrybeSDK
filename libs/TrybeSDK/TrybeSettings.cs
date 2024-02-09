// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using FluentValidation;

using Microsoft.Extensions.Options;

namespace TrybeSDK;

/// <summary>
/// Represents settings for configuring Trybe.
/// </summary>
public class TrybeSettings
{
	public const string ConfigurationSection = "Trybe";

	/// <summary>
	/// Gets or sets the API key.
	/// </summary>
	public string ApiKey { get; set; } = default!;

	/// <summary>
	/// Gets or sets the base URL.
	/// </summary>
	public string ApiUrl { get; set; } = default!;

	/// <summary>
	/// Gets or sets the Trybe Partner ID.
	/// </summary>
	public string? PartnerId { get; set; }

	/// <summary>
	/// Gets or sets whether to capture request content.
	/// </summary>
	public bool CaptureRequestContent { get; set; }

	/// <summary>
	/// Gets or sets whether to capture response content.
	/// </summary>
	public bool CaptureResponseContent { get; set; }

	/// <summary>
	/// Gets or sets the shop URL.
	/// </summary>
	public string ShopUrl { get; set; } = default!;

	/// <summary>
	/// Returns the settings as a wrapped options instance.
	/// </summary>
	/// <returns>The options instance.</returns>
	public IOptions<TrybeSettings> AsOptions()
		=> Options.Create(this);

	/// <summary>
	/// Validates the current instance.
	/// </summary>
	public void Validate()
		=> TrybeSettingsValidator.Instance.Validate(this);
}

/// <summary>
/// Validates instances of <see cref="TrybeSettings"/>.
/// </summary>
public class TrybeSettingsValidator : AbstractValidator<TrybeSettings>
{
	public static readonly TrybeSettingsValidator Instance = new();

	public TrybeSettingsValidator()
	{
		bool ValidateUri(string value)
			=> Uri.TryCreate(value, UriKind.Absolute, out var _);

		RuleFor(s => s.ApiKey)
			.NotEmpty()
			.WithMessage(Resources.TrybeSettingsValidator_ApiKey_ValidationMessage);

		RuleFor(s => s.ApiUrl)
			.NotEmpty()
			.Must(ValidateUri)
			.WithMessage(Resources.TrybeSettingsValidator_ApiUrl_ValidationMessage);

		RuleFor(s => s.ShopUrl)
			.NotEmpty()
			.Must(ValidateUri)
			.WithMessage(Resources.TrybeSettingsValidator_ShopUrl_ValidationMessage);
	}
}
