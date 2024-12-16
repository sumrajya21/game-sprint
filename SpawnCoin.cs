using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.position -= new Vector3(0.1f, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            //tickets--
        }
    }
}
