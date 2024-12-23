// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json;
using System.Text.Json.Serialization;

using TrybeSDK.Primitives;

namespace TrybeSDK;

static class JsonUtility
{
	public static JsonSerializerOptions CreateSerializerOptions()
	{
		JsonSerializerOptions options = new()
		{
			WriteIndented = false,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};

		options.Converters.Add(new DateFormatJsonConverter());

		return options;
	}

	public static JsonSerializerOptions CreateDeserializerOptions()
	{
		JsonSerializerOptions options = new()
		{
			WriteIndented = false,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			NumberHandling = JsonNumberHandling.AllowReadingFromString
		};

		options.Converters.Add(new ObjectDictionaryJsonConverter());

		return options;
	}
}
