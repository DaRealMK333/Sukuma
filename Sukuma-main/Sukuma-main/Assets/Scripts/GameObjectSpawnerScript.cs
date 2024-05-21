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
    public List<Vector3> colliderPos = new List<Vector3>();
    public List<Vector3> colliderGreen = new List<Vector3>();
    public List<Vector3> colliderGrey = new List<Vector3>();
    public List<Vector3> colliderRed = new List<Vector3>();
    public Vector3 colliderWhite;

    public Animator movingBlueBead;



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
                Vector3 position = new Vector3(-4f + i, 4f - j, 0);
                Instantiate(boardColliders, position, Quaternion.identity);
                //This creates colliders for each spot on the board
                getColliderPos(position); //Tracking List for everyposition
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
    public void getColliderPos(Vector3 pos)
    {

        //GreenSpaces
        if (pos == new Vector3(0, 4, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(0, 2, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(0, -2, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(0, -4, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(-1, 0, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(-3, 0, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(1, 0, 0))
            colliderGreen.Add(pos);
        else if (pos == new Vector3(3, 0, 0))
            colliderGreen.Add(pos);

        //GreySpaces
        else if (pos == new Vector3(0, 3, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(0, 1, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(0, -3, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(0, -1, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(-4, 0, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(-2, 0, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(4, 0, 0))
            colliderGrey.Add(pos);
        else if (pos == new Vector3(2, 0, 0))
            colliderGrey.Add(pos);

        //Square1
        else if (pos == new Vector3(-2, 2, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-1, 1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-2, 1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-1, 2, 0))
            colliderRed.Add(pos);

        //Square2
        else if (pos == new Vector3(2, 2, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(1, 1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(2, 1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(1, 2, 0))
            colliderRed.Add(pos);

        //Square3
        else if (pos == new Vector3(2, -2, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(1, -1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(2, -1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(1, -2, 0))
            colliderRed.Add(pos);

        //Square4
        else if (pos == new Vector3(-2, -2, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-1, -1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-2, -1, 0))
            colliderRed.Add(pos);
        else if (pos == new Vector3(-1, -2, 0))
            colliderRed.Add(pos);

        //WhiteSpot
        else if (pos == new Vector3(0, 0, 0))
            colliderWhite = pos;
        else
            colliderPos.Add(pos);
    }
    public void MoveBlue()
    {
        movingBlueBead.SetInteger("AnimState", 0);
    }
    public void MoveBlueUp()
    {
        movingBlueBead.SetInteger("AnimState", 1);
    }
    public void MoveBlueDown()
    {
        movingBlueBead.SetInteger("AnimState", 4);
    }
    public void MoveBlueLeft()
    {
        movingBlueBead.SetInteger("AnimState", 3);
    }
    public void MoveBlueRight()
    {
        movingBlueBead.SetInteger("AnimState", 2);
    }
    public void MoveBlueBead()
    {

    }

}
