using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject player;
	public float speed = 2f;

	EnemySword sword;
	bool inRange;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sword = GetComponentInChildren<EnemySword>();
	}

	void Update()
	{
		Vector2 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, angle);

		if (inRange)
		sword.Attack(player.transform);

	}

	void FixedUpdate()
	{
		if (inRange)
		{
			rb.linearVelocity = Vector2.zero;
			return;
		}

		Vector2 direction = player.transform.position - transform.position;
		rb.linearVelocity = direction.normalized * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			inRange = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			inRange = false;
	}
}