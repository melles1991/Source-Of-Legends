using UnityEngine;
using System.Collections;
using stats; //Используем пространство stats
using UnityStandardAssets.Utility;
using skillPassCM;
using skillPassFS;


public class PlayerStats : MonoBehaviour {
	public Stats stats = new Stats(1, 600, 4, 2, 3,0,0,0);
	public CombatMedecine statsCoM = new CombatMedecine(1, 0, 10);//Объявляем новый объект Stats
	public FightingSpirit statsFS = new FightingSpirit(1, 0);//Объявляем новый объект Stats
	public static bool death; //Глобальная переменная отвечающа нам жив ли персонаж
	int pointstat = 0; //кол-во поинтов дающихся при повышении
	int showstat = 0; //Отображать ли окно со статами
	int showstatskill = 0;
	int pointskill = 0;
	public float CurHealth; //кол-во жизней персонаж нынешние
	public float curEXP; //кол-во опыта
	public int CurLvl;
	private float RegenTime;


	void Start()
	{
		death = false; //По умолчанию персонаж жив
		Time.timeScale = 1; //Игра работает
		CurHealth = stats.HealthMax; //В начале у персонажа кол-во жизней максимально
	}

	void Update () {
		if(CurHealth > stats.HealthMax) //если кол-во жизни будет выше максимального кол-ва жизней
			CurHealth=stats.HealthMax; //Уравниваем их
		if(CurHealth<=0) //Если кол-во жизни меньше или равно 0
		{
			CurHealth=0; //Ставим 0 дабы наш бар не рисовался не корректно
			death = true; //Ставим что персонаж мертв
			Time.timeScale = 0;
		}
		float Regen = statsCoM.regenHp ;
		if(RegenTime <= Time.time)
			{
			RegenTime = Time.time + statsCoM.timeRegen;
				if ((CurHealth < stats.HealthMax))
				{
					CurHealth += Regen;
				}
			}


		if(showstat == 0) //Если окно со статами не отображается
		{
			if(Input.GetKeyDown (KeyCode.P)) //Принажатии на клавишу P
				showstat = 1; //окно со статами будет отображаться
		}
		else if(showstat == 1) //если окно со статами отображается
		{
			if(Input.GetKeyDown (KeyCode.P)) //При нажатии на клавишу P
				showstat = 0; //Окно исчезнет
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
	void OnGUI()
	{
		if(showstat == 1) //если статы отображаются
		{
			//Рисуем наши статы
			GUI.Box (new Rect(10, 70, 300, 300), "STATS");
			GUI.Label (new Rect(10, 95,300,300), " Level: "+stats.Level);
			GUI.Label (new Rect(10, 110,300,300), " HealthMax: "+(int)stats.HealthMax);
			GUI.Label (new Rect(10, 125,300,300), " EnergyMax: "+(int)stats.EnergyMax);
			GUI.Label (new Rect(10, 140,300,300), " EXP: "+stats.EXP);
			GUI.Label (new Rect(10, 165,300,300), " Stamina: "+(int)stats.Stamina);
			GUI.Label (new Rect(10, 180,300,300), " Strengh: "+(int)stats.Strengh);
			GUI.Label (new Rect(10, 195,300,300), " Agility: "+(int)stats.Agility);
			GUI.Label (new Rect(10, 230,300,300), " minDamage: "+stats.MinDamage);
			GUI.Label (new Rect(10, 245,300,300), " maxDamage: "+stats.MaxDamage);
			GUI.Label (new Rect(10, 265,300,300), " WalkSpeed: "+stats.WalkSpeed);
			GUI.Label (new Rect(10, 280,300,300), " RunSpeed: "+stats.RunSpeed);
			GUI.Label (new Rect(10, 295,300,300), " SwimSpeed: "+stats.SwimSpeed);
//			GUI.Label (new Rect(10, 310,300,300), "FlySpeed: "+stats.FlySpeed);

			if(pointstat >0) //если очков статов больше 0 делаем кнопки для повышения статов
			{
				GUI.Label(new Rect(10,340,300,20),"points "+pointstat.ToString());
				if(GUI.Button (new Rect(150,180,20,20), "+")) //Для силы
				{
					if(pointstat > 0)
					{
						pointstat -= 1;
						stats.Strengh += 1;
						stats.newdmg();
					}
				}
				if(GUI.Button (new Rect(150,165,20,20), "+")) //Для живучести
				{
					if(pointstat > 0)
					{
						pointstat -= 1;
						stats.Stamina += 1;

						stats.newhp();
					}
				}
				if(GUI.Button (new Rect(150,195,20,20), "+")) //Для живучести
				{
					if(pointstat > 0)
					{
						pointstat -= 1;
						stats.Agility += 1;
						stats.newenergy();
						stats.newspeed();
					}
				}
			}
		}
		else if(showstat == 0)
			useGUILayout=false; //Скрываем окно статов




		if(showstatskill == 1) //если статы отображаются
		{
			//Рисуем наши статы
			GUI.Box (new Rect(310, 70, 300, 300), "SKILL");
			GUI.Label (new Rect(350, 95,300,300), " CombatMedecine " );
			GUI.Label (new Rect(310, 110,300,300), " Lv. "+ statsCoM.LevelCm + " HpRegen:  " + statsCoM.regenHp);
			GUI.Label (new Rect(350, 115,300,300), " " );
			GUI.Label (new Rect(350, 130,300,300), "  FightingSpirit " );
			GUI.Label (new Rect(310, 145,300,300), " Lv. "+ statsFS.LevelFs + " AddBlockChance:  " + statsFS.addBlockChance);



			if(pointskill >0) //если очков статов больше 0 делаем кнопки для повышения статов
			{
				GUI.Label(new Rect(310,340,300,20),"points "+pointskill.ToString());
				if(GUI.Button (new Rect(480,100,20,20), "+")) //Для силы
				{
					if(pointskill > 0)
					{
						pointskill -= 1;
						statsCoM.LevelCm += 1;
						statsCoM.newregenhp();
					}
				}
				if(GUI.Button (new Rect(480,120,20,20), "+")) //Для силы
				{
					if(pointskill > 0)
					{
						pointskill -= 1;
						statsFS.LevelFs += 1;
						statsFS.newaddBlockChance();
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


