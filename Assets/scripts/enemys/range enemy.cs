using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
	public GameObject player;
	public GameObject bulletPrefab;
	public float speed = 2f;
	public float attackRange = 6f;
	public float fireRate = 1f;

	bool inRange;
	float nextShot;
	Rigidbody2D rb;
	Bow bow;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		bow = GetComponentInChildren<Bow>();
		bow.target = player.transform;
		GetComponent<CircleCollider2D>().radius = attackRange;
	}

	void Update()
	{
		Vector2 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

		if (inRange && !bow.shooting && Time.time >= nextShot)
		{
			bow.Fire(bulletPrefab);
			nextShot = Time.time + fireRate;
		}
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