// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

partial interface IOrderOperations
{
	Task<TrybeResponse<OrderPayment>> AddPaymentAsync(
		string orderId,
		AddPaymentRequest request,
		CancellationToken cancellationToken = default);
}

partial class OrderOperations
{
	public async Task<TrybeResponse<OrderPayment>> AddPaymentAsync(
		string orderId,
		AddPaymentRequest paymentRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(orderId, nameof(orderId));
		Ensure.IsNotNull(paymentRequest, nameof(paymentRequest));

		var request = new TrybeRequest<AddPaymentRequest>(HttpMethod.Post, path + $"/{orderId}/payments", paymentRequest);

		return await client.FetchAsync<AddPaymentRequest, OrderPayment>(request, cancellationToken)
			.ConfigureAwait(false);
	}
}

public class AddPaymentRequest
{
	/// <summary>
	/// Gets the payment amount.
	/// </summary>
	[JsonPropertyName("amount")]
	public int Amount { get; set; }

	/// <summary>
	/// Gets the capture method
	/// </summary>
	[JsonPropertyName("capture_method")]
	public string? CaptureMethod { get; set; }

	/// <summary>
	/// Gets the details source.
	/// </summary>
	[JsonPropertyName("details_source")]
	public string? DetailsSource { get; set; }

	/// <summary>
	/// Gets the processor.
	/// </summary>
	[JsonPropertyName("processor")]
	public string Processor { get; set; }

	/// <summary>
	/// Gets the processor data.
	/// </summary>
	[JsonPropertyName("processor_data")]
	public ObjectDictionary? ProcessorData { get; set; }

	/// <summary>
	/// Gets the payment status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }
}
