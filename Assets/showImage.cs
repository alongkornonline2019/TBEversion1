using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    [SerializeField]
    GameObject renderPicPrefeb;
    public Image travelPic;
    public Sprite[] pic;
    protected string Types;
    // Start is called before the first frame update
   
    void Start()
    {
        LoadPic();
        travelPic = Instantiate(renderPicPrefeb, FindObjectOfType<Canvas>().transform).GetComponent<Image>();

                //#travelPic.gameObject.GetComponent<Image>().sprite =   .sprite = ;
    }

    // Update is called once per frame
    void Update()
    {
        travelPic.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
    public void LoadPic()
    {
        object[] loadedPic = Resources.LoadAll("a/", typeof(Sprite));
        pic = new Sprite[loadedPic.Length];
        for (int x = 0; x < loadedPic.Length; x++)
        {
            pic[x] = (Sprite)loadedPic[x];
        }
    }
}
