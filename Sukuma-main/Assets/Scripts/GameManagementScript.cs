using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScript : MonoBehaviour
{
    public MovementScript _MovementScript;
    // Start is called before the first frame update
    void Start()
    {
        _MovementScript = FindObjectOfType<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //stores this converted mouse position in a Vector2 variable named mousePosition
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        //hit will contain information about the collider that the raycast hits, such as the collider itself 
        if (other.gameObject.CompareTag("BeadTrigger") && hit.collider != null)
        {
            Rigidbody2D Bead = GetComponent<Rigidbody2D>();
            string Name = other.gameObject.name ;
            Debug.Log(Name);
            _MovementScript.MoveBeadRight(Bead);
            _MovementScript.MoveBeadDown(Bead);
        }
    }
}
