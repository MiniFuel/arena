using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 8f;
	public float lifetime = 3f;
	public int damage = 10;
	public Vector2 direction;

	void Start()
	{
		Destroy(gameObject, lifetime);
	}

	void Update()
	{
		transform.position += (Vector3)(direction * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.isTrigger)
			return;

		if (other.CompareTag("Enemy"))
			return;

		if (other.CompareTag("Player"))
			Debug.Log("Player hit for " + damage);

		Destroy(gameObject);
	}
}