using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _diskSystem;
    private MovementSwitchDisk _diskScript;

    void Start()
    {
        _diskScript = _diskSystem.GetComponent<MovementSwitchDisk>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Disk"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _diskScript._fallCount++;
        }
    }
}
