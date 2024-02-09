// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net;

namespace TrybeSDK;

/// <summary>
/// Represents a Trybe response.
/// </summary>
/// <param name="method">The HTTP method requested.</param>
/// <param name="uri">The URI requested.</param>
/// <param name="isSuccessStatusCode">States whether the status code is a success HTTP status code.</param>
/// <param name="statusCode">The HTTP status code returned.</param>
public class TrybeResponse(
	HttpMethod method,
	Uri uri,
	bool isSuccessStatusCode,
	HttpStatusCode statusCode)
{
	/// <summary>
	/// Gets whether the status code represents a success HTTP status code.
	/// </summary>
	public bool IsSuccessStatusCode => isSuccessStatusCode;

	/// <summary>
	/// Gets the HTTP status code of the response.
	/// </summary>
	public HttpStatusCode StatusCode => statusCode;

	/// <summary>
	/// Gets or sets the request HTTP method.
	/// </summary>
	public HttpMethod RequestMethod => method;

	/// <summary>
	/// Gets or sets the request URI.
	/// </summary>
	public Uri RequestUri => uri;

	/// <summary>
	/// Gets or sets the request content, when logging is enabled.
	/// </summary>
	public string? RequestContent { get; set; }

	/// <summary>
	/// Gets or sets the response content, when logging is enabled.
	/// </summary>
	public string? ResponseContent { get; set; }
}

/// <summary>
/// Represents a Trybe response with payload data.
/// </summary>
/// <param name="method">The HTTP method requested.</param>
/// <param name="uri">The URI requested.</param>
/// <param name="isSuccessStatusCode">States whether the status code is a success HTTP status code.</param>
/// <param name="statusCode">The HTTP status code.</param>
/// <typeparam name="TData">The data type.</typeparam>
public class TrybeResponse<TData>(
	HttpMethod method,
	Uri uri,
	bool isSuccessStatusCode,
	HttpStatusCode statusCode,
	TData? data) : TrybeResponse(method, uri, isSuccessStatusCode, statusCode)
	where TData : class
{
	/// <summary>
	/// Gets the response data.
	/// </summary>
	public TData? Data => data;

	/// <summary>
	/// Gets whether the response has data.
	/// </summary>
	public bool HasData => data is not null;
}

/// <summary>
/// Represents a Trybe error response.
/// </summary>
/// <param name="method">The HTTP method requested.</param>
/// <param name="uri">The URI requested.</param>
/// <param name="statusCode">The HTTP status code.</param>
public class TrybeError(
	HttpMethod method,
	Uri uri,
	HttpStatusCode statusCode)
	: TrybeResponse(method, uri, false, statusCode)
{
	/// <summary>
	/// Gets the error message.
	/// </summary>
	public string Message { get; set; } = default!;
}
/// <summary>
/// Represents a Trybe error response.
/// </summary>
/// <param name="method">The HTTP method requested.</param>
/// <param name="uri">The URI requested.</param>
/// <param name="statusCode">The HTTP status code.</param>
/// <typeparam name="TData">The data type.</typeparam>
public class TrybeError<TData>(
	HttpMethod method,
	Uri uri,
	HttpStatusCode statusCode)
	: TrybeResponse<TData>(method, uri, false, statusCode, default)
	where TData : class
{
	/// <summary>
	/// Gets the error message.
	/// </summary>
	public string Message { get; set; } = default!;
}
