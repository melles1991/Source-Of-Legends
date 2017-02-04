public class Weapon : Item 
{
	private int _minDamage;
	private int _maxDamage;
	private float _range;
	private float _speed;
	private DamageTypes _dt;
	private WeaponTypes _wt;
	public Weapon()
	{
		_minDamage = 5;
		_maxDamage = 10;
		_range = 2;
		_speed = 10;
		_dt = DamageTypes.Physical;
		_wt = WeaponTypes.Dagger;
	}
	public Weapon(int minD, int maxD, float r, float s, DamageTypes dt, WeaponTypes wt)
	{
		_minDamage = minD;
		_maxDamage = maxD;
		_range = r;
		_speed = s;
		_dt = dt;
		_wt = wt;

	}
	public int MinDamage
	{
		get{return _minDamage;}
		set{_minDamage = value;}
	}
	public int MaxDamage
	{
		get{return _maxDamage;}
		set{_maxDamage = value;}
	}
	public float Range
	{
		get{return _range;}
		set{_range = value;}
	}
	public float Speed
	{
		get{return _speed;}
		set{_speed = value;}
	}
	public DamageTypes DTypes
	{
		get{return _dt;}
		set{_dt = value;}
	}
	public WeaponTypes WTypes
	{
		get{return _wt;}
		set{_wt = value;}
	}
	public enum DamageTypes
	{
		Physical,
		Fire,
		Cold,
		Lighting,
		Poison,
		Holy
	}
	public enum WeaponTypes
	{
		OneHAxe,
		TwoHAxe,
		Bow,
		Crossbow,
		Dagger,
		Fist,
		OneHMace,
		TwoHMace,
		Polearm,
		Staff,
		OneHSword,
		TwoHSword,
	}

}