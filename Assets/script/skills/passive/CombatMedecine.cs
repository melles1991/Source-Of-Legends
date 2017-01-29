// параметры скила боевая медецина
using UnityEngine;
using System.Collections;


namespace statsCM {
public class CombatMedecine 
{
      const int _LEVELCM = 1; // начальный уровень скила
      public int LevelCm = _LEVELCM;
      
      const float _REGENHP = 0.6; // начальное количество востановления HP
      const float _TIMEREGEN = 10; // время востановления HP
      public float regenHp = _REGENHP; 
      public float timeRegen = _TIMEREGEN;
    public Stats()
		{
			this.newregenhp ();

		}
    public Stats() //конструктор класса с о всеми значениями
		{
			this.LevelCm = LevelCm; //начальный уровень
			this.regenHp = regenHp; // востановление HP
			this.timeRegen = timeRegen; //время
			
			this.newregenhp (); //считаем кол-во HP для востановления
		}

    public void lvlUPcm() //функция вызываемая при повышении уровня
		{
			this.LevelCm += 1; //уровень устанавливаем +1
		}
    public void newregenhp()
		{
			this.regenHp =this.regenHp  + 0.6; // перещет по уровню
		}
    }
}
