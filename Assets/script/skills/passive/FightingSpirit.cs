// параметры скила боевой дух
using UnityEngine;
using System.Collections;


namespace skillPassFS {
public class FightingSpirit
{
      const int _LEVELFS = 1; // начальный уровень скила
      public int LevelFs = _LEVELFS;
      
		const float _MISS_CHANCE  = 0.2f; // прибавляет к блоку
		public float addMissChance  = _MISS_CHANCE;

		public FightingSpirit ()
		{
			this.newaddMissChance ();

		}
		public FightingSpirit(int LevelFs, int addMissChance) //конструктор класса с о всеми значениями
		{
			this.LevelFs = LevelFs; //начальный уровень
			this.addMissChance = addMissChance; 
			
			this.newaddMissChance (); 
		}

    public void lvlUPFs() //функция вызываемая при повышении уровня
	{
			this.LevelFs += 1; //уровень устанавливаем +
		}

		public void newaddMissChance()
		{
			this.addMissChance = MissChance  + _MISS_CHANCE; // перещет по уровню
		}

    }
}
