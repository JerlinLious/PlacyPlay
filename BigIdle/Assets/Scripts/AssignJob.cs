using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

 
public enum AssignType{
  WoodCut,// 伐木
StonePick,//采石
IronMelt,//炼铁
GoldMelt,//炼金
Plant,//种植
Sheep,//放牧
Bake//烘培

}
public class AssignID
{
    public AssignType ID;//数量
    public int Quantity { get; set; }//数量
    public int UpLimit { get; set; }//上限
    public int CurrentLevel { get; set;}
    public List<LevelData> LevelDataList = new List<LevelData>();
}
public class Assign
{

    public List<AssignID> AssignList = new List<AssignID>();
}

public class AssignJob : MonoBehaviour
{
    private AssignJob() { initialisze(); }
    public static readonly AssignJob instance = new AssignJob();

    public int upLimit = 5;
    public Assign assign = new Assign();
    
    // Use this for initialization
    void Start()
    {
      
        initialisze();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void initialisze()
    {
        //初始化资源  shuliang Uplimit waiyi
        


        foreach (AssignType type in Enum.GetValues(typeof(AssignType)))//job assign
        {
            AssignID asID = new AssignID();
            asID.UpLimit = upLimit;
            asID.Quantity = 0;
            asID.ID =  type;
            asID.CurrentLevel = 0;
            for (int i = 0; i < upLimit; i++)//level
            {
                LevelData lData = new LevelData();
                Resource rs = new Resource();

                rs.ResourceQuantity = 1 * i;
                rs.RourceName = (ResourceType)(int)type;

                lData.Level = i;
                lData.Output.Add(rs);
                lData.RequestedSource.Add(rs);
                //  lData.RequestedSource.Add(rs);
                lData.UpSource.Add(rs);
                asID.LevelDataList.Add(lData);
            }
            assign.AssignList.Add(asID);
        }

        //写入Json
        string json = JsonMapper.ToJson(assign);
        
        string fp = "info.json";
        File.WriteAllText(fp, json);
        //读取json
        //  string Tson =  File.ReadAllText("info.json");
        // List <LevelData> player2 = JsonMapper.ToObject<List<LevelData>>(Tson);
        // print(player2);

        
    }
}