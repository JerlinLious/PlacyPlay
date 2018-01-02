using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOLDBUTTON : MonoBehaviour {

	public  void addGold()
    {
        GameObject gold = GameObject.Find("GOLDNUM");
       string a=gold.GetComponent<Text>().text;
       
        int b;
        int.TryParse(a, out b);
       
        b++;
        a=b.ToString();
        gold.GetComponent<Text>().text = a;
    }
}
