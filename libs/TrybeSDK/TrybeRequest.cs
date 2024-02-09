// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK;

/// <summary>
/// Represents a request to a Trybe API resource.
/// </summary>
/// <param name="method">The HTTP method.</param>
/// <param name="resource">The relative resource.</param>
public class TrybeRequest(
	HttpMethod method,
	string resource)
{
	/// <summary>
	/// Gets the HTTP method for the request.
	/// </summary>
	public HttpMethod Method => method;

	/// <summary>
	/// Gets the relative resource for the request.
	/// </summary>
	public string Resource => resource;
}

/// <summary>
/// Represents a request to a Trybe API resource.
/// </summary>
/// <param name="method">The HTTP method.</param>
/// <param name="resource">The relative resource.</param>
/// <param name="data">The data.</param>
/// <typeparam name="TData">The data type.</typeparam>
public class TrybeRequest<TData>(
	HttpMethod method,
	string resource,
	TData data) : TrybeRequest(method, resource)
	where TData : notnull
{
	/// <summary>
	/// Gets the model for the request.
	/// </summary>
	public TData Data => data;
}
