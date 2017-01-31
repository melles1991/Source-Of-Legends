private var options_on : boolean = false;   // скрытая переменная "options_on"
private var graphics : boolean = false;     // скрытая переменная "graphics"
public var name_level : String;             // публичная строковая переменная

function OnGUI () {	
if(!options_on){   // если "options_on" не активна, тогда

GUI.Box(Rect(Screen.width/2-150,Screen.height/2-150,300,250), "Меню");              //отрисовываем GUI.Box "Меню"

		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-100,280,50), "Играть")) { //нажата кнопка "играть"?
           Application.LoadLevel(name_level);             // загружаем уровень
		}
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-50,280,50), "Опции")) {   //нажата кнопка "опции"?
		options_on = true;
		}
		
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-0,280,50), "Выход")) {    //нажата кнопка "выход"?

			Application.Quit();                     //выход из игры
		}
	   }  	   
	
if(options_on)    // если "options_on" активна, тогда

if(!graphics){     // если "graphics" не активна, тогда
GUI.Box(Rect(Screen.width/2-150,Screen.height/2-150,300,200), "Опции");             //отрисовываем GUI.Box "Опции"

        if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-100,280,50), "Графика")) {
                graphics = true;
        }
        if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-50,280,50), "Назад")) {
		        options_on = false;		// возвращаемся в "Меню"
		}
}


if(graphics){      // если "graphics" активна, тогда
GUI.Box(Rect(Screen.width/2-150,Screen.height/2-150,300,500), "Настройки графики");

		if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2-100,280,50), "Очень низкие")){
				QualitySettings.currentLevel = QualityLevel.Fastest;
			}
			if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2-50,280,50), "Низкие")){
				QualitySettings.currentLevel = QualityLevel.Fast;
			}
			if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2-0,280,50), "Средние")){
				QualitySettings.currentLevel = QualityLevel.Simple;
			}
			if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2+50,280,50), "Хорошие")){
				QualitySettings.currentLevel = QualityLevel.Good;
			}
			if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2+100,280,50), "Очень хорошие")){
				QualitySettings.currentLevel = QualityLevel.Beautiful;
			}
			if(GUI.Button(Rect(Screen.width /2-140,Screen.height /2+150,280,50), "Фантастические")){
				QualitySettings.currentLevel = QualityLevel.Fantastic;
			}	
			if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2+250,280,50), "Назад")) {
		        graphics = false;		// возвращаемся в "Опции"
		}			
	}
}      	   