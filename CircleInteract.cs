using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject _ticketSystemObject;
    private UnifiedStorage _ticketsSystem;
    // Start is called before the first frame update
    void Start()
    {
        _ticketsSystem = _ticketSystemObject.GetComponent<UnifiedStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(_ticketsSystem.TicketGet());
        }
    }

}
