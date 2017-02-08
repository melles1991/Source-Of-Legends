using UnityEngine;
using System.Collections;
using stats; //Используем пространство stats
using UnityStandardAssets.Utility;
using skillPassCM;
using skillPassFS;


public class PlayerStats : MonoBehaviour {
	public Stats stats = new Stats(1, 600, 4, 2, 3,0,0,0);
	public CombatMedecine skillPassCM = new CombatMedecine(1, 0, 10);//Объявляем новый объект Stats
	public FightingSpirit skillPassFS = new FightingSpirit(1, 0);//Объявляем новый объект Stats
	public static bool death; //Глобальная переменная отвечающа нам жив ли персонаж
	public int pointstat = 0; //кол-во поинтов дающихся при повышении
    	int showstatskill = 0;
	public int pointskill = 0;
	public float CurHealth; //кол-во жизней персонаж нынешние
	public float curEXP; //кол-во опыта
	public int CurLvl;
	public float MaxHP;
	public float Energy;
	public float STA;
	public float STR;
	public float AGL;
	public float MinDAM;
	public float MaxDAM;
	public float WSpeed;
	public float RSpeed;
	public float SSpeed;
	private float RegenTime;


	void Start()
	{
		death = false; //По умолчанию персонаж жив
		Time.timeScale = 1; //Игра работает
		CurHealth = stats.HealthMax; //В начале у персонажа кол-во жизней максимально
	}

	void Update () {
		MaxHP=stats.HealthMax;
		Energy=stats.EnergyMax;
		STA=stats.Stamina;
		STR=stats.Strengh;
		AGL=stats.Agility;
		MinDAM=stats.MinDamage;
		MaxDAM=stats.MaxDamage;
		WSpeed=stats.WalkSpeed;
		RSpeed=stats.RunSpeed;
		SSpeed=stats.SwimSpeed;



		if(CurHealth > stats.HealthMax) //если кол-во жизни будет выше максимального кол-ва жизней
			CurHealth=stats.HealthMax; //Уравниваем их
		if(CurHealth<=0) //Если кол-во жизни меньше или равно 0
		{
			CurHealth=0; //Ставим 0 дабы наш бар не рисовался не корректно
			death = true; //Ставим что персонаж мертв
			Time.timeScale = 0;
		}
		float Regen = skillPassCM.regenHp ;
		if(RegenTime <= Time.time)
			{
			RegenTime = Time.time + skillPassCM.timeRegen;
				if ((CurHealth < stats.HealthMax))
				{
					CurHealth += Regen;
				}
			}





		if(showstatskill == 0) //Если окно со статами не отображается
		{
			if(Input.GetKeyDown (KeyCode.L)) //Принажатии на клавишу P
				showstatskill = 1; //окно со статами будет отображаться
		}
		else if(showstatskill == 1) //если окно со статами отображается
		{
			if(Input.GetKeyDown (KeyCode.L)) //При нажатии на клавишу P
				showstatskill = 0; //Окно исчезнет
		}

//		if(movePlayer.IsDrawWeapon == true) //Проверяем вытащено ли у нас оружие, и если вытащено
//		{
//			stats.minATKweapon = weaponstat.minATKweapon; //Устанавливаем значение минимальной атаки оружия
//			stats.maxATKweapon = weaponstat.maxATKweapon; //Максимальной атаки оружия
//			stats.newdmg(); //Пересчитываем урон согласно оружию
//		}
//		else //если не одето
//		{
//			stats.minATKweapon = 0; //ставим значения в 0
//		stats.maxATKweapon = 0;
//			stats.newdmg(); //соответственно атака у нас 0
//		}

		if( curEXP >= stats.EXP) //Если количество опыта у нас рано и ли больше нужного кол-ва опыта
		{
			stats.lvlUP(); //повышаем уровень
			curEXP=0; //кол-во опыта ставим 0
			pointstat += 5; //Добавляем очки статов
			pointskill += 10;
			CurLvl = stats.Level;
		}
	}
	public void StrenghPlus(){
		if (pointstat > 0) {
			pointstat -= 1;
			stats.Strengh += 1;
			stats.newdmg ();
		}
	}

	public void StaminaPlus(){
		if (pointstat > 0) {
			pointstat -= 1;
			stats.Stamina += 1;
			stats.newhp ();
		}
	}	
	public void AgilityPlus(){
		if(pointstat > 0)
		{
			pointstat -= 1;
			stats.Agility += 1;
			stats.newenergy();
			stats.newspeed();
		}
	}
					
			
					
				
		



	void OnGUI()
	{


		if(showstatskill == 1) //если статы отображаются
		{
			//Рисуем наши статы
			GUI.Box (new Rect(310, 70, 300, 300), "SKILL");
			GUI.Label (new Rect(350, 95,300,300), " Боевая медицина " );
			GUI.Label (new Rect(310, 110,300,300), " Ур. "+ skillPassCM.LevelCm + " HpRegen:  " + skillPassCM.regenHp);
			GUI.Label (new Rect(350, 115,300,300), " " );
			GUI.Label (new Rect(350, 130,300,300), "  Боевой дух " );
			GUI.Label (new Rect(310, 145,300,300), " Ур. "+ skillPassFS.LevelFs + " AddMissChance:  " + skillPassFS.addMissChance);



			if(pointskill >0) //если очков статов больше 0 делаем кнопки для повышения статов
			{
				GUI.Label(new Rect(310,340,300,20),"points "+pointskill.ToString());
				if(GUI.Button (new Rect(480,100,20,20), "+")) //Для силы
				{
					if(pointskill > 0)
					{
						pointskill -= 1;
						skillPassCM.LevelCm += 1;
						skillPassCM.newregenhp();
					}
				}
				if(GUI.Button (new Rect(480,120,20,20), "+")) //Для силы
				{
					if(pointskill > 0)
					{
						pointskill -= 1;
						skillPassFS.LevelFs += 1;
						skillPassFS.newaddMissChance();
					}
				}
			}
		}
		else if(showstatskill == 0)
			useGUILayout=false; //Скрываем окно статов






		if(death==true) //Если умерли
		{
			if(GUI.Button (new Rect(Screen.width/2,Screen.height/2,100,50),"Переиграть")) //Ресуем кнопку переиграть
			{
				Application.LoadLevel (1);
			}
		}
	}
}


