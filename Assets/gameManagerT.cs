using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LINQtoCSV;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Networking;
using Proyecto26;

public class gameManagerT : MonoBehaviour
{
    public GameObject night1;
    public GameObject night2;
    public GameObject night3;
    public GameObject Cul1;
    public GameObject Cul2;
    public GameObject Cul3;

    public GameObject city11;
    public GameObject city22;
    public GameObject city33;
    public GameObject nature1;
    public GameObject nature2;
    public GameObject nature3;
    public GameObject adven1;
    public GameObject adven2;
    public GameObject adven3;
  
    public GameObject healty1;
    public GameObject healty2;
    public GameObject healty3;


    public GameObject thankyou;
    public GameObject correct;
    public float mainSpeed;
    // point
    public GameObject bag;
    
    public Text Texttype1;
    public Text Texttype2;
    public Text Texttype3;
    public Text Texttype4;
    public Text Texttype5;
    public Text Texttype6;

    public float nightlife1 = 0;
    public float cultural2 = 0;
    public float city3 = 0;
    public float nature4 = 0;
    public float adventure5 = 0;
    public float healthy6 = 0;

    public float timer = 0.0f;
    public int []scoreTypes = new int[6];
    public int keepCount =0;

    public Button sentbutton;
    public int type1,
                type2,
                type3,
                type4,
                type5,
                type6;

    //-------------------------------------

    //----------------------------min[] max[]

    public bool pass = false;

    public int[] idRandom; 
    private bool gameStop = false;
    public static gameManagerT gameManagerTT;
    public GameObject poll;
    public int itemLine;
    public float x = 0;
    public float y = 0;


    public int[] leveloflike = new int[6];
    public GameObject[] point;
    public bool[] line = new bool[3];
    public int[] selectedInfo;
    
    string path1;


    [SerializeField]
    public Sprite pic2;
    public Sprite[] pic;

    [SerializeField]
    protected string Types;
    public int numPic = 0;

    public TextAsset sceneDescriptor;

    public List<int> idInfo = new List<int>();
   // public List<string> nameInfo = new List<string>();
    public List<int> typesInfo = new List<int>();

    public bool[] pictureOut;
    //---------------------------------------------Manage Stage----------------------------------------------------------'
    private string gameStage = "GAME_START";
    public string[] attractionStatus = new string[6];

    //--------------------reload3-------------------------
    [SerializeField]
    private int nextTypeCreate = 0;

    //--------------------reload2-------------------------
    public int secondScore;
    public int maxNormal = 0;

    //--------------------reload1-------------------------
    public int top = 2;
    public int countTop;
    [SerializeField]

    public int numpic2;

    //--------------------Show UI----------------------------
    public GameObject panel;
    public GameObject TypesBorad;
    public string behavExplan;
    public Text behavText;

    public Slider satifactionScoreInput;
    public Text satifactionScoreShow;
    public int satifactionScore;
    public InputField studentIDinput;
    


    /// <info>
    ///  
    public string studentIdinfo;
    public string ageInfo;
    public int sexInfo;

    /// </info>
    void Start()
    {

        studentIdinfo = PlayerPrefs.GetString("studentIdinfo");
        ageInfo = PlayerPrefs.GetString("ageInfo");
        sexInfo = PlayerPrefs.GetInt("sexInfo");
  


        pass = false;

        mainSpeed = 0.06f;

        gameManagerTT = this;
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            using (var ms = new MemoryStream(sceneDescriptor.text.Length))
            {
                using (var txtWriter = new StreamWriter(ms))
                {
                    using (var txtReader = new StreamReader(ms))
                    {
                        txtWriter.Write(sceneDescriptor.text);
                        txtWriter.Flush();
                        ms.Seek(0, SeekOrigin.Begin);

                        // Read the data from the CSV file
                        CsvContext cc = new CsvContext();
                        cc.Read<CSVObject>(txtReader, inputFileDescription)
                          .ToList()
                          .ForEach(so =>
                          {
                              idInfo.Add(so.id);
                              
                              typesInfo.Add(so.types);
                              //Debug.Log(so.id);
                              //Debug.Log(so.tourism_name);
                              // Debug.Log(so.types);
                          });
                    }
                }
            }







            // Debug.Log("aaa");
            LoadPic();
            RandomTourism();
            
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = false;
            }

        }

        selectedInfo = new int[idInfo.Count];
        for (int i = 0; i < selectedInfo.Length; i++)
        {
            selectedInfo[i] = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        satifactionScore = (int)satifactionScoreInput.value;
        satifactionScoreShow.text = satifactionScore + " point";
        


        if (gameStage != "GAME_END")
        {
            timer += Time.deltaTime;
        }


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("p"))
        {
            mainSpeed += 0.01f;
            
        }

        if (Input.GetKeyDown("m"))
        {
            mainSpeed -= 0.01f;
           
        }

        if (numPic >= pic.Length)
        {
            gameStage = "GAME_END";
        }
        //--------------------------------------------------------- 1 -----------------------------------------------------------------------------

        if (gameStage == "GAME_START")
        {
            setScore();
            RandomTourism();
            gameStage = "RELOAD3";
        }


        //--------------------------------------------------------- 2 -----------------------------------------------------------------------------

        if (gameStage == "RELOAD3")
        {

            if(attractionStatus[nextTypeCreate] == "normal")
            {
                for (int findid = 0; findid < pic.Length; findid++)
                {
                    if((typesInfo[findid] == nextTypeCreate+1) && (pictureOut[findid] == false))
                    {
                        CreatePoll(2, findid);
                        pictureOut[findid] = true;
                        line[2] = true;
                        break;
                    }
                }

            }
            nextTypeCreate += 1;
            gameStage = "MONITOR";
        }


        //--------------------------------------------------------- 3 -----------------------------------------------------------------------------

        if (gameStage == "RELOAD2")
        {

            int tempFindid2 = 90;
            int temptypes = 90;

            List<int> secondTemp = new List<int>();
            int RandomSecondTypes = 0;
            for (int count = 0; count < attractionStatus.Length; count++)
            {
                if (attractionStatus[count] == "second")
                {
                    secondTemp.Add(count);
                    RandomSecondTypes = Random.Range(0, secondTemp.Count);
                }
            }

            if ((secondTemp.Count > 0) && (line[1]==false))
            {
                for (int findid2 = 0; findid2 < pic.Length; findid2++)
                {
                    if ((typesInfo[findid2] == (secondTemp[RandomSecondTypes]) + 1) && (pictureOut[findid2] == false))
                    {
                        temptypes = RandomSecondTypes;
                        tempFindid2 = findid2;

                        break;
                    }
                }
                if ((temptypes != 90) && (tempFindid2 != 90))
                {
                    //attractionStatus[temptypes] = "normal";
                    CreatePoll(1, tempFindid2);
                    pictureOut[tempFindid2] = true;
                    line[1] = true;
                }

            }
            else
            {
                for (int count2 = 0; count2 < attractionStatus.Length; count2++)
                {
                    if (attractionStatus[count2] == "Lastpick")
                    {
                        for (int findid2 = 0; findid2 < pic.Length; findid2++)
                        {
                            if ((typesInfo[findid2] == (count2 + 1)) && (pictureOut[findid2] == false))
                            {
                                temptypes = count2;
                                tempFindid2 = findid2;
                                break;
                            }
                        }

                    }
                }
                if ((temptypes != 90) && (tempFindid2 != 90))
                {
                    attractionStatus[temptypes] = "normal";
                    CreatePoll(1, tempFindid2);
                    pictureOut[tempFindid2] = true;
                    line[1] = true;
                }
            }

            gameStage = "MONITOR";
        }


        //--------------------------------------------------------- 4 -----------------------------------------------------------------------------

        if (gameStage == "RELOAD1")
        {
            Debug.Log("IN");
            int tempFindid3 = 90;
            int temptypes = 90;
            int tempCount = 0;
            List<int> topTemp = new List<int>();
            int RandomTopTypes = 0;
            for (int count = 0; count < attractionStatus.Length; count++)
            {
                if (attractionStatus[count] == "top")
                {
                    topTemp.Add(count);
                    RandomTopTypes = Random.Range(0, topTemp.Count);
                }
            }

                for (int findid2 = 0; findid2 < pic.Length; findid2++)
                {
                    if ((typesInfo[findid2] == (topTemp[RandomTopTypes])+1) && (pictureOut[findid2] == false))
                    {
                        temptypes = RandomTopTypes;
                        tempFindid3 = findid2;

                        break;
                    }
                }
            if ((temptypes != 90) && (tempFindid3 != 90))
            {
                //attractionStatus[temptypes] = "normal";
                CreatePoll(0, tempFindid3);
                pictureOut[tempFindid3] = true;
                line[0] = true;
            }


            /*
            for (int count2 = 0; count2 < attractionStatus.Length; count2++)
            {
                if (attractionStatus[count2] == "top")
                {

                    for (int findid2 = 0; findid2 < pic.Length; findid2++)
                    {
                        if ((typesInfo[findid2] == (count2 + 1)) && (pictureOut[findid2] == false))
                        {
                            temptypes = count2;
                            tempFindid3 = findid2;

                            break;
                        }
                    }

                }
            }
           
            */




            gameStage = "MONITOR";
        }


        //--------------------------------------------------------- 5 -----------------------------------------------------------------------------

        if (gameStage == "GAME_END" && pass == false)
        {
            Debug.Log("End");
            
            panel.SetActive(true);
            cal();
            displayText();
            pass = true;
        }

       

        //-----------------------------------------------------------------------------------------------------------------------------------------

        if (gameStage == "MONITOR")
        {
            maxNormal = 0;
            
          



            for (int count = 0; count < attractionStatus.Length; count++)
            {
                if (attractionStatus[count] != "empty")
                {
                    bool have = false;
                    for (int findid2 = 0; findid2 < pic.Length; findid2++)
                    {
                        if ((typesInfo[findid2] == (count + 1)) && (pictureOut[findid2] == false))
                        {
                            have = true;
                            break;
                        }
                    }
                    if(have == true)
                    {

                    }
                    else
                    {

                        if (attractionStatus[count] == "top")
                        {
                            top = 2;
                            
                        }
                        attractionStatus[count] = "empty";
                    }
                        
                }
            }

            if (gameStop == false && line[2] == false)
            {
                gameStage = "RELOAD3";
            }

            if (nextTypeCreate >= attractionStatus.Length)
            {
                Debug.Log("nextTypeCreate"+nextTypeCreate);
                nextTypeCreate = 0;
            }
            
            
            for (int count = 0; count < attractionStatus.Length; count++)
            {

                if (attractionStatus[count] == "top" && (scoreTypes[count] != top))
                {
                    attractionStatus[count] = "second";
                   
                }
                if (attractionStatus[count] == "second" && (scoreTypes[count] != secondScore))
                {
                    attractionStatus[count] = "normal";
                }
                

                if (((attractionStatus[count] == "Lastpick") || (attractionStatus[count] == "second")) && line[1] == false)
                {
                    gameStage = "RELOAD2";
                }

                if ((attractionStatus[count] == "top") && line[0] == false)
                {
                    gameStage = "RELOAD1";
                }
            }

            
            /*
            Debug.Log("Hel");
            if ((line[1] == false) && (keepCount > 3) && (gameStage != "RELOAD2"))
            {
                Debug.Log("Hello");
                int s = 0;
                for (int count = 0; count < attractionStatus.Length; count++)
                {
                    if ((attractionStatus[count] == "normal") && (scoreTypes[count] > s))
                    {
                        s = scoreTypes[count];
                        attractionStatus[s] = "lastpick";
                        Debug.Log("Hello"+s);
                        break;
                    }
                }
                
            }
            
           int countSecond = 0;
           int countLastpick = 0;
           int numberTypes = 99;

           List<int> NormalTemp = new List<int>();
           int RandomSecondTypes = 0;
           for (int count = 0; count < attractionStatus.Length; count++)
           {
               if (attractionStatus[count] == "normal")
               {
                   NormalTemp.Add(count);
                   RandomSecondTypes = Random.Range(0, NormalTemp.Count);
               }
           }

           /*
            for (int count = 0; count < attractionStatus.Length; count++)
            {

                if ((scoreTypes[count] > maxNormal) && (attractionStatus[count] == "normal"))  
                {
                    maxNormal = scoreTypes[count];
                    numberTypes = count;
                }

            }

            /*
            if ((line[1] == false))
            {
                for (int count = 0; count < attractionStatus.Length; count++)
                {
                    if ((scoreTypes[count] > maxNormal) && (attractionStatus[count] == "normal"))
                    {
                        maxNormal = scoreTypes[count];
                        numberTypes = count;

                    }
                }

                if ((countLastpick == 0) && (countSecond == 0) && (maxNormal!=0))
                {
                    attractionStatus[numberTypes] = "lastpick";
                }   


            }
            */



        }
        
    }

    public void Checktop()
    {
        
        bag.gameObject.transform.localScale = new Vector3(0.8193849f, 0.8193849f, 0.8193849f);

        for (int count = 0; count < attractionStatus.Length; count++)
        {
            if (attractionStatus[count] == "top")
            {
                countTop += 1;
            }
        }
        for (int count = 0; count < attractionStatus.Length; count++)
        {
            if ((scoreTypes[count] >= top) && attractionStatus[count] != "empty")
            {
                secondScore = top;
                top = scoreTypes[count];
                attractionStatus[count] = "top";
            }

            if ((scoreTypes[count] >= secondScore) && (attractionStatus[count] != "empty") && ((scoreTypes[count] < top)) && (countTop > 0))
            {
                secondScore = scoreTypes[count];
                
                attractionStatus[count] = "second";
            }
        }
        countTop = 0;
    }
    void LoadPic()
    {
        object[] loadedPic = Resources.LoadAll(Types, typeof(Sprite));
        pic = new Sprite[loadedPic.Length];
        for (int x = 0; x < loadedPic.Length; x++)
        {
            pic[x] = (Sprite)loadedPic[x];
        }

    }
    void RandomTourism()
    {
        idRandom = new int[pic.Length];
        pictureOut = new bool[pic.Length];
        for (int x = 0; x < idRandom.Length; x++)
        {
            idRandom[x] = x+1;
            pictureOut[x] = false;
        }
        
        int tempGO;
        int tempID;
        int tempTypes;
        Sprite tempPic;
        
            for (int i = 0; i < idRandom.Length; i++)
            {
                int rnd = Random.Range(0, idRandom.Length);
                tempGO = idRandom[rnd];
                tempID = idInfo[rnd];
                tempTypes = typesInfo[rnd];
                tempPic = pic[rnd];

                idRandom[rnd] = idRandom[i];
                idInfo[rnd] =  idInfo[i];
                typesInfo[rnd] = typesInfo[i];
                pic[rnd] = pic[i];

                idRandom[i] = tempGO;
                idInfo[i] = tempID;
                typesInfo[i] = tempTypes;
                pic[i] = tempPic;

            }
        
    }
    void CreatePoll(int itemLine,int id)
    {
        x = point[itemLine].transform.position.x;
        Instantiate(poll, new Vector3(x, 7.6f, 0.0f), Quaternion.identity);
        
        move.moveMove.currLine = itemLine;
        numpic2 = id;

        //Debug.Log(id);
        //numPic++;
    }
    
    void cal()
    {

        nightlife1 = ((float)scoreTypes[0] / 10) * 100;
        cultural2 = ((float)scoreTypes[1] / 10) * 100;
        city3 = ((float)scoreTypes[2] / 10) * 100;
        nature4 = ((float)scoreTypes[3] / 10) * 100;
        adventure5 = ((float)scoreTypes[4] / 10) * 100;
        healthy6 = ((float)scoreTypes[5] / 10) * 100;

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if(nightlife1 < 40)
        {
            type1 = 1;
        }
        if(nightlife1 > 60)
        {
            type1 = 3;
        }
        if(nightlife1 >= 40 && nightlife1 <= 60)
        {
            type1 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (cultural2 < 40)
        {
            type2 = 1;
        }
        if (cultural2 > 60)
        {
            type2 = 3;
        }
        if (cultural2 >= 40 && cultural2 <= 60)
        {
            type2 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (city3 < 40)
        {
            type3 = 1;
        }
        if (city3 > 60)
        {
            type3 = 3;
        }
        if (city3 >= 40 && city3 <= 60)
        {
            type3 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (nature4 < 40)
        {
            type4 = 1;
        }
        if (nature4 > 60)
        {
            type4 = 3;
        }
        if (nature4 >= 40 && nature4 <= 60)
        {
            type4 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (adventure5 < 40)
        {
            type5 = 1;
        }
        if (adventure5 > 60)
        {
            type5 = 3;
        }
        if (adventure5 >= 40 && adventure5 <= 60)
        {
            type5 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (healthy6 < 40)
        {
            type6 = 1;
        }
        if (healthy6 > 60)
        {
            type6 = 3;
        }
        if (healthy6 >= 40 && healthy6 <= 60)
        {
            type6 = 2;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        leveloflike[0] = type1;
        leveloflike[1] = type2;
        leveloflike[2] = type3;
        leveloflike[3] = type4;
        leveloflike[4] = type5;
        leveloflike[5] = type6;


      

    }
    void setScore()
    {
        nextTypeCreate = 0;
        gameStop = false;
        numPic = 0;
        
        keepCount = 0;

        for(int count = 0; count< attractionStatus.Length; count++)
        {
            attractionStatus[count] = "normal";
            scoreTypes[count] = 0;
        }

    }



    void InsertDataToOnline()
    {
        setDataObjforDB obj = new setDataObjforDB();
        //RestClient.Post("https://tbdgame-5cb60.firebaseio.com/"+ "player" + ".json", obj);
        RestClient.Post("https://tbeversion1.firebaseio.com/.json", obj);
        Debug.Log("in");

    }




    void displayText()
    {
        Texttype1.text = "Nightlife & Party";
        Texttype2.text = "Cultural heritage & Religions";
        Texttype3.text = "City & Shopping" ;
        Texttype4.text = "Nature and Animal" ;
        Texttype5.text = "Adventure & Hard sport" ;
        Texttype6.text = "Healthy & Soft sport";

        if (leveloflike[0] == 1)
        {
            night2.SetActive(false);
            night3.SetActive(false);
        }
        if (leveloflike[0] == 2)
        {
            night3.SetActive(false);
        }

        if (leveloflike[1] == 1)
        {
            Cul2.SetActive(false);
            Cul3.SetActive(false);
        }
        if (leveloflike[1] == 2)
        {
            Cul3.SetActive(false);
        }
        if (leveloflike[2] == 1)
        {
            city33.SetActive(false);
            city22.SetActive(false);
        }
        if (leveloflike[2] == 2)
        {
            city33.SetActive(false);
        }

        if (leveloflike[3] == 1)
        {
            nature2.SetActive(false);
            nature3.SetActive(false);
        }
        if (leveloflike[3] == 2)
        {
            nature3.SetActive(false);
        }


        if (leveloflike[4] == 1)
        {
            adven2.SetActive(false);
            adven3.SetActive(false);
        }
        if (leveloflike[4] == 2)
        {
            adven3.SetActive(false);
        }

        
        if (leveloflike[5] == 1)
        {
            healty2.SetActive(false);
            healty3.SetActive(false);
        }
        if (leveloflike[5] == 2)
        {
            healty3.SetActive(false);
        }
    }



    public void sentButton()
    {
        InsertDataToOnline();
        sentbutton.interactable = false;
        panel.SetActive(false);
        thankyou.SetActive(true);
        Application.OpenURL("https://forms.gle/USf4xuY6MopBYY9XA");
        
    }

    public void correctDisplay()
    {
        GameObject correctPic = Instantiate(correct) as GameObject;
        
    }
}
