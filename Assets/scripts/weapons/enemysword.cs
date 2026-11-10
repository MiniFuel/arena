using System.Collections;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
	public float startAngle = 60f;
	public float endAngle = -60f;
	public float downTime = 0.15f;
	public float upTime = 0.3f;
	public float cooldown = 1f;

	bool swinging;
	float nextAttack;

	public void Attack(Transform target)
	{
		if (swinging || Time.time < nextAttack)
			return;

		StartCoroutine(Swing());
	}

	IEnumerator Swing()
	{
		swinging = true;

		yield return Rotate(startAngle, endAngle, downTime);
		yield return Rotate(endAngle, startAngle, upTime);

		swinging = false;
		nextAttack = Time.time + cooldown;
	}

	IEnumerator Rotate(float from, float to, float duration)
	{
		float t = 0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			float angle = Mathf.Lerp(from, to, t / duration);
			transform.localRotation = Quaternion.Euler(0f, 0f, angle);
			yield return null;
		}
		transform.localRotation = Quaternion.Euler(0f, 0f, to);
	}
}