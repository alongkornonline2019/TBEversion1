using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public static move moveMove;
    public int currLine;
    public bool canKeep = false;
    public Vector3 endPos = new Vector3(10,0,0);
    public gameManagerT gameManaT;
    public int id =2;
    public float speed = 0.07f;
    public int types;
    // Start is called before the first frame update



    public bool clickGU = false;
    private Vector2 mousePosition;
    public float rescale;
    private void Awake()
    {
        clickGU = false;
        
        moveMove = this;

    }


    void Start()
    {
        speed = 0.07f;
        id = gameManagerT.gameManagerTT.idInfo[gameManagerT.gameManagerTT.numpic2];
        gameObject.GetComponent<SpriteRenderer>().sprite = gameManagerT.gameManagerTT.pic[gameManagerT.gameManagerTT.numpic2];
        rescale = gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit / 4.5f;
        gameObject.transform.localScale = new Vector2(0.07f, 0.07f) * rescale;
        types = gameManagerT.gameManagerTT.typesInfo[gameManagerT.gameManagerTT.numpic2];

        if (currLine == 0)
        {
            endPos.x = -6.5f;
        }
        else if (currLine == 1)
        {
            endPos.x = -2f;
        }
        else if (currLine == 2)
        {
            endPos.x = 2.5f;
        }

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
        //GetComponent<BoxCollider2D>().size = new Vector2(transform.localScale.x*10.0f, transform.localScale.y*10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameManagerT.gameManagerTT.mainSpeed;
        // transform.position = Vector3.MoveTowards(transform.position, endPos, 0.05f);


        //transform.position = Vector3.MoveTowards(transform.position, endPos, 0.05f);


        if (Input.GetMouseButtonDown(0))
        {
            if (canKeep == true)
            {
                clickGU = true;
            }
        }

        if (canKeep == true && clickGU == true)
        {

            this.transform.position = new Vector3(controler.con.transform.position.x-2.0f, controler.con.transform.position.y +0.9f, 0);
            controler.con.holdItem = true;
        }
        else
        {
        
            if(transform.position.x != endPos.x)
            {
                Vector3 newPosX = new Vector3(endPos.x, 0, 0);
                transform.position = Vector3.MoveTowards(transform.position, newPosX, 0.5f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            canKeep = false;
            clickGU = false;
            controler.con.holdItem = false;

        }

        if(transform.position.y == endPos.y)
        {
            gameManagerT.gameManagerTT.numPic += 1;
            Destroy(this.gameObject);
            gameManagerT.gameManagerTT.line[currLine] = false;
        }
    }


 
    private void OnTriggerEnter2D(Collider2D  c)
    {
        if (controler.con.holdItem == false)
        {
            canKeep = true;
        }
        //transform.position.x = controler.con.transform.position.x;
       
        if(c.gameObject.tag == "target")
        {
            if (clickGU == true)
            {
                
                controler.con.holdItem = false;
                gameManagerT.gameManagerTT.numPic += 1;
                gameManagerT.gameManagerTT.selectedInfo[id-1] = 1;
                Destroy(this.gameObject);
                gameManagerT.gameManagerTT.line[currLine] = false;
                gameManagerT.gameManagerTT.keepCount += 1;
                switch (types)
                {
                    case 1:
                        gameManagerT.gameManagerTT.scoreTypes[0] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[0] = "Lastpick";
                        }
                        break;
                    case 2:
                        gameManagerT.gameManagerTT.scoreTypes[1] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[1] = "Lastpick";
                        }
                        break;
                    case 3:
                        gameManagerT.gameManagerTT.scoreTypes[2] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[2] = "Lastpick";
                        }
                        break;
                    case 4:
                        gameManagerT.gameManagerTT.scoreTypes[3] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[3] = "Lastpick";
                        }
                        break;
                    case 5:
                        gameManagerT.gameManagerTT.scoreTypes[4] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[4] = "Lastpick";
                        }
                        break;
                    case 6:
                        gameManagerT.gameManagerTT.scoreTypes[5] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[5] = "Lastpick";
                        }
                        break;
                    case 7:
                        gameManagerT.gameManagerTT.scoreTypes[6] += 1;
                        if (currLine == 2)
                        {
                            gameManagerT.gameManagerTT.attractionStatus[6] = "Lastpick";
                        }
                        break;

                }
                gameManagerT.gameManagerTT.Checktop();
            }

        }
    }
    private void OnTriggerExit2D()
    {
        if (clickGU == false)
        {
            canKeep = false;
            controler.con.holdItem = false;
        }
    }



}
