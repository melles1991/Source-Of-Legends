/// <summary>
/// Player bar display.
/// Выводит на экран бары игрока
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBarDisplay : MonoBehaviour {
	public PlayerStats Char; // Объект на котором висят статы 
    public Slider slider;
    public Text textHp;
	public Text textName;
	public Text textLv;


    void Start()

	{
    }

    // Update is called once per frame
    void Update()
    {

        //получаем переменную PlayerSt компонент PlayerStats
        //В инспекторе в Unity нужно указать на игрока
        //получаем значения


		//получаем переменную PlayerSt компонент PlayerStats
		//В инспекторе в Unity нужно указать на игрока
		PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
		//получаем значения
		float MaxHealth = PlayerSt.stats.HealthMax;
		float CurHealth = PlayerSt.CurHealth;
		float needExp = PlayerSt.stats.EXP;
		float curLvl = PlayerSt.CurLvl;
		slider.maxValue = MaxHealth;
        slider.value = CurHealth;
		textHp.text = (int)CurHealth + "/"+ (int)MaxHealth;
		textName.text = "Player";
        textLv.text = "LV." + curLvl;


    }
}