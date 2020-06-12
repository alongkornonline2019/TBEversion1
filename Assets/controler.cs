using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controler : MonoBehaviour
{
    public static controler con;

    public Vector3 mousePos;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 150f;
    public bool holdItem = false;

    public int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        holdItem = false; 
        con = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePos - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    
    }


}