public class Item 
{
	private string _name;
	private string _desc;
	private int _cost;
	private int _curDur;
	private int _maxDur;
	private RTypes _rarityTypes;
	public Item()
	{
		_name = "NoName";
		_desc = "null";
		_cost = 0;
		_curDur = 0;
		_maxDur = 10;
		_rarityTypes = RTypes.Common;
	}
	public Item(string n, string d, int c, int curD, int maxD, RTypes r)
	{
		_name = n;
		_desc = d;
		_cost = c;
		_curDur = curD;
		_maxDur = maxD;
		_rarityTypes = r;
	}
	public string Name
	{
		get{return _name;}
		set{_name = value;}
	}
	public string Description
	{
		get{return _desc;}
		set{_desc = value;}
	}
	public int Cost
	{
		get{return _cost;}
		set{_cost = value;}
	}
	public int CurDur
	{
		get{return _curDur;}
		set{_curDur = value;}
	}
	public int MaxDur
	{
		get{return _maxDur;}
		set{_maxDur = value;}
	}
	public RTypes RarityTypes
	{
		get{return _rarityTypes;}
		set{_rarityTypes = value;}
	}
	public enum RTypes
	{
		Common,
		Uncommon,
		Rare,
		Mythical
	}

}