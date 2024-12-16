using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MovingObject;
    public int numObjects;
    public float speed = 5f;
    private GameObject[] objects;
    private float objectWidth;
    

    public int direction = 1;

    void Start()
    {
        objects = new GameObject[numObjects];
        objectWidth = MovingObject.GetComponent<Renderer>().bounds.size.x * 2;

        for (int i = 0; i < numObjects; i++)
        {
            objects[i] = Instantiate(MovingObject, new Vector3(i * objectWidth * 2 , transform.position.y, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numObjects; i++)
        {
            objects[i].transform.Translate(Vector3.left * direction  * speed * Time.deltaTime);

            if (objects[i].transform.position.x < -objectWidth * 2f)
            {
                Destroy(objects[i]);

                objects[i] = Instantiate(MovingObject, new Vector3((numObjects - 1) * objectWidth * 2 , transform.position.y, 0), Quaternion.identity);
            }

            else if(objects[i].transform.position.x > objectWidth * 10f)
            {
                Destroy(objects[i]);

                objects[i] = Instantiate(MovingObject, new Vector3((numObjects - 1) - objectWidth * 3, transform.position.y, 0), Quaternion.identity);
            }
        }

        
    }
}
