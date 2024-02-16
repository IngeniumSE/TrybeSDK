// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Frontend;

partial interface ITrybeFrontendClient
{
	/// <summary>
	/// Gets the /booking-frame operations.
	/// </summary>
	IBookingFrameOperations BookingFrames { get; }
}

partial class TrybeFrontendClient
{
	Lazy<IBookingFrameOperations> _bookingFrames;
	public IBookingFrameOperations BookingFrames => (_bookingFrames ??= Defer<IBookingFrameOperations>(
		c => new BookingFrameOperations(new("/booking-frame"), c))).Value;
}

/// <summary>
/// Provides operations for operating on the /booking-frame endpoint.
/// </summary>
public partial interface IBookingFrameOperations
{
	/// <summary>
	/// Creates a booking frame.
	/// HTTP POST /booking-frame/create
	/// </summary>
	/// <param name="request">The create booking frame request.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The booking frame.</returns>
	Task<TrybeResponse<BookingFrame>> CreateBookingFrameAsync(
		CreateBookingFrameRequest request,
		CancellationToken cancellationToken = default);
}

public class BookingFrameOperations(PathString path, ApiClient client) : IBookingFrameOperations
{
	public async Task<TrybeResponse<BookingFrame>> CreateBookingFrameAsync(
		CreateBookingFrameRequest frameRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNull(frameRequest, nameof(frameRequest));
		var request = new TrybeRequest<CreateBookingFrameRequest>(
			HttpMethod.Post, path + "/create", frameRequest);

		return await client.FetchAsync<CreateBookingFrameRequest, BookingFrame>(
			request, cancellationToken)
			.ConfigureAwait(false);
	}
}
