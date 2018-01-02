using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;


 

//public class Data   {
//    public List<LevelData> _ownBuildingList = new List<LevelData>();
//    public void SaveBuildingData(LevelData data)
//    {
//        string filePath = Application.dataPath + @"/Resources/Settings/JsonBuilding.txt";
//        if (!File.Exists(filePath))
//        {
//            _ownBuildingList = new LevelData();
//            _ownBuildingList._buildingList.Add(data);
//        }
//        else
//        {
//            bool bFind = false;
//            for (int i = 0; i < _ownBuildingList._buildingList.Count; ++i)
//            {
//                BuildingSaveData saveData = _ownBuildingList._buildingList[i];
//                if (data.strID == saveData.strID)
//                {
//                    saveData.nBuildingLevel = data.nBuildingLevel;  
//                ...  
//                bFind = true;
//                    break;
//                }
//            }
//            if (!bFind)
//                _ownBuildingList._buildingList.Add(data);
//        }

//        FileInfo file = new FileInfo(filePath);
//        StreamWriter sw = file.CreateText();
//        string json = JsonMapper.ToJson(_ownBuildingList);
//        sw.WriteLine(json);
//        sw.Close();
//        sw.Dispose();

//#if UNITY_EDITOR
//        AssetLevelData.Refresh();
//#endif
//    }


//}

public class LevelData
{
    public int Level { get; set; }//等级
    public List<Resource> Output =new List<Resource>();//产能   产出
    public List<Resource> RequestedSource =new List<Resource>();//达到产能所需的资源  消耗
    public List<Resource> UpSource= new List<Resource>();//升级所需的资源
   
}


public class DataC : MonoBehaviour {

    private DataC() { }
    public static readonly DataC instance = new DataC();

    List<LevelData> BuildingList = new List<LevelData>();
    // Use this for initialization
    void Start () {

     
    }
	
	// Update is called once per frame
	void Update () {
        
		
	}
  
}
