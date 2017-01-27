using UnityEngine;
using System.Collections;

public class moveCam : MonoBehaviour {
	public Transform target; //Объект за которым летаем(Наш персонаж)
	public float distance = 3.0f; //На каком ратоянии от него
	public float xSpeed = 125.0f; //Чуствительность по Х
	public float ySpeed = 50.0f; //Y Чуствительность
	public float targetHeight = 1.0f; //Высота относительно объекта
	//Минимальный и максимальный угол поворота Y инче камеру разверет, Дальше у нас будет простая функция для инвертации их в обратные числа
	public float yMinLimit = -40;
	public float yMaxLimit = 80;
	//Максимальное удаление и приближение камеры к персонажу, искорость.
	public float maxDistance = 10.0f;
	public float minDistance = 0.5f;
	public float zoomRote = 20.0f;

	private float x = 0.0f; //Угол поворота по Y?
	private float y = 0.0f; //Уго поворота по X?

	[AddComponentMenu("Scripts/Mouse Orbit")] //Добавляем в меню

	public void Start() {  
		//переворачивам углы
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

//		if (Rigidbody)
//			Rigidbody.freezeRotation = true; //Если камера столкнется с физ.объектомона остановиться
	}

	public void LateUpdate() {  
		if (target) {//Если цель установлена(Персонаж)
			//Меняем углы согласно положению мыши
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			//Меняем дистанция до персонажа.
			distance -= (Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime) * zoomRote * Mathf.Abs(distance);
			distance = Mathf.Clamp (distance, minDistance, maxDistance);

			y = ClampAngle(y,yMinLimit, yMaxLimit); //Вызыв самописной функции для ограничения углов поврот
			movePlayer.x = x;
			//Повернуть камеру согласно поченым данным
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			transform.rotation = rotation;

			//Двигаем камеру и следим за персонажем
			Vector3 position = rotation * new Vector3(0.0f, targetHeight+0.5f, -distance) + target.position;
			transform.position = position;

			//Следуйщи код нужен что бы камера не проваливалась по ланшафт  
			RaycastHit hit;
			Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -targetHeight,0);
			if(Physics.Linecast (trueTargetPosition, transform.position, out hit))
			{
				float tempDistance = Vector3.Distance (trueTargetPosition, hit.point) - 0.28f;
				position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -targetHeight, 0));
				transform.position = position;
			}
		}

	}
	//Меняем значения углов
	public static float ClampAngle (float angle, float min, float max) {
		if(angle < -360)
			angle += 360;
		if(angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
