﻿// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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
		using var httpReq = CreateHttpRequest(request);
		HttpResponseMessage? httpResp = null;

		try
		{
			httpResp = await _http.SendAsync(httpReq, cancellationToken)
				.ConfigureAwait(false);

			var (transformedResponse, capturedResponseContent) = await TransformResponse(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp)
				.ConfigureAwait(false);

			if (_settings.CaptureResponseContent || !httpResp.IsSuccessStatusCode)
			{
				transformedResponse.ResponseContent = capturedResponseContent;
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			var response = new TrybeResponse(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));

			return response;
		}
	}

	protected internal async Task<TrybeResponse> SendAsync<TRequest>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
	{
		Ensure.IsNotNull(request, nameof(request));
		var (httpReq, capturedRequestContent) = CreateHttpRequest(request);
		HttpResponseMessage? httpResp = null;

		try
		{
			httpResp = await _http.SendAsync(httpReq, cancellationToken)
				.ConfigureAwait(false);

			var (transformedResponse, capturedResponseContent) = await TransformResponse(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp)
					.ConfigureAwait(false); ;

			if (_settings.CaptureRequestContent)
			{
				transformedResponse.RequestContent = capturedRequestContent;
			}

			if (_settings.CaptureResponseContent || !httpResp.IsSuccessStatusCode)
			{
				transformedResponse.ResponseContent = capturedResponseContent;
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			var response = new TrybeResponse(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));

			return response;
		}
	}

	protected internal async Task<TrybeResponse<TResponse>> FetchAsync<TResponse>(
		TrybeRequest request,
		CancellationToken cancellationToken = default)
		where TResponse : class
	{
		Ensure.IsNotNull(request, nameof(request));
		var httpReq = CreateHttpRequest(request);
		HttpResponseMessage? httpResp = null;

		try
		{
			httpResp = await _http.SendAsync(httpReq, cancellationToken)
				.ConfigureAwait(false);

			var (transformedResponse, capturedResponseContent) = await TransformResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp)
					.ConfigureAwait(false);

			if (_settings.CaptureResponseContent || !httpResp.IsSuccessStatusCode)
			{
				transformedResponse.ResponseContent = capturedResponseContent;
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			var response = new TrybeResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));

			return response;
		}
		finally
		{
			if (httpReq is not null)
			{
				httpReq.Dispose();
			}

			if (httpResp is not null)
			{
				httpResp.Dispose();
			}
		}
	}

	protected internal async Task<TrybeResponse<TResponse>> FetchAsync<TRequest, TResponse>(
		TrybeRequest<TRequest> request,
		CancellationToken cancellationToken = default)
		where TRequest : notnull
		where TResponse : class
	{
		Ensure.IsNotNull(request, nameof(request));
		var (httpReq, capturedRequestContent) = CreateHttpRequest(request);
		HttpResponseMessage? httpResp = null;

		try
		{
			httpResp = await _http.SendAsync(httpReq, cancellationToken)
				.ConfigureAwait(false);

			var (transformedResponse, capturedResponseContent) = await TransformResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				httpResp)
					.ConfigureAwait(false); ;

			if (_settings.CaptureRequestContent)
			{
				transformedResponse.RequestContent = capturedRequestContent;
			}

			if (_settings.CaptureResponseContent || !httpResp.IsSuccessStatusCode)
			{
				transformedResponse.ResponseContent = capturedResponseContent;
			}

			return transformedResponse;
		}
		catch (Exception ex)
		{
			var response = new TrybeResponse<TResponse>(
				httpReq.Method,
				httpReq.RequestUri,
				false,
				(HttpStatusCode)0,
				error: new Error(ex.Message, exception: ex));

			return response;
		}
		finally
		{
			if (httpReq is not null)
			{
				httpReq.Dispose();
			}

			if (httpResp is not null)
			{
				httpResp.Dispose();
			}
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

	protected internal (HttpRequestMessage, string?) CreateHttpRequest<TRequest>(
		TrybeRequest<TRequest> request)
		where TRequest : notnull
	{
		var message = CreateHttpRequest((TrybeRequest)request);
		string? capturedContent = null;

		if (_settings.CaptureRequestContent)
		{
			capturedContent = JsonSerializer.Serialize(request.Data, _serializerOptions);
			message.Content = new StringContent(capturedContent, Encoding.UTF8, "application/json");
		}
		else
		{
			message.Content = JsonContent.Create(
				inputValue: request.Data, options: _serializerOptions);
		}

		return (message, capturedContent);
	}
	#endregion

	#region Postprocessing
	protected internal async Task<(TrybeResponse, string?)> TransformResponse(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
	{
		var rateLimiting = GetRateLimiting(response);

		if (response.IsSuccessStatusCode)
		{
			return (new TrybeResponse(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				rateLimiting: rateLimiting), null);
		}
		else
		{
			Error error;
			string? stringContent = await response.Content.ReadAsStringAsync()
					.ConfigureAwait(false);
			if (stringContent is { Length: >0 })
			{
				var result = JsonSerializer.Deserialize<ErrorContainer>(stringContent, _deserializerOptions);

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

			return (new TrybeResponse(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				rateLimiting: rateLimiting,
				error: error
			), stringContent);
		}
	}

	protected internal async Task<(TrybeResponse<TResponse>, string?)> TransformResponse<TResponse>(
		HttpMethod method,
		Uri uri,
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
		where TResponse : class
	{
		var rateLimiting = GetRateLimiting(response);

		Stream? content = null;
		string? stringContent = null;
		if (response.Content is not null)
		{
			if (_settings.CaptureResponseContent || !response.IsSuccessStatusCode)
			{
				stringContent = await response.Content.ReadAsStringAsync()
					.ConfigureAwait(false);
			}
			else
			{
				content = await response.Content.ReadAsStreamAsync()
				.ConfigureAwait(false);
			}
		}

		if (response.IsSuccessStatusCode)
		{
			DataContainer<TResponse>? data = default;
			Meta? meta = default;
			if (content is not null || stringContent is { Length: >0 })
			{
				try
				{
					data = stringContent is { Length: > 0 }
						? JsonSerializer.Deserialize<DataContainer<TResponse>>(stringContent, _deserializerOptions)
						: await JsonSerializer.DeserializeAsync<DataContainer<TResponse>>(content!, _deserializerOptions).ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					return new(
						new TrybeResponse<TResponse>(
							method,
							uri,
							response.IsSuccessStatusCode,
							response.StatusCode,
							rateLimiting: rateLimiting,
							error: new Error(ex.Message, exception: ex)
						), stringContent);
				}

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

			return (new TrybeResponse<TResponse>(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				data: data?.Data,
				meta: meta,
				rateLimiting: rateLimiting
			), stringContent);
		}
		else
		{
			Error error;
			if (stringContent is not null)
			{
				var result = JsonSerializer.Deserialize<ErrorContainer>(stringContent, _deserializerOptions);

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

			return (new TrybeResponse<TResponse>(
				method,
				uri,
				response.IsSuccessStatusCode,
				response.StatusCode,
				rateLimiting: rateLimiting,
				error: error
			), stringContent);
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
