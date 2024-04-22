using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawnerScript : MonoBehaviour
{
    public GameObject boardColliders;
    public GameObject BlueBead;
    public GameObject PurpleBead;
    public GameObject[] ArrBlueBead = new GameObject[26];
    public GameObject[] ArrPurpleBead = new GameObject[26];
    public GameObject CircleHighlight;
    private bool IsPlayerBlueTurn = true;
    public GameObjectDestroyer Destroyer;
    
    
    private int beadCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ArrBlueBead.Length ; i++)
        {
            ArrBlueBead[i] = BlueBead;
           
            //Debug.Log(ArrBlueBead[i].name);
            ArrPurpleBead[i] = PurpleBead;
            
        }

        for (int i = 0; i < ArrBlueBead.Length; i++)
        {
            ArrBlueBead[i].name = "BlueBead " + (i+1).ToString();
            ArrPurpleBead[i].name = "PurpleBead " + (i + 1).ToString();
        }
        Destroyer = FindObjectOfType<GameObjectDestroyer>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            { 
                Instantiate(boardColliders, new Vector3(-4f + i, 4 - j, 0), Quaternion.identity);
                //This creates colliders for each spot on the board
            }
                
        } 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //stores this converted mouse position in a Vector2 variable named mousePosition
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        //hit will contain information about the collider that the raycast hits, such as the collider itself 
        
        if (hit.collider != null)  // Check if the ray hits a collider
        {
            if (!(Input.GetMouseButtonDown(0))) // Change this condition if you want to instantiate on hover instead of click
            {
                Vector3 position = new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -1);//stores the position where the beads will be placed
                if (IsPlayerBlueTurn && beadCounter == 0)
                {
                    Instantiate(ArrBlueBead[25], position, Quaternion.identity);//creates blue beads if blues turn
                   ArrBlueBead[0].name = "BlueBead " + (1).ToString();
                   // ArrBlueBead[0].name = "BlueBead " + (1).ToString();
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    beadCounter = 1;
                }
                else if (IsPlayerBlueTurn == false && beadCounter == 0)
                {
                    Instantiate(ArrPurpleBead[0], position, Quaternion.identity); //creates purple beads if blues turn
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    beadCounter = 1;

                }
            }
            
        }
        
        if (hit.collider != null)  // Check if the ray hits a collider
        {
            if ((Input.GetMouseButtonDown(0))) // Change this condition if you want to instantiate on hover instead of click
            {
                Vector3 position = new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -1);//stores the position where the beads will be placed
                if (IsPlayerBlueTurn && beadCounter == 0)
                {
                    Instantiate(BlueBead, position, Quaternion.identity);//creates blue beads if blues turn
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    beadCounter = 1;
                }
                else if (IsPlayerBlueTurn == false && beadCounter == 0)
                {
                    Instantiate(PurpleBead, position, Quaternion.identity); //creates purple beads if blues turn
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    beadCounter = 1;

                }
            }
            
        }

        if (hit.collider == null)
        {
            if (beadCounter == 1)
            {
                GameObjectDestroyer.BlueBeadDestroyer(1);
                GameObjectDestroyer.CircleHighlightDestroyer();
                beadCounter = 0;
            }
        }
    }
   
}
