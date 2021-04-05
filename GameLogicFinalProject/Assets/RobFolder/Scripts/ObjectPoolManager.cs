using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public GameObject cheesePickUp;
    public GameObject smallBatteryPickUp;
    public GameObject largeBatteryPickUp;
    public GameObject ratTrap;

    public int numOfSmallBatteriesToMake;
    public int numOfLargeBatteriesToMake;
    public int numOfCheeseToMake;
    public int numOfRatTrapsToMake;

    public List<GameObject> allSmallBatteriesCreated = new List<GameObject>();
    public List<GameObject> allLargeBatteriesCreated = new List<GameObject>();
    public List<GameObject> allCheeseCreated = new List<GameObject>();
    public List<GameObject> allRatTrapsCreated = new List<GameObject>();

    private void Awake()
    {
        for(int i = 0; i < numOfCheeseToMake; i++)
        {
            CreateObject(cheesePickUp, allCheeseCreated);
        }
        for(int i = 0; i < numOfSmallBatteriesToMake; i++)
        {
            CreateObject(smallBatteryPickUp, allSmallBatteriesCreated);
        }
        for(int i = 0; i < numOfLargeBatteriesToMake; i++)
        {
            CreateObject(largeBatteryPickUp, allLargeBatteriesCreated);
        }
        for(int i = 0; i < numOfRatTrapsToMake; i++)
        {
            CreateObject(ratTrap, allRatTrapsCreated);
        }
    }
    public GameObject CreateObject(GameObject prefab, List<GameObject> list)
    {
        GameObject go = Instantiate(prefab);
        go.SetActive(false);
        list.Add(go);
        return go;
    }

    public GameObject GetObject(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                return list[i];
            }
        }
        return null;
    }
}
