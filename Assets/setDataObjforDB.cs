using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class setDataObjforDB : MonoBehaviour
{
    public int Scoretype1;
    public int Scoretype2;
    public int Scoretype3;
    public int Scoretype4;
    public int Scoretype5;
    public int Scoretype6;

    public int ptype1;
    public int ptype2;
    public int ptype3;
    public int ptype4;
    public int ptype5;
    public int ptype6;

    public float playingTime;
    public int satifactionScore;

    
    public int pictureSelected1;
    public int pictureSelected2;
    public int pictureSelected3;
    public int pictureSelected4;
    public int pictureSelected5;
    public int pictureSelected6;
    public int pictureSelected7;
    public int pictureSelected8;
    public int pictureSelected9;
    public int pictureSelected10;
    public int pictureSelected11;
    public int pictureSelected12;
    public int pictureSelected13;
    public int pictureSelected14;
    public int pictureSelected15;
    public int pictureSelected16;
    public int pictureSelected17;
    public int pictureSelected18;
    public int pictureSelected19;
    public int pictureSelected20;
    public int pictureSelected21;
    public int pictureSelected22;
    public int pictureSelected23;
    public int pictureSelected24;
    public int pictureSelected25;
    public int pictureSelected26;
    public int pictureSelected27;
    public int pictureSelected28;
    public int pictureSelected29;
    public int pictureSelected30;
    public int pictureSelected31;
    public int pictureSelected32;
    public int pictureSelected33;
    public int pictureSelected34;
    public int pictureSelected35;
    public int pictureSelected36;
    public int pictureSelected37;
    public int pictureSelected38;
    public int pictureSelected39;
    public int pictureSelected40;
    public int pictureSelected41;
    public int pictureSelected42;
    public int pictureSelected43;
    public int pictureSelected44;
    public int pictureSelected45;
    public int pictureSelected46;
    public int pictureSelected47;
    public int pictureSelected48;
    public int pictureSelected49;
    public int pictureSelected50;
    public int pictureSelected51;
    public int pictureSelected52;
    public int pictureSelected53;
    public int pictureSelected54;
    public int pictureSelected55;
    public int pictureSelected56;
    public int pictureSelected57;
    public int pictureSelected58;
    public int pictureSelected59;
    public int pictureSelected60;



   
    public string studentID;
    public string age;
    public int sex;


    public setDataObjforDB()
    {
        Scoretype1 = gameManagerT.gameManagerTT.scoreTypes[0];
        Scoretype2 = gameManagerT.gameManagerTT.scoreTypes[1];
        Scoretype3 = gameManagerT.gameManagerTT.scoreTypes[2];
        Scoretype4 = gameManagerT.gameManagerTT.scoreTypes[3];
        Scoretype5 = gameManagerT.gameManagerTT.scoreTypes[4];
        Scoretype6 = gameManagerT.gameManagerTT.scoreTypes[5];


        ptype1 = gameManagerT.gameManagerTT.type1;
        ptype2 = gameManagerT.gameManagerTT.type2;
        ptype3 = gameManagerT.gameManagerTT.type3;
        ptype4 = gameManagerT.gameManagerTT.type4;
        ptype5 = gameManagerT.gameManagerTT.type5;
        ptype6 = gameManagerT.gameManagerTT.type6;

        playingTime = gameManagerT.gameManagerTT.timer;
        satifactionScore = gameManagerT.gameManagerTT.satifactionScore;

        

        pictureSelected1 = gameManagerT.gameManagerTT.selectedInfo[0];
        pictureSelected2 = gameManagerT.gameManagerTT.selectedInfo[1];
        pictureSelected3 = gameManagerT.gameManagerTT.selectedInfo[2];
        pictureSelected4 = gameManagerT.gameManagerTT.selectedInfo[3];
        pictureSelected5 = gameManagerT.gameManagerTT.selectedInfo[4];
        pictureSelected6 = gameManagerT.gameManagerTT.selectedInfo[5];
        pictureSelected7 = gameManagerT.gameManagerTT.selectedInfo[6];
        pictureSelected8 = gameManagerT.gameManagerTT.selectedInfo[7];
        pictureSelected9 = gameManagerT.gameManagerTT.selectedInfo[8];
        pictureSelected10 = gameManagerT.gameManagerTT.selectedInfo[9];

        pictureSelected11 = gameManagerT.gameManagerTT.selectedInfo[10];
        pictureSelected12 = gameManagerT.gameManagerTT.selectedInfo[11];
        pictureSelected13 = gameManagerT.gameManagerTT.selectedInfo[12];
        pictureSelected14 = gameManagerT.gameManagerTT.selectedInfo[13]; 
        pictureSelected15 = gameManagerT.gameManagerTT.selectedInfo[14];
        pictureSelected16 = gameManagerT.gameManagerTT.selectedInfo[15];
        pictureSelected17 = gameManagerT.gameManagerTT.selectedInfo[16];
        pictureSelected18 = gameManagerT.gameManagerTT.selectedInfo[17];
        pictureSelected19 = gameManagerT.gameManagerTT.selectedInfo[18];
        pictureSelected20 = gameManagerT.gameManagerTT.selectedInfo[19];

        pictureSelected21 = gameManagerT.gameManagerTT.selectedInfo[20];
        pictureSelected22 = gameManagerT.gameManagerTT.selectedInfo[21];
        pictureSelected23 = gameManagerT.gameManagerTT.selectedInfo[22];
        pictureSelected24 = gameManagerT.gameManagerTT.selectedInfo[23];
        pictureSelected25 = gameManagerT.gameManagerTT.selectedInfo[24];
        pictureSelected26 = gameManagerT.gameManagerTT.selectedInfo[25];
        pictureSelected27 = gameManagerT.gameManagerTT.selectedInfo[26];
        pictureSelected28 = gameManagerT.gameManagerTT.selectedInfo[27];
        pictureSelected29 = gameManagerT.gameManagerTT.selectedInfo[28];
        pictureSelected30 = gameManagerT.gameManagerTT.selectedInfo[29];

        pictureSelected31 = gameManagerT.gameManagerTT.selectedInfo[30];
        pictureSelected32 = gameManagerT.gameManagerTT.selectedInfo[31];
        pictureSelected33 = gameManagerT.gameManagerTT.selectedInfo[32];
        pictureSelected34 = gameManagerT.gameManagerTT.selectedInfo[33];
        pictureSelected35 = gameManagerT.gameManagerTT.selectedInfo[34];
        pictureSelected36 = gameManagerT.gameManagerTT.selectedInfo[35];
        pictureSelected37 = gameManagerT.gameManagerTT.selectedInfo[36];
        pictureSelected38 = gameManagerT.gameManagerTT.selectedInfo[37];
        pictureSelected39 = gameManagerT.gameManagerTT.selectedInfo[38];
        pictureSelected40 = gameManagerT.gameManagerTT.selectedInfo[39];

        pictureSelected41 = gameManagerT.gameManagerTT.selectedInfo[40];
        pictureSelected42 = gameManagerT.gameManagerTT.selectedInfo[41];
        pictureSelected43 = gameManagerT.gameManagerTT.selectedInfo[42];
        pictureSelected44 = gameManagerT.gameManagerTT.selectedInfo[43];
        pictureSelected45 = gameManagerT.gameManagerTT.selectedInfo[44];
        pictureSelected46 = gameManagerT.gameManagerTT.selectedInfo[45];
        pictureSelected47 = gameManagerT.gameManagerTT.selectedInfo[46];
        pictureSelected48 = gameManagerT.gameManagerTT.selectedInfo[47];
        pictureSelected49 = gameManagerT.gameManagerTT.selectedInfo[48];
        pictureSelected50 = gameManagerT.gameManagerTT.selectedInfo[49];

        pictureSelected51 = gameManagerT.gameManagerTT.selectedInfo[50];
        pictureSelected52 = gameManagerT.gameManagerTT.selectedInfo[51];
        pictureSelected53 = gameManagerT.gameManagerTT.selectedInfo[52];
        pictureSelected54 = gameManagerT.gameManagerTT.selectedInfo[53];
        pictureSelected55 = gameManagerT.gameManagerTT.selectedInfo[54];
        pictureSelected56 = gameManagerT.gameManagerTT.selectedInfo[55];
        pictureSelected57 = gameManagerT.gameManagerTT.selectedInfo[56];
        pictureSelected58 = gameManagerT.gameManagerTT.selectedInfo[57];
        pictureSelected59 = gameManagerT.gameManagerTT.selectedInfo[58];
        pictureSelected60 = gameManagerT.gameManagerTT.selectedInfo[59];


        studentID=  gameManagerT.gameManagerTT.studentIdinfo;
        age=  gameManagerT.gameManagerTT.ageInfo;
        sex=gameManagerT.gameManagerTT.sexInfo;
   
    }
}

