// параметры скила боевой дух
using UnityEngine;
using System.Collections;


namespace statsFS {
public class FightingSpirit
{
      const int _LEVELFS = 1; // начальный уровень скила
      public int LevelFs = _LEVELFS;
      
		const float _ADDBLOCKCHANCE  = 0.2f; // прибавляет к блоку
		public float addBlockChance  = _ADDBLOCKCHANCE;

		public FightingSpirit ()
		{
			this.newaddBlockChance ();

		}
		public FightingSpirit(int LevelFs, int addBlockChance) //конструктор класса с о всеми значениями
		{
			this.LevelFs = LevelFs; //начальный уровень
			this.addBlockChance = addBlockChance; 
			
			this.newaddBlockChance (); 
		}

    public void lvlUPFs() //функция вызываемая при повышении уровня
	{
			this.LevelFs += 1; //уровень устанавливаем +
		}

		public void newaddBlockChance()
		{
			this.addBlockChance = addBlockChance  + _ADDBLOCKCHANCE; // перещет по уровню
		}

    }
}
