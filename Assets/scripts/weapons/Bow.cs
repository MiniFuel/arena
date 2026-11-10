using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
	public Transform arrow;
	public Transform target;
	public float distanceFromEnemy = 0.8f;
	public float drawDistance = 0.4f;
	public float drawTime = 0.5f;
	public bool shooting;

	Vector3 arrowStart;
	Transform enemy;

	void Start()
	{
		arrowStart = arrow.localPosition;
		enemy = transform.parent;
	}

	void LateUpdate()
	{
		Vector2 direction = target.position - enemy.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.position = enemy.position + (Vector3)(direction.normalized * distanceFromEnemy);
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
	}

	public void Fire(GameObject bulletPrefab)
	{
		if (!shooting)
			StartCoroutine(Shoot(bulletPrefab));
	}

	IEnumerator Shoot(GameObject bulletPrefab)
	{
		shooting = true;

		float t = 0f;
		while (t < drawTime)
		{
			t += Time.deltaTime;
			arrow.localPosition = arrowStart + Vector3.left * drawDistance * (t / drawTime);
			yield return null;
		}

		Vector2 direction = target.position - arrow.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		GameObject bullet = Instantiate(bulletPrefab, arrow.position, Quaternion.Euler(0f, 0f, angle));
		Bullet bulletScript = bullet.GetComponent<Bullet>();

		if (bulletScript == null)
			Debug.LogError("The bullet prefab has no Bullet script on it");
		else
			bulletScript.direction = direction.normalized;

		arrow.localPosition = arrowStart;
		shooting = false;
	}
}