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

    public string[] ArrBlueBeadName = new string[26];
    public string[] ArrPurpleBeadName = new string[26];

    private bool[,] IsBeadPlaced = new bool[9, 9];
    private bool IsPlayerBlueTurn = true;
    private bool Ishovering = false;
    
    public GameObjectDestroyer Destroyer;
    public TrackerScript _TrackerScript;
    // Start is called before the first frame update
    void Start()
    {
        _TrackerScript = FindObjectOfType<TrackerScript>();
        
        for (int i = 0; i < ArrBlueBead.Length ; i++)
        {
            ArrBlueBead[i] = BlueBead;
            ArrPurpleBead[i] = PurpleBead;
            
        }
        
        for (int i = 0; i < ArrBlueBead.Length ; i++)
        {
            ArrBlueBeadName[i] = "BlueBead " + (i+1).ToString() ;
            ArrPurpleBeadName[i] = "PurpleBead " + (i+1).ToString();

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
        BeadPlacer();
    }

    public void BeadPlacer()
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
                if (IsPlayerBlueTurn && Ishovering == false)
                {
                    BeadNamer(IsPlayerBlueTurn);
                    Instantiate(ArrBlueBead[_TrackerScript.BlueScore-1], position, Quaternion.identity);//creates blue beads if blues turn
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    Ishovering = true;
                }
                else if (IsPlayerBlueTurn == false && Ishovering == false )
                {
                    BeadNamer(IsPlayerBlueTurn);
                    Instantiate(ArrPurpleBead[_TrackerScript.PurpleScore-1], position, Quaternion.identity); //creates purple beads if blues turn
                    Instantiate(CircleHighlight, new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -2), Quaternion.identity);
                    Ishovering = true;
                }
            }
            
        }
        
        if (hit.collider != null)  // Check if the ray hits a collider
        {
            if ((Input.GetMouseButtonDown(0))) // Change this condition if you want to instantiate on hover instead of click
            {
                Vector3 position = new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.center.y, -1);//stores the position where the beads will be placed
                if (IsPlayerBlueTurn && Ishovering)
                {
                    BeadNamer(IsPlayerBlueTurn);
                   // Instantiate(ArrBlueBead[_TrackerScript.BlueScore-1], position, Quaternion.identity);//creates blue beads if blues turn
                    _TrackerScript.Decrement(TrackerScript.Score.BlueScore);
                    GameObjectDestroyer.CircleHighlightDestroyer();
                    Ishovering = true;
                    IsPlayerBlueTurn = false;
                }
                else if (IsPlayerBlueTurn == false && Ishovering)
                {
                    BeadNamer(IsPlayerBlueTurn);
                   // Instantiate(ArrPurpleBead[_TrackerScript.PurpleScore-1], position, Quaternion.identity); //creates purple beads if blues turn
                    _TrackerScript.Decrement(TrackerScript.Score.PurpleScore);
                    GameObjectDestroyer.CircleHighlightDestroyer();
                    Ishovering = true;
                    IsPlayerBlueTurn = true;
                }
            }
            
        }

        if (hit.collider == null)
        {
            if (Ishovering)
            {
                GameObjectDestroyer.BlueBeadDestroyer(_TrackerScript.BlueScore);
                GameObjectDestroyer.PurpleBeadDestroyer(_TrackerScript.PurpleScore);
                GameObjectDestroyer.CircleHighlightDestroyer();
                Ishovering = false;
            }
        }
    }
    public void BeadNamer(bool IsplayerBlue)
    {
        if (IsplayerBlue)
        {
            ArrBlueBead[_TrackerScript.BlueScore - 1].gameObject.name = ArrBlueBeadName[_TrackerScript.BlueScore - 1];
        }
        else
        {
            ArrPurpleBead[_TrackerScript.PurpleScore - 1].gameObject.name = ArrPurpleBeadName[_TrackerScript.PurpleScore - 1];
        }
    }
    
    
}
