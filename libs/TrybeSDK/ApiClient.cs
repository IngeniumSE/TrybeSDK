// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrybeSDK;

/// <summary>
/// Provides a base implementation of an API client.
/// </summary>
public abstract class ApiClient
{
	readonly HttpClient _http;
	readonly TrybeSettings _settings;
	readonly JsonSerializerOptions _serializerOptions = JsonUtility.CreateSerializerOptions();
	readonly Uri _baseUrl;

	protected ApiClient(HttpClient http, TrybeSettings settings, string baseUrl)
	{
		_http = Ensure.IsNotNull(http, nameof(http));
		_settings = Ensure.IsNotNull(settings, nameof(settings));
		_baseUrl = new Uri(baseUrl);
	}

	protected async Task<TrybeResponse> SendAsync<TRequest>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
	{
		Ensure.IsNotNull(request, nameof(request));

		var httpReq = CreateHttpRequest(request);
		var httpResp = await _http.SendAsync(httpReq, cancellationToken);

		return await GetResponse(httpReq.Method, httpReq.RequestUri, httpResp);
	}

	protected async Task<TrybeResponse<TResponse>> SendAsync<TRequest, TResponse>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
		where TResponse : class
	{
		Ensure.IsNotNull(request, nameof(request));

		var httpReq = CreateHttpRequest(request);
		var httpResp = await _http.SendAsync(httpReq, cancellationToken);

		return await GetResponse<TResponse>(httpReq.Method, httpReq.RequestUri, httpResp);
	}

	protected async Task<TrybeResponse> GetResponse(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
	{
		async Task<TrybeError> GetTrybeError()
		{
			TrybeError error;
			if (response.Content is not null)
			{
				var result = await response.Content.ReadFromJsonAsync<Error>(cancellationToken);
				if (result?.Message is not { Length: > 0 })
				{
					error = new TrybeError(method, uri, response.StatusCode)
					{
						Message = Resources.ApiClient_UnknownResponse
					};
				}
				else
				{
					error = new TrybeError(method, uri, response.StatusCode)
					{
						Message = result.Message
					};
				}

				if (_settings.CaptureResponseContent)
				{
					error.ResponseContent = await response.Content.ReadAsStringAsync();
				}
			}
			else
			{
				error = new TrybeError(method, uri, response.StatusCode)
				{
					Message = Resources.ApiClient_NoErrorMessage
				};
			}

			return error;
		}

		if (response.IsSuccessStatusCode)
		{
			return new TrybeResponse(method, uri, response.IsSuccessStatusCode, response.StatusCode);
		}

		return await GetTrybeError();
	}

	protected async Task<TrybeResponse<TResponse>> GetResponse<TResponse>(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
		where TResponse : class
	{
		async Task<TrybeError<TResponse>> GetTrybeError()
		{
			TrybeError<TResponse> error;
			if (response.Content is not null)
			{
				var result = await response.Content.ReadFromJsonAsync<Error>(cancellationToken);
				if (result?.Message is not { Length: > 0 })
				{
					error = new TrybeError<TResponse>(method, uri, response.StatusCode)
					{
						Message = Resources.ApiClient_UnknownResponse
					};
				}
				else
				{
					error = new TrybeError<TResponse>(method, uri, response.StatusCode)
					{
						Message = result.Message
					};
				}

				if (_settings.CaptureResponseContent)
				{
					error.ResponseContent = await response.Content.ReadAsStringAsync();
				}
			}
			else
			{
				error = new TrybeError<TResponse>(method, uri, response.StatusCode)
				{
					Message = Resources.ApiClient_NoErrorMessage
				};
			}

			return error;
		}

		if (response.IsSuccessStatusCode)
		{
			TResponse? data = default;
			if (response.Content is not null)
			{
				data = await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken);
			}

			return new TrybeResponse<TResponse>(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				data
			);
		}

		return await GetTrybeError();
	}

	protected HttpRequestMessage CreateHttpRequest(
		TrybeRequest request)
	{
		var uri = new Uri(_baseUrl, request.Resource);

		var message = new HttpRequestMessage(request.Method, uri);

		return message;
	}

	protected HttpRequestMessage CreateHttpRequest<TRequest>(
		TrybeRequest<TRequest> request)
		where TRequest : notnull
	{
		var message = CreateHttpRequest((TrybeRequest)request);

		message.Content = JsonContent.Create(
			inputValue: request.Data, options: _serializerOptions);

		return message;
	}

	class Error
	{
		[JsonPropertyName("message")]
		public string Message { get; set; } = default!;
	}
}
