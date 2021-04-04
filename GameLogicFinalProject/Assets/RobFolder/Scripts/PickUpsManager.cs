using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsManager : Singleton<PickUpsManager>
{
    public List<PickUpController> allPickUpTypes = new List<PickUpController>();

    public List<Transform> areaOneBatteryLocations = new List<Transform>();
    public List<Transform> areaTwoBatteryLocations = new List<Transform>();
    public List<Transform> areaThreeBatteryLocations = new List<Transform>();

    public List<Transform> areaOneCheeseLocations = new List<Transform>();
    public List<Transform> areaTwoCheeseLocations = new List<Transform>();
    public List<Transform> areaThreeCheeseLocations = new List<Transform>();

    public List<Transform> areaOneRatTrapLocations = new List<Transform>();
    public List<Transform> areaTwoRatTrapLocations = new List<Transform>();
    public List<Transform> areaThreeRatTrapLocations = new List<Transform>();

    private void Start()
    {
        // Populate the first area with pick ups and traps
        PopulateNewAreaPickUps(areaOneBatteryLocations, ObjectPoolManager.Instance.allSmallBatteriesCreated);
        PopulateNewAreaPickUps(areaOneRatTrapLocations, ObjectPoolManager.Instance.allRatTrapsCreated);
        PopulateNewAreaPickUps(areaOneCheeseLocations, ObjectPoolManager.Instance.allCheeseCreated);
    }

    //Checks to see if any pick ups and traps are active and turns them off if they are
    public void RemovePreviousAreaPickUps(List<GameObject> objectList)
    {
        foreach (GameObject pickup in objectList)
        {
            if (pickup.activeInHierarchy)
            {
                pickup.SetActive(false);
            }
        }
    }

    //Populates the new area with pick ups and traps
    public void PopulateNewAreaPickUps(List<Transform> areaList, List<GameObject> objectlist)
    {
        foreach (Transform pickup in areaList)
        {
            Transform newPickup = ObjectPoolManager.Instance.GetObject(objectlist).transform;
            newPickup.transform.position = pickup.transform.position;
            newPickup.gameObject.SetActive(true);
        }
    }

}
