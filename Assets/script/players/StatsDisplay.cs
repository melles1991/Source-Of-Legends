/// <summary>
/// Player bar display.
/// Р’С‹РІРѕРґРёС‚ РЅР° СЌРєСЂР°РЅ Р±Р°СЂС‹ РёРіСЂРѕРєР°
/// Р’РµС€Р°С‚СЊ РЅР° РёРіСЂРѕРєР°
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using stats;


public class StatsDisplay : MonoBehaviour {
	public PlayerStats Char; // РћР±СЉРµРєС‚ РЅР° РєРѕС‚РѕСЂРѕРј РІРёСЃСЏС‚ СЃС‚Р°С‚С‹ 
	public GameObject ListStat; // ui panel  РёРЅРІРµРЅС‚Р°СЂСЏ 
	public GameObject butPlus; // ui panel  РёРЅРІРµРЅС‚Р°СЂСЏ 
	public Text textLv;
	public Text textHp;
	public Text textSTA;
	public Text textSTR;
	public Text textAGL;
	public Text textDamage;
//	public Text textSpeed;


    void Start()
	{
		ListStat.SetActive (false); 

	}

	void Update (){
		PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
		int curLvl = PlayerSt.CurLvl;
		float Hp = PlayerSt.MaxHP;
		float Energy = PlayerSt.Energy;
		float STAM = PlayerSt.STA;
		float STRE = PlayerSt.STR;
		float AGLI = PlayerSt.AGL;
		float MinDAM = PlayerSt.MinDAM;
		float MaxDAM = PlayerSt.MaxDAM;
//		float WSpeed = PlayerSt.WSpeed;
//		float RSpeed = PlayerSt.RSpeed;
//		float SSpeed = PlayerSt.SSpeed;


		if (Input.GetKeyDown (KeyCode.P)) 
		{
			if (ListStat.activeSelf) 
			{
				ListStat.SetActive (false); 
			} 
			else 
			{
				ListStat.SetActive (true);  

			}
		}
	
		textLv.text = " " + (int)curLvl ;
		textHp.text = " " + (int)Hp;
		textSTA.text = " " + (int)STAM;
		textSTR.text = " " + (int)STRE;
		textAGL.text = " " + (int)AGLI;


		textDamage.text = MinDAM+" - " + MaxDAM;
//		textSpeed.text = WSpeed+"/" + RSpeed + "/" + SSpeed;
//	GUI.Label (new Rect(10, 110,300,300), "  "+(int)stats.HealthMax);
//	GUI.Label (new Rect(10, 125,300,300), "  "+(int)stats.EnergyMax);
//	GUI.Label (new Rect(10, 140,300,300), " РћРїС‹С‚: "+stats.EXP);
//	GUI.Label (new Rect(10, 165,300,300), " Р’С‹РЅРѕСЃР»РёРІРѕСЃС‚СЊ: "+(int)stats.Stamina);
//	GUI.Label (new Rect(10, 180,300,300), " РЎРёР»Р°: "+(int)stats.Strengh);
//	GUI.Label (new Rect(10, 195,300,300), "  "+(int)stats.Agility);
//	GUI.Label (new Rect(10, 230,300,300), " minDamage: "+stats.MinDamage);
//	GUI.Label (new Rect(10, 245,300,300), " maxDamage: "+stats.MaxDamage);
//	GUI.Label (new Rect(10, 265,300,300), " WalkSpeed: "+stats.WalkSpeed);
//	GUI.Label (new Rect(10, 280,300,300), " RunSpeed: "+stats.RunSpeed);
//	GUI.Label (new Rect(10, 295,300,300), " SwimSpeed: "+stats.SwimSpeed);



	}
}