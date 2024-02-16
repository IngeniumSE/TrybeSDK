// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net;
using System.Net.Http.Headers;
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
	readonly JsonSerializerOptions _deserializerOptions = JsonUtility.CreateDeserializerOptions();
	readonly Uri _baseUrl;

	protected ApiClient(HttpClient http, TrybeSettings settings, string baseUrl)
	{
		_http = Ensure.IsNotNull(http, nameof(http));
		_settings = Ensure.IsNotNull(settings, nameof(settings));
		_baseUrl = new Uri(baseUrl);
	}

	#region Send and Fetch
	protected internal async Task<TrybeResponse> SendAsync(
		TrybeRequest request,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNull(request, nameof(request));
		var httpReq = CreateHttpRequest(request);

		try
		{
			var httpResp = await _http.SendAsync(httpReq, cancellationToken);

			var transformedResponse = await TransformResponse(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp);

			if (_settings.CaptureRequestContent && httpReq.Content is not null)
			{
				transformedResponse.RequestContent = await httpReq.Content.ReadAsStringAsync();
			}

			if (_settings.CaptureResponseContent && httpResp.Content is not null)
			{
				transformedResponse.ResponseContent = await httpResp.Content.ReadAsStringAsync();
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			return new TrybeResponse(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));
		}
	}

	protected internal async Task<TrybeResponse> SendAsync<TRequest>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
	{
		Ensure.IsNotNull(request, nameof(request));
		var httpReq = CreateHttpRequest(request);

		try
		{
			var httpResp = await _http.SendAsync(httpReq, cancellationToken);

			var transformedResponse = await TransformResponse(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp);

			if (_settings.CaptureRequestContent && httpReq.Content is not null)
			{
				transformedResponse.RequestContent = await httpReq.Content.ReadAsStringAsync();
			}

			if (_settings.CaptureResponseContent && httpResp.Content is not null)
			{
				transformedResponse.ResponseContent = await httpResp.Content.ReadAsStringAsync();
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			return new TrybeResponse(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));
		}
	}

	protected internal async Task<TrybeResponse<TResponse>> FetchAsync<TResponse>(
		TrybeRequest request,
		CancellationToken cancellationToken = default)
		where TResponse : class
	{
		Ensure.IsNotNull(request, nameof(request));
		var httpReq = CreateHttpRequest(request);

		try
		{
			var httpResp = await _http.SendAsync(httpReq, cancellationToken);

			var transformedResponse = await TransformResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp);

			if (_settings.CaptureRequestContent && httpReq.Content is not null)
			{
				transformedResponse.RequestContent = await httpReq.Content.ReadAsStringAsync();
			}

			if (_settings.CaptureResponseContent && httpResp.Content is not null)
			{
				transformedResponse.ResponseContent = await httpResp.Content.ReadAsStringAsync();
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			return new TrybeResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));
		}
	}

	protected internal async Task<TrybeResponse<TResponse>> FetchAsync<TRequest, TResponse>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
		where TResponse : class
	{
		Ensure.IsNotNull(request, nameof(request));
		var httpReq = CreateHttpRequest(request);

		try
		{
			var httpResp = await _http.SendAsync(httpReq, cancellationToken);

			var transformedResponse = await TransformResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp);

			if (_settings.CaptureRequestContent && httpReq.Content is not null)
			{
				transformedResponse.RequestContent = await httpReq.Content.ReadAsStringAsync();
			}

			if (_settings.CaptureResponseContent && httpResp.Content is not null)
			{
				transformedResponse.ResponseContent = await httpResp.Content.ReadAsStringAsync();
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			return new TrybeResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));
		}
	}
	#endregion

	#region Preprocessing
	protected internal HttpRequestMessage CreateHttpRequest(
		TrybeRequest request)
	{
		string pathAndQuery = request.Resource.ToUriComponent();
		if (request.Query.HasValue)
		{
			pathAndQuery += request.Query.Value.ToUriComponent();
		}
		var uri = new Uri(_baseUrl, pathAndQuery);


		var message = new HttpRequestMessage(request.Method, uri);
		message.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_settings.ApiKey}");

		return message;
	}

	protected internal HttpRequestMessage CreateHttpRequest<TRequest>(
		TrybeRequest<TRequest> request)
		where TRequest : notnull
	{
		var message = CreateHttpRequest((TrybeRequest)request);

		message.Content = JsonContent.Create(
			inputValue: request.Data, options: _serializerOptions);

		return message;
	}
	#endregion

	#region Postprocessing
	protected internal async Task<TrybeResponse> TransformResponse(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
	{
		async Task<Error> GetTrybeError()
		{
			Error error;
			if (response.Content is not null)
			{
				var result = await response.Content.ReadFromJsonAsync<ErrorContainer>(cancellationToken);
				if (result?.Message is not { Length: > 0 })
				{
					error = new(Resources.ApiClient_UnknownResponse, result?.Errors);
				}
				else
				{
					error = new(result.Message, result.Errors);
				}
			}
			else
			{
				error = new Error(Resources.ApiClient_NoErrorMessage);
			}

			return error;
		}

		if (response.IsSuccessStatusCode)
		{
			return new TrybeResponse(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode);
		}
		else
		{
			Error? error = await GetTrybeError();

			return new TrybeResponse(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				error: error
			);
		}
	}

	protected internal async Task<TrybeResponse<TResponse>> TransformResponse<TResponse>(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
		where TResponse : class
	{
		async Task<Error> GetTrybeError()
		{
			Error error;
			if (response.Content is not null)
			{
				var result = await response.Content.ReadFromJsonAsync<ErrorContainer>(
					_deserializerOptions, cancellationToken);
				if (result?.Message is not { Length: > 0 })
				{
					error = new(Resources.ApiClient_UnknownResponse, result?.Errors);
				}
				else
				{
					error = new(result.Message, result.Errors);
				}
			}
			else
			{
				error = new Error(Resources.ApiClient_NoErrorMessage);
			}

			return error;
		}

		var rateLimiting = GetRateLimiting(response);

		if (response.IsSuccessStatusCode)
		{
			DataContainer<TResponse>? data = default;
			Meta? meta = default;
			if (response.Content is not null)
			{
				data = await response.Content.ReadFromJsonAsync<DataContainer<TResponse>>(
					_deserializerOptions, cancellationToken);

				if (data?.Meta is not null)
				{
					meta = new Meta
					{
						Page = data.Meta.CurrentPage,
						PageSize = data.Meta.PerPage,
						TotalItems = data.Meta.Total,
						TotalPages = data.Meta.LastPage
					};
				}
			}

			return new TrybeResponse<TResponse>(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				data: data?.Data,
				meta: meta,
				rateLimiting: rateLimiting
			);
		}
		else
		{
			Error? error = await GetTrybeError();

			return new TrybeResponse<TResponse>(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				rateLimiting: rateLimiting,
				error: error
			);
		}
	}

	RateLimiting? GetRateLimiting(HttpResponseMessage response)
	{
		var headers = response.Headers;

		return int.TryParse(GetHeader("X-Ratelimit-Remaining", headers), out int remaining)
			&& int.TryParse(GetHeader("X-Ratelimit-Limit", headers), out int limit)
			? new RateLimiting { Limit = limit, Remaining = remaining } : null;
	}

	string? GetHeader(string name, HttpHeaders headers)
		=> headers.TryGetValues(name, out var values)
		? values.First()
		: null;

	class ErrorContainer
	{
		[JsonPropertyName("errors")]
		public Dictionary<string, string[]>? Errors { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; } = default!;
	}

	class DataContainer<TData>
	{
		[JsonPropertyName("data")]
		public TData? Data { get; set; }

		[JsonPropertyName("meta")]
		public MetaContainer? Meta { get; set; }
	}

	class MetaContainer
	{
		[JsonPropertyName("current_page")]
		public int CurrentPage { get; set; }

		[JsonPropertyName("from")]
		public int From { get; set; }

		[JsonPropertyName("last_page")]
		public int LastPage { get; set; }

		[JsonPropertyName("per_page")]
		public int PerPage { get; set; }

		[JsonPropertyName("to")]
		public int To { get; set; }

		[JsonPropertyName("total")]
		public int Total { get; set; }
	}
	#endregion

	protected internal Lazy<TOperations> Defer<TOperations>(Func<ApiClient, TOperations> factory)
		=> new Lazy<TOperations>(() => factory(this));

	protected internal Uri Root(string resource)
		=> new Uri(resource, UriKind.Relative);
}
