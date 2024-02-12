// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK;

partial interface ITrybeApiClient
{
	/// <summary>
	/// Gets the shop operations.
	/// </summary>
	IShopOperations Shop { get; }
}

partial class TrybeApiClient
{
	Lazy<IShopOperations>? _shop;
	public IShopOperations Shop => (_shop ??= Defer<IShopOperations>(
		c => new ShopOperations(new("/shop"), c))).Value;
}

public partial interface IShopOperations
{
}

/// <summary>
/// Provides operations for the /shop/ resource.
/// </summary>
/// <param name="path">The path for this resource.</param>
/// <param name="client">The API client.</param>
public partial class ShopOperations(
	PathString path,
	ApiClient client) : IShopOperations
{
}
