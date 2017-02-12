using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour {

    public string nodeName;

    List<ActivityScript> activities = new List<ActivityScript>();

    public List<GameObject> connectedNodes = new List<GameObject>();

    public string eventDescription, cityEventName, buttonAcceptText, buttonRejectText;

    public int happinessRewardMin, happinessRewardMax, cashRewardMin, cashrewardMax, foodRewardMin, foodRewardMax;

    public void ResolveCityEvent()
    {
        GameMaster.Instance.partyMoney += UnityEngine.Random.Range(cashRewardMin, cashrewardMax);
        GameMaster.Instance.foodStored += UnityEngine.Random.Range(foodRewardMin, foodRewardMax);

        foreach (GameObject duder in GameMaster.Instance.activeDuders)
        {
            duder.GetComponent<DuderScript>().ChangeHappiness(UnityEngine.Random.Range(happinessRewardMin, happinessRewardMax));
        }
    }

}
