using UnityEngine;

public class enemywithsword : MonoBehaviour
{
	public GameObject player;
	public EnemySword sword;
	public float speed = 2f;

	bool inRange;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
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