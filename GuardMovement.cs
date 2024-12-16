using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;
    public int speed = 2;
    private Rigidbody2D rb;
    private Transform currentPos;
    private Arcade Arcade;

    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererUp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPos = endPoint.transform;
        spriteRendererRight.enabled = true;
    }

    private void Update()
    {
        Vector2 point = currentPos.position - transform.position;
        if (currentPos == endPoint.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            spriteRendererLeft.enabled = false;
            spriteRendererRight.enabled = true;
            spriteRendererUp.enabled = false;
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            spriteRendererRight.enabled = false;
            spriteRendererLeft.enabled = true;
            spriteRendererUp.enabled = false;
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == endPoint.transform)
        {
            currentPos = startPoint.transform;
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == startPoint.transform)
        {
            currentPos = endPoint.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        try
        {
            if (collision.GetComponent<Arcade>().isBreaking)
            {
                Debug.Log("Guard has caught you");
            }

            else
            {
                return;
            }
        }

        catch
        {
            return;
        }
        
    }
    
}
