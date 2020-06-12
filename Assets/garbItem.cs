using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbItem : MonoBehaviour
{
    public static garbItem garbing;
    public bool editPos = false;
    private Vector2 mousePosition;
    public static bool locked;
    private float delX, delY;
    //protected bool edit_pos = false;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        garbing = this;
    }

    // Update is called once per frame
    void Update()
    {

   
    }
    private void OnMouseDown()
    {
        if (!locked)
        {
            delX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            delY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - delX, mousePosition.y - delY);
        }
    }


}
    

