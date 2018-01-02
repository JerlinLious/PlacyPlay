using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceType
{
    Wood,
    Stone,
    Iron,
    IronEnhaced,
    Wheat,
    Leather,
    Bread
}
public class Resource
{
    public ResourceType RourceName { get; set; }
    public int ResourceQuantity { get; set; }
    

}

public class ResourceData : MonoBehaviour
{
   


    private ResourceData() { }
    public static readonly ResourceData instance = new ResourceData();

    public List<Resource> Resour = new List<Resource>();

    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
    // Use this for initialization
    void Start () {
        // initialize resource
        foreach(ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            Resource temp = new Resource();
            temp.RourceName = type;
            temp.ResourceQuantity = 0;
            instance. Resour.Add(temp);
        }
        sourceUpdate();


    }

    // Update is called once per frame
    int t;
	void Update () {

        // sourceUpdate();
        // Invoke(sourceUpdate, 10.0f);
        // StartCoroutine(ResourceData.DelayToInvokeDo(() =>  {   sourceUpdate(); }, 3.0f));
        t++;
        if (t % 180 == 0)
        {
            sourceUpdate();
        }

    }
   
    void sourceUpdate()
    {
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            int te = (int)type;
            
            //print(AssignJob.instance.assign.AssignList.Count);
            AssignID temp = AssignJob.instance.assign.AssignList[te];
            Text text = GameObject.Find("Canvas/Source(" + te + ")/Text").GetComponent<Text>();
           

            var rate = temp.LevelDataList.Find((x) => { return x.Level == 0; });
            var rate2 = rate.Output.Find((x) => { return x.RourceName == (ResourceType)te; });
            instance.Resour[0].ResourceQuantity += (rate2.ResourceQuantity + 1) * (temp.Quantity + 1);

            text.text = (instance.Resour[0].ResourceQuantity ).ToString();
             
        }
    }
}
