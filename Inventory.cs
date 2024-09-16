namespace ProjectAlpha;
public class Inventory
{

	public int Storage;
	public object? Current;

	public List<Skill> Skills = new();
	public Dictionary<Quest, bool> Quests = new();
	public Dictionary<object, int> Items = new();

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
		// add skills separately
		if (item is Skill skill)
		{
			Skills.Add(skill);
			return true;
		}

		if (item is Quest quest)
		{
			Quests.Add(quest, false);
			return true;
		}

		// disallow bloat
		if (Items.Count + 1 > Storage) 
			return false;

		// increment or introduce
		if (Items.ContainsKey(item))
			Items[item]++;
		
		else
			Items.Add(item, 1);

		return true;
	}

    public object? Del(object item)
    {
		// don't delete non-existent items
		if (!Items.ContainsKey(item))
			return null;

		// decrement quantity or delete entirely
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
		// abort on invalid type 
		if (!new List<Type>() { typeof(Weapon), typeof(Item) }.Contains(type))
			return null;

		// construct a list of explicitly requested type
		List<object> list = new();
		foreach (var item in Items)
			if (item.Key.GetType() == type)
				list.Add(item);

		return list;
	}

	public void Represent()
	{
		foreach (var item in Items)
		{

			// L'items
			if (item.Key.GetType() == typeof(Item))
			{ 
				Item current = (Item) item.Key;
                Console.WriteLine($"{item.Value} {current.ToString()}");
            }

            // La weapons
            if (item.Key.GetType() == typeof(Weapon))
            {
                Weapon current = (Weapon)item.Key;
				Console.Write($"{item.Value} {item.Key.Description}");
            }
        }
	}
}