using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinko : MonoBehaviour
{
    // Start is called before the first frame update
    public int rows;
    public GameObject peg;
    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j >0 ; j--)
            {
                Instantiate(peg, new Vector3(j - (0.5f * i), i, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
