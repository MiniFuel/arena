using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
	public float speed = 0.1f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
		{
        rb.position += new Vector2(0, 1f) * speed;
		}
		if (Input.GetKey(KeyCode.A))
		{
			rb.position += new Vector2(-1f, 0)* speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.position += new Vector2(0, -1f) * speed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			rb.position += new Vector2(1f, 0) * speed;
		}
	}
}
