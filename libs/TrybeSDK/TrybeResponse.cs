// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net;

namespace TrybeSDK;

/// <summary>
/// Represents a Trybe response.
/// </summary>
/// <param name="method">The HTTP method requested.</param>
/// <param name="uri">The URI requested.</param>
/// <param name="isSuccess">States whether the status code is a success HTTP status code.</param>
/// <param name="statusCode">The HTTP status code returned.</param>
/// <param name="meta">The paging metadata for the request, if available.</param>
/// <param name="rateLimiting">The rate limiting metadata for the request, if available.</param>
/// <param name="error">The API error, if available.</param>
public class TrybeResponse(
	HttpMethod method,
	Uri uri,
	bool isSuccess,
	HttpStatusCode statusCode,
	Meta? meta = default,
	RateLimiting? rateLimiting = default,
	Error? error = default)
{
	/// <summary>
	/// Gets whether the status code represents a success HTTP status code.
	/// </summary>
	public bool IsSuccess => isSuccess;

	/// <summary>
	/// Gets the error.
	/// </summary>
	public Error? Error => error;

	/// <summary>
	/// Gets th metadata.
	/// </summary>
	public Meta? Meta => meta;

	/// <summary>
	/// Gets the HTTP status code of the response.
	/// </summary>
	public HttpStatusCode StatusCode => statusCode;

	/// <summary>
	/// Gets the rate limiting metdata for the request.
	/// </summary>
	public RateLimiting? RateLimiting => rateLimiting;

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
/// <param name="isSuccess">States whether the status code is a success HTTP status code.</param>
/// <param name="statusCode">The HTTP status code.</param>
/// <param name="data">The API response data, if available.</param>
/// <param name="meta">The paging metadata for the request, if available.</param>
/// <param name="rateLimiting">The rate limiting metadata for the request, if available.</param>
/// <param name="error">The API error, if available.</param>
/// <typeparam name="TData">The data type.</typeparam>
public class TrybeResponse<TData>(
	HttpMethod method,
	Uri uri,
	bool isSuccess,
	HttpStatusCode statusCode,
	TData? data = default,
	Meta? meta = default,
	RateLimiting? rateLimiting = default,
	Error? error = default) : TrybeResponse(method, uri, isSuccess, statusCode, meta, rateLimiting, error)
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
/// <param name="message">The error message.</param>
/// <param name="errors">The set of additional error messages, these may be field specific.</param>
public class Error(string message, Dictionary<string, string[]>? errors = null)
{
	/// <summary>
	/// Gets the set of additional error messages, these may be field specific.
	/// </summary>
	public Dictionary<string, string[]>? Errors => errors;

	/// <summary>
	/// Gets the error message.
	/// </summary>
	public string Message => message;
}

/// <summary>
/// Represents metadata for a Trybe request.
/// </summary>
public class Meta
{
	/// <summary>
	/// Gets the current page.
	/// </summary>
	public int Page { get; init; }

	/// <summary>
	/// Gets the page size.
	/// </summary>
	public int PageSize { get; init; }

	/// <summary>
	/// Gets or sets the total number of items.
	/// </summary>
	public int TotalItems { get; init; }

	/// <summary>
	/// Gets or sets the total number of pages.
	/// </summary>
	public int TotalPages { get; init; }
}

/// <summary>
/// Represents rate-limiting information for a Trybe request.
/// </summary>
public class RateLimiting
{
	/// <summary>
	/// Gets the remaining number of calls available.
	/// </summary>
	public int Remaining { get; init; }

	/// <summary>
	/// Gets the limit of calls available.
	/// </summary>
	public int Limit { get; init; }
}
