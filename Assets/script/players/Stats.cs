using UnityEngine;
using System.Collections;

namespace stats { //Пространство имен stats
	public class Stats //Объявляем новый класс Stats
	{ 

            public float EXP = 1000; //Необходимое кол-во опыта на следующий уровень(По достижению считается заново)
		  	const float _HEALTHMAX = 370;
//			const float _RAGEMAX = 100f; //Ярость
			const float _ENERGYMAX = 100; 
     		public float HealthMax = _HEALTHMAX;
//			public float RageMax { get { return _RAGEMAX; }}
			public float EnergyMax = _ENERGYMAX;

			const float _STAMINA = 2; // Виносливость
			const float _AGILITY = 3; //Ловкость
			const float _STRENGH = 4; //Сила
//			const byte _SPIRIT = 2;  //Сила духа

			public float Stamina = _STAMINA; 
		    public float Agility = _AGILITY;
		    public float Strengh = _STRENGH;
//			public byte Spirit { get { return _SPIRIT; }}



			const float _ARMOR = 0f;
			const float _RANGE_ARMOR_PERCENT = 0f;

			public float Armor = _ARMOR;
			public float RangeArmorPercent = _RANGE_ARMOR_PERCENT;


			const int _LEVEL = 1;
			public int Level = _LEVEL;



			const float _WALK_SPEED = 4.2f;
//			const float _FASTWALK_SPEED = 2.5f;
			const float _RUN_SPEED = 5.8f;
			const float _SWIM_SPEED = 3.2f;
//			const float _FLY_SPEED = 7.5f;

			public float WalkSpeed = _WALK_SPEED; 
//			public float FastWalkSpeed = _FASTWALK_SPEED; 
			public float RunSpeed = _RUN_SPEED; 
			public float SwimSpeed = _SWIM_SPEED; 
//			public float FlySpeed = _FLY_SPEED; 

	

			const float _ATTACK_SPEED = 1.7f; // скорость боя
			const float _ATTACK_CRITICAL_CHANCE = 4.5f;
			const float _MIN_DAMAGE = 1f; //нижний урон
			const float _MAX_DAMAGE = 4f; //верхний урон
			const float _ATTACK_DISTANCE = 2.5f; 
			const float _VISIBLE_DISTANCE = 10f;

			public float AttackSpeed = _ATTACK_SPEED;
			public float AttackCriticalChance = _ATTACK_CRITICAL_CHANCE; 
			public float MinDamage = _MIN_DAMAGE; 
			public float MaxDamage = _MAX_DAMAGE; 
			public float AttackDistance = _ATTACK_DISTANCE; 
			public float VisibleDistance = _VISIBLE_DISTANCE; 



			const float _MAX_DISTANCE = 5f;
			const float _MAX_FOLLOWING_DISTANCE = 20f;
			const float _STAY_ON_NEW_POSITION = 15f;

			public float MaxWalkingDistance { get { return _MAX_DISTANCE; }}
			public float MaxFollowingDistance { get { return _MAX_FOLLOWING_DISTANCE; }}
			public float StayOnPosition { get { return _STAY_ON_NEW_POSITION; }}



			const float _MISS_CHANCE = 4f; //уклонение
			const float _BLOCK_CHANCE = 2.5f; //блок
			const float _PARRY_CHANCE = 1.75f; //парирование

			public float MissChance { get { return _MISS_CHANCE; }}
			public float BlockChance { get { return _BLOCK_CHANCE; }}
			public float ParryChance { get { return _PARRY_CHANCE; }}
		public Stats()
		{
			this.newdmg (); //Считаем урон
			this.newhp (); //считаем кол-во жизни
			this.newenergy (); //считаем кол-во маны
			this.newspeed ();
		}
		public Stats(int Level, int EXP, int Agility, int Strengh, int Stamina, int WalkSpeed, int RunSpeed, int SwimSpeed) //конструктор класса с о всеми значениями
		{
			this.Level = Level; //начальный уровень
			this.EXP = EXP; //необходимое кол-во опыта для следующего уровня
			this.Agility = Agility;
			this.Strengh = Strengh; //начальное кол-во силы
			this.Stamina = Stamina; //начальное кол-во живучисти
			this.WalkSpeed = WalkSpeed;
			this.RunSpeed = RunSpeed;
			this.SwimSpeed = SwimSpeed;
			this.newenergy (); //Считаем енергию
			this.newdmg (); //Считаем урон
			this.newhp (); //считаем кол-во жизни
			this.newspeed();
		}

		public void lvlUP() //функция вызываемая при повышении уровня
		{
			this.Level += 1; //уровень устанавливаем +1
			this.EXP += Mathf.Floor(this.EXP /1.2f); //Высчитываем необходимое кол-во опыта для следующего уровня
		}
		public void newdmg() //функция пересчета урона
		{
			this.MinDamage =((this.Agility/10)  + (this.Strengh + 100)) / 10 - (this.MaxDamage *10/100); //минимальный урон
			this.MaxDamage = ((this.Agility/10) + (this.Strengh + 100)) / 10; //максимальный урон
		}
		public void newhp() //Пересчет кол-ва жизней
		{
			this.HealthMax = _HEALTHMAX + (this.Stamina * 3.6f);  
		}
		public void newenergy() //Пересчет кол-ва енергии
		{
			this.EnergyMax = _ENERGYMAX + (this.Agility * 1.1f);
		}
		public void newspeed() //Пересчет скорости 
		{
			this.WalkSpeed = _WALK_SPEED + ( this.Agility / 100);
			this.RunSpeed = _RUN_SPEED + (this.Agility / 100);
			this.SwimSpeed = _SWIM_SPEED + ( this.Agility / 100) ; 
//			this.FlySpeed = _FLY_SPEED + (this.Agility / 100);
		}
	}
}
