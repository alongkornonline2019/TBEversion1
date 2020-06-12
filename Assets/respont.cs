using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respont : MonoBehaviour
{
    void Start()
    {
        Invoke("del", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, this.GetComponent<RectTransform>().anchoredPosition.y + 5);
    }

    void del()
    {
        
        Destroy(this.gameObject);
    }
}
