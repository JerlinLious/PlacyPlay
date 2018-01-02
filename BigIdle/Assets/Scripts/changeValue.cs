using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Add()

    {
      
        transform.parent.GetComponentInChildren<Quantity>().selfIncrease();

    }
    public void Remove()
    {
        //GameObject.Find("Quantity").GetComponent<Quantity>().selfDecrease();
        transform.parent.GetComponentInChildren<Quantity>().selfDecrease();
    }
}

