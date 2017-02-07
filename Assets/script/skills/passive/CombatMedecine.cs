// параметры скила боевая медецина
using UnityEngine;
using System.Collections;


namespace skillPassCM {
public class CombatMedecine 
{
      const int _LEVELCM = 1; // начальный уровень скила
      public int LevelCm = _LEVELCM;
      
      const float _REGENHP = 0.636f; // начальное количество востановления HP
      const float _TIMEREGEN = 10f; // время востановления HP
      public float regenHp = _REGENHP; 
      public float timeRegen = _TIMEREGEN;

      public CombatMedecine ()
		{
			this.newregenhp ();

		}
		public CombatMedecine (int LevelCm, int regenHp, int timeRegen) //конструктор класса с о всеми значениями
		{
			this.LevelCm = LevelCm; //начальный уровень
			this.regenHp = regenHp; // востановление HP
			this.timeRegen = timeRegen; //время
			
			this.newregenhp (); //считаем кол-во HP для востановления
		}

    public void lvlUPcm() //функция вызываемая при повышении уровня
		{
			this.LevelCm += 1; //уровень устанавливаем +
		}

		public void newregenhp()
		{
			this.regenHp = regenHp  + _REGENHP; // перещет по уровню
		}

    }
}
