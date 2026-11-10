using System.Collections;
using UnityEngine;

public class abbilities : MonoBehaviour
{
public int healthcooldown = 5;
public int fireballcooldown = 4;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(Healing());
		}
	}
	IEnumerator Healing()
	{
		// Healing logic here

		yield return null;
	}
}
