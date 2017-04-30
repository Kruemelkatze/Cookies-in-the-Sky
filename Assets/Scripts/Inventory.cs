using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Flags
    public bool Crank = false;
    public bool Screw = false;
    public bool Cog = false;

    //UI GameObjects
    public GameObject CrankObj;
    public GameObject ScrewUiObj;
    public GameObject CogUiObj;

    // Use this for initialization
    void Start()
    {
        FetchObjects();
        UpdateInventoryVisibility();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDestroy()
    {
    }
    public void UpdateObject(GameObject obj, bool val)
    {
        string name = obj.name.Replace("UI", "");
        UpdateObject(name, val);
    }

    public void GiveObject(string name)
    {
        UpdateObject(name, true);
    }

    public void RemoveObject(string name)
    {
        UpdateObject(name, false);
    }

    public void UpdateObject(string name, bool val)
    {

        switch (name)
        {
            case "Crank": Crank = val; break;
            case "Screw": Screw = val; break;
            case "Cog": Cog = val; break;
        }

        UpdateInventoryVisibility();
    }

    private bool IsInventoryFull()
    {
        return Crank && Screw && Cog;
    }

    public void FetchObjects()
    {
        CrankObj = GameObject.Find("CrankUI");
        ScrewUiObj = GameObject.Find("ScrewUI");
        CogUiObj = GameObject.Find("CogUI");
    }

    public void UpdateInventoryVisibility()
    {
        CrankObj.SetActive(Crank);
        ScrewUiObj.SetActive(Screw);
        CogUiObj.SetActive(Cog);
    }
}
