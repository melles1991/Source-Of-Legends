using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Library : MonoBehaviour 
{
	public static List<Weapon> WeaponsLibrary = new List<Weapon>();
	void Awake () 
	{
		//Sword of justice 0
		Weapon weapon = new Weapon(333,777,4,10,Weapon.DamageTypes.Holy,Weapon.WeaponTypes.TwoHSword);
		weapon.Name = "Sword of justice";
		weapon.Description = "EEEEEEEEEEEEEEEPIC SWORD";
		weapon.Cost = 1800000000;
		weapon.CurDur = 800;
		weapon.MaxDur = 1000;
		weapon.RarityTypes = Item.RTypes.Mythical;
		WeaponsLibrary.Add(weapon);
		//Mace 1
		weapon = new Weapon(5,10,2,15,Weapon.DamageTypes.Physical,Weapon.WeaponTypes.OneHMace);
		weapon.Name = "Mace";
		weapon.Description = "herovaia dubinka";
		weapon.Cost = 24;
		weapon.CurDur = 8;
		weapon.MaxDur = 10;
		weapon.RarityTypes = Item.RTypes.Common;
		WeaponsLibrary.Add(weapon);
	}
}