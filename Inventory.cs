/// <summary>
///		This class is the centralized entity-specific registry/collection
///		for in-game obtainable items.
/// </summary>
///
/// <attr id="Storage">Amount of items/skills the player can hold</attr>
/// <attr id="Current">Object handle to currently held item</attr>
/// <attr id="Items">Multi-type collection of all obtainable items the player has</attr>
/// 
/// <constructor>
///		<base>
///			<param name="Storage" ref=attr:Storage></param>
///		</base>
///		<overload>
///			<para>Allow creation without specified storage (default: 8)</para>
///		</overload>
/// </constructor>
/// 
/// <div sort="standard">
/// 
///		<method id="Select">
///			<param name="slot">Offset relative to the 0-index (inside? joke;)</param>
///			<summary>
///				This will simply modify the this.Current variable and 
///				assign the new object (beware, this object can be of any type)
///			</summary>
///		</method>
///		
///		<method id="Add">
///			<param name="item">An object of any type to the inventory, this can be filtered afterwards</param>
///			<summary>
///				This will append any provided object with any provided type to the inventory;
///				all items except skills will be verified on quantity before appending.
///			</summary>
///		</method>
///		
///		<method id="Del">
///			<param name="Item" ref=attr:Storage></param>
///			<summary>
///				This will delete any provided item from the player's inventory;
///				all items except skills can be deleted.
///			</summary>
///		</method>
///		
///		<method id="Filter">
///			<param name="type">A type i.e. typeof(<type>); e.g. typeof(Skill)</param>
///			<summary>
///				This will filter out a specific type from the player's inventory; 
///				with this, you can easily inspect weapons or items individually.
///			</summary>
///		</method>
///		
///	</div>
///		
/// <method id="ToString" sort="override">
///		<summary>
///			This overwritten method acts as the representation 
///			of the inventory on the player's terminal
///		</summary>
/// </method>
///

namespace ProjectAlpha;
public class Inventory
{

	public int Storage;
	public object Current;

	List<Skill> Skills = new();
	Dictionary<object, int> Items = new();

	public Inventory(int storage) => Storage = storage;
	public Inventory() : this(8) { }

	public bool Select(int slot)
	{

		if (slot > Storage) 
			return false;
		
		Current = Items.ElementAt(slot);
		return true;

	}

	public bool Add(object item)
	{

		if (item.GetType() == typeof(Skill))
		{
			Skills.Add(item as Skill);
			return true;
		}

		if (Items.Count + 1 > Storage) 
			return false;

		if (Items.ContainsKey(item))
			Items[item]++;
		
		else
			Items.Add(item, 1);

		return true;

	}

    public object? Del(object item)
    {

		if (!Items.ContainsKey(item))
			return null;

		object removal = Items[item];
		if (Items[item] > 1)
		{
			Items[item]--;
			return removal;
		}
		else
		{
			Items.Remove(item);
			return removal;
		}

    }

	public List<object>? Filter(Type type)
	{

		if (!new List<Type>() { typeof(Weapon) }.Contains(type))
			return null;

		List<object> list = new();
		foreach (var item in Items)
		{

			if (item.Key.GetType() == type)
				list.Add(item);

		}

		return list;

	}

    public override string ToString()
    {

		// work in progress.. stfu
		string str = $"";
		foreach (object item in Items)
		{
			str += item.ToString() + "\n";
		}

		return str;

    }
}