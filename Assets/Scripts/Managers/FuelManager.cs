using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Holds a list of fuel game object
/// Reactivates on "Restart Race"
/// </summary>
public class FuelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> fuelList;

    void OnEnable()
    {
        EventManager.I.SubscribeEvent(Helper.RESTART_RACE, reactivateFuelObjects);
    }
    void OnDisable()
    {
        EventManager.I.UnsubscribeEvent(Helper.RESTART_RACE, reactivateFuelObjects);
    }
    void Start()
    {
        fuelList = new List<GameObject>();
        fuelList = GameObject.FindGameObjectsWithTag(Helper.FUEL).ToList();
    }
    void reactivateFuelObjects()
    {
        for (int i = 0; i < fuelList.Count; i++)
        {
            if (!fuelList[i].activeSelf)
                fuelList[i].SetActive(true);
        }
    }
}
