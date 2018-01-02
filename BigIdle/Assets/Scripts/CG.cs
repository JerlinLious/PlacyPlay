using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CG : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
    public void Add()

    {
        Building bins = Building.Binstance;
        InputField  aas= transform.parent.GetComponentInChildren<InputField>();
      
       int tr= Convert.ToInt32(aas.name.Substring(12, 1));
        bins.addQuantity((BuildingType )tr);
        
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
