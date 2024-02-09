// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json;

namespace TrybeSDK;

static class JsonUtility
{
	public static JsonSerializerOptions CreateSerializerOptions()
	{
		JsonSerializerOptions options = new()
		{
			WriteIndented = false
		};

		return options;
	}
}
