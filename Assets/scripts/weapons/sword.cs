using System.Collections;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
	public float startAngle = 60f;
	public float endAngle = -60f;
	public float downTime = 0.12f;
	public float upTime = 0.25f;
	public int damage = 50;

	bool swinging;

	void Start()
	{
		SetAngle(startAngle);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !swinging)
			StartCoroutine(Swing());
	}

	IEnumerator Swing()
	{
		swinging = true;
		yield return Rotate(startAngle, endAngle, downTime);
		yield return Rotate(endAngle, startAngle, upTime);
		swinging = false;
	}

	IEnumerator Rotate(float from, float to, float duration)
	{
		float t = 0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			SetAngle(Mathf.Lerp(from, to, Mathf.SmoothStep(0f, 1f, t / duration)));
			yield return null;
		}
		SetAngle(to);
	}

	void SetAngle(float angle)
	{
		transform.localRotation = Quaternion.Euler(0f, 0f, angle);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.isTrigger)
			return;

		EnemyHealth enemy = other.GetComponent<EnemyHealth>();

		if (enemy != null)
			enemy.TakeDamage(damage);
	}
}