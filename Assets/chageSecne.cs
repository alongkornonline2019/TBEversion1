using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chageSecne : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject getID;
    public GameObject instaction1;
    public GameObject getPreferace;
    // basic info
    public InputField studentID;
    public InputField age;
    public Dropdown sex;



    public string studentIdinfo;
    public string ageInfo;
    public int sexInfo;


    void Start()
    {
        getID.gameObject.SetActive(true);
        instaction1.gameObject.SetActive(false);
        getPreferace.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next1()
    {
        studentIdinfo = studentID.text;
        ageInfo = age.text;
        sexInfo = sex.value;

        getID.SetActive(false);
        instaction1.SetActive(false);
        getPreferace.SetActive(true);
        

    }
    public void next2()
    {

        getID.SetActive(false);
        instaction1.SetActive(true);
        getPreferace.SetActive(false);


    }

    public void go()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("studentIdinfo", studentIdinfo);
        PlayerPrefs.SetString("ageInfo", ageInfo);
        PlayerPrefs.SetInt("sexInfo", sexInfo);
        SceneManager.LoadScene(1);
    }
}
