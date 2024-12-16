using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlinko : MonoBehaviour
{
    public float scoreMultiplier;
    private float prize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            prize = 10 * scoreMultiplier;
            Destroy(collision.gameObject);
            Debug.Log("You win");
            Debug.Log(prize);
        }
        

    }
}
