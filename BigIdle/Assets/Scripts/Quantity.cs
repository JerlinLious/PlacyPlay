using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quantity : MonoBehaviour {
    public Text self;
    private int quants;

	// Use this for initialization
	void Start () {
        quants = 5;
        //json read
	}
	
	// Update is called once per frame
	void Update () {

        // transform.parent.gameObject.GetComponentInParent<Longlidy>().self.text = quants.ToString();
        // GetComponentInParent<Longlidy>().self.text = quants.ToString();
        // transform.Find("Quantity"). text= quants.ToString();
        self.text = quants.ToString();

    }
   public void selfDecrease()
    {
        quants -= 1;
        if (quants < 0)
            quants = 0;
    }
    public void selfIncrease()
    {
        quants += 1;
    }
}
