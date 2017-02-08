/// <summary>
/// Player bar display.
/// Выводит на экран бары игрока
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using stats;


public class StatsDisplay : MonoBehaviour {
	public PlayerStats Char; // Объект на котором висят статы 
	public GameObject ListStat; // ui panel  инвентаря 
	public GameObject butPlus; // ui panel  инвентаря 
	public Text textLv;
	public Text textHp;
	public Text textSTA;
	public Text textSTR;
	public Text textAGL;
	public Text textDamage;
	public Text textSpeed;
	public Text textPoinStat;


    void Start()
	{
		ListStat.SetActive (false); 

	}

	void Update (){
		PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
		float curLvl = PlayerSt.CurLvl;
		float Hp = PlayerSt.MaxHP;
		float Energy = PlayerSt.Energy;
		float STAM = PlayerSt.STA;
		float STRE = PlayerSt.STR;
		float AGLI = PlayerSt.AGL;
		float MinDAM = PlayerSt.MinDAM;
		float MaxDAM = PlayerSt.MaxDAM;
		float WSpeed = PlayerSt.WSpeed;
		float RSpeed = PlayerSt.RSpeed;
		float SSpeed = PlayerSt.SSpeed;
		int PointStats = PlayerSt.pointstat;


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
	
		textLv.text ="Уровень: "+ curLvl ;
		textHp.text ="Жизнь: "+ (int)Hp+ " / "+"Енергия: "+ (int)Energy;


		textSTA.text ="Выносливость: "+ (int)STAM;
		textSTR.text ="Сила: "+ (int)STRE;
		textAGL.text ="Ловкость: "+ (int)AGLI;
		textPoinStat.text ="Поинтов : "+ PointStats;


		textDamage.text ="Урон: "+ MinDAM+" - "+MaxDAM;
		textSpeed.text ="Ходьбы: "+ WSpeed+"   Бега: "+RSpeed+"   Плаванья: "+SSpeed;
//	GUI.Label (new Rect(10, 110,300,300), "  "+(int)stats.HealthMax);
//	GUI.Label (new Rect(10, 125,300,300), "  "+(int)stats.EnergyMax);
//	GUI.Label (new Rect(10, 140,300,300), " Опыт: "+stats.EXP);
//	GUI.Label (new Rect(10, 165,300,300), " Выносливость: "+(int)stats.Stamina);
//	GUI.Label (new Rect(10, 180,300,300), " Сила: "+(int)stats.Strengh);
//	GUI.Label (new Rect(10, 195,300,300), "  "+(int)stats.Agility);
//	GUI.Label (new Rect(10, 230,300,300), " minDamage: "+stats.MinDamage);
//	GUI.Label (new Rect(10, 245,300,300), " maxDamage: "+stats.MaxDamage);
//	GUI.Label (new Rect(10, 265,300,300), " WalkSpeed: "+stats.WalkSpeed);
//	GUI.Label (new Rect(10, 280,300,300), " RunSpeed: "+stats.RunSpeed);
//	GUI.Label (new Rect(10, 295,300,300), " SwimSpeed: "+stats.SwimSpeed);



	}
}