// параметры скила боевая медецина
using UnityEngine;
using System.Collections;


namespace statsCM {
public class CombatMedecine 
{
      const int _LEVELCM = 1;
			public int LevelCm = _LEVELCM;
      
      const float _REGENHP = 0.6; 
			const float _TIMEREGEN = 10; 
			public float regenHp = _REGENHP; 
		  public float timeRegen = _TIMEREGEN;
    public Stats()
		{
			this.newregenhp ();

		}
		public Stats() //конструктор класса с о всеми значениями
		{
			this.LevelCm = LevelCm; //начальный уровень
			this.regenHp = regenHp;
			this.timeRegen = timeRegen; 
			
			this.newregenhp (); //считаем кол-во жизни
		}

		public void lvlUPcm() //функция вызываемая при повышении уровня
		{
			this.LevelCm += 1; //уровень устанавливаем +1
		}
		public void newregenhp()
		{
			this.regenHp =this.regenHp  + 0.6; 
		}
    }
