using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResType
{
   Food,
   Wood,
    Iron,
   Stone,
   Population
}
public class ResQt{
    public ResType rt;
    public int quantity;
    }
public class ResourceQ
{
     public    ResType ty;
    //resource total amount
    public int TotalAmount { get; set; }
    //resource current amount
    public int CurrentAmount { get; set; }
    public int Product { get; set; }
    


}
public class Res: MonoBehaviour
{
    private Res() {   }
    public static readonly Res Rinstance = new Res();
    public List<ResourceQ > ResQList = new List<ResourceQ>();
 
void Start()
    {
        foreach (ResType type in Enum.GetValues(typeof(ResType)))//restype
        {
            ResourceQ temps = new ResourceQ();
            temps.ty = type;
            temps.TotalAmount = 0;
            temps.CurrentAmount =500;
            temps.Product = 0;
             
            int te = (int)type + 1;
            Text text = GameObject.Find("Canvas/Text (" + te + ")").GetComponent<Text>();
            text.text  = temps.CurrentAmount.ToString();
            int pe = (te ) * 10+1;
           // to be optimised
            if (pe != 51) {
                Text text2 = GameObject.Find("Canvas/Text (" + pe + ")").GetComponent<Text>();
                text2.text = temps.Product.ToString();
            }

            Rinstance.ResQList.Add(temps);
        }
    }
 
    void Update()
    {
        refreshScreen();

        foreach (ResType type in Enum.GetValues(typeof(ResType)))//restype
        { Rinstance.ResQList[(int)type].CurrentAmount += Rinstance.ResQList[(int)type].Product;
            if (Rinstance.ResQList[(int)type].CurrentAmount > 9999)
                Rinstance.ResQList[(int)type].CurrentAmount = 9999; }

    }
    public bool checkAmount(ResType tp,int amout)
    {
        var rate = Rinstance.ResQList .Find((x) => { return x.ty == tp; });
        return rate.CurrentAmount > amout;
    }
    public void addProduct(ResType tp, int amout,int quans)
    {
        var rate = Rinstance.ResQList.Find((x) => { return x.ty == tp; });
        
        rate.Product   += amout*quans;
       
       

    }
    public void addAmount(ResType tp, int amout, int quans)
    {
        var rate = Rinstance.ResQList.Find((x) => { return x.ty == tp; });

       
        rate.CurrentAmount += amout * quans;


    }
    private void refreshScreen()
    {
        foreach (ResType type in Enum.GetValues(typeof(ResType)))//restype
        {
            //  Rinstance.ResQList[(int)type].CurrentAmount -= (Rinstance.ResQList[(int)type].Product  );
            int te = (int)type + 1;
            Text text = GameObject.Find("Canvas/Text (" + te + ")").GetComponent<Text>();
           
            text.text = Rinstance.ResQList[(int)type].CurrentAmount.ToString();
            int pe = (te) * 10 + 1;
            // to be optimised
            if (pe != 51)
            {
                Text text2 = GameObject.Find("Canvas/Text (" + pe + ")").GetComponent<Text>();
                text2.text = Rinstance.ResQList[(int)type].Product.ToString();
            }
        }
    }

}

 
