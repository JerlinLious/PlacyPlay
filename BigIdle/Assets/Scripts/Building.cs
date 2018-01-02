using System;

using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public enum BuildingType
{
    House,
    Farm,
    WoodHouse,
    StoneHouse
}
public class BuildingQ
{
    public BuildingType bt;
    public int Quantities;
    public List<ResQt> Production = new List<ResQt>();
    public List<ResQt> Consumption = new List<ResQt>();
   // public List<ResQt> UpdateConsumption = new List<ResQt>();

}

public class Building : MonoBehaviour {
    private Building() { }
    public static readonly Building Binstance = new Building();
    public List<BuildingQ> BuildingQList = new List<BuildingQ>();
	// Use this for initialization
	void Start () {
        // foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))

        //house set
        BuildingQ temp = new BuildingQ();
        temp.bt = BuildingType.House;
        temp.Quantities = 0;
        ResQt tqr = new  ResQt();
        tqr.rt = ResType.Population;
        tqr.quantity  = 3;
        temp.Production.Add(tqr);
        ResQt tqr2 = new ResQt();
        tqr2.rt = ResType.Stone ;
        tqr2.quantity = 400;
        temp.Consumption .Add(tqr2);
        ResQt tqr3 = new ResQt();
        tqr3.rt = ResType.Wood;
        tqr3.quantity = 200;
        temp.Consumption.Add(tqr3);
       Binstance . BuildingQList.Add(temp);
        //farm set
        BuildingQ temp2 = new BuildingQ();
        temp2.bt = BuildingType.Farm;
        temp2.Quantities = 0;
        ResQt tqr4 = new ResQt();
        tqr4.rt = ResType.Food ;
        tqr4.quantity = 3;
        temp2.Production.Add(tqr4);
        ResQt tqr5 = new ResQt();
        tqr5.rt = ResType.Wood;
        tqr5.quantity = 200;
        temp2.Consumption.Add(tqr5);
        Binstance.BuildingQList.Add(temp2);
        //woodhouse
        BuildingQ temp3 = new BuildingQ();
        temp3.bt = BuildingType.WoodHouse;
        temp3.Quantities = 0;
        ResQt tqr6 = new ResQt();
        tqr6.rt = ResType.Wood;
        tqr6.quantity = 2;
        temp3.Production.Add(tqr6);
        ResQt tqr7 = new ResQt();
        tqr7.rt = ResType.Wood;
        tqr7.quantity = 200;
        temp3.Consumption.Add(tqr7);
        Binstance.BuildingQList.Add(temp3);
        //StoneHouse
        BuildingQ temp4 = new BuildingQ();
        temp4.bt = BuildingType.StoneHouse;
        temp4.Quantities = 0;
        ResQt tqr8 = new ResQt();
        tqr8.rt = ResType.Stone ;
        tqr8.quantity = 2;
        temp4.Production.Add(tqr8);
        ResQt tqr9 = new ResQt();
        tqr9.rt = ResType.Wood;
        tqr9.quantity = 300;
        temp4.Consumption.Add(tqr9);
        tqr9.rt = ResType.Stone;
        tqr9.quantity = 100;
        temp4.Consumption.Add(tqr9);
        Binstance.BuildingQList.Add(temp4);



    }
	
	// Update is called once per frame
	void Update () {









		
	}
  
    public void addQuantity(BuildingType ty)
    {
        Res t = Res.Rinstance;

        var tes = Binstance.BuildingQList.Find((x) => { return x.bt == ty; });

        bool flag = true;
        //检测资源是否满足条件
        foreach (ResQt obj in tes.Consumption)
        {
            flag = flag & t.checkAmount(obj.rt, obj.quantity);

        }
        if (flag)//满足的话
        {
            tes.Quantities++;//增量
            foreach (ResQt obj in tes.Consumption)//减少值
            {
                t.addAmount(obj.rt, obj.quantity * -1, 1);
            }
        }else
        {
          // EditorUtility.DisplayDialog("警告", "资源不足", "确认");
            return;
        } 


        foreach (ResQt obj in tes.Production)
        {
            t.addProduct(obj.rt, obj.quantity, tes.Quantities);
        }
    }
}
