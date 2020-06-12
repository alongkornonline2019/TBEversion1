using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x > 0.6193849f)
        {
            
            Invoke("setScaleBack", 0.1f);
        }


    }

    void setScaleBack()
    {
        this.gameObject.transform.localScale = new Vector3(0.6193849f, 0.6193849f, 0.6193849f);
    }
}
