using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using System;

public class SaveTest : MonoBehaviour {
    public class BuildingSave
    {
        public BuildingType type;
        public int Quantities;
    }
    /// <summary>
    /// 定义一个测试类
    /// </summary>
    public class TestClass
    {
        public string Name = "张三";
        public float Age = 23.0f;
        public int Sex = 1;

        public List<int> Ints = new List<int>()
        {
            1,
            2,
            3
        };
        public List<ResourceQ> SaveList = new List<ResourceQ>();
        public List<BuildingSave> SaveBList = new List<BuildingSave>();
    }

    void Start()
    {
        //定义存档路径
        string dirpath = Application.persistentDataPath + "/Save";
        //创建存档文件夹
        GameSaveManager.IOHelper.CreateDirectory(dirpath);
        //定义存档文件路径
        string filename = dirpath + "/GameData.sav";
        TestClass t = new TestClass();
        //保存数据
        Res tp = Res.Rinstance;
        Building tp2 = Building.Binstance;
        t.SaveList = tp.ResQList;
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))//restype
        { BuildingSave bs = new BuildingSave();
            bs.type = tp2.BuildingQList[(int)type].bt;
            bs.Quantities = tp2.BuildingQList[(int)type].Quantities;
            t.SaveBList.Add(bs);
            
    }
        string json = JsonMapper.ToJson(t  );

        string fp = "info.json";
        File.WriteAllText(fp, json);


        GameSaveManager.IOHelper.SetData(filename, t  );
        //读取数据
        TestClass t1 = (TestClass)GameSaveManager.IOHelper.GetData(filename, typeof(TestClass));

        Debug.Log(t1.Name);
        Debug.Log(t1.Age);
        Debug.Log(t1.Ints);
    }
}
