using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction = mouse - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
	}
}