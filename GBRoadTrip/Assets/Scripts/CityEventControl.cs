using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityEventControl : MonoBehaviour {

    public static CityEventControl Instance;

    public Text eventName;
    public Text eventDesc;

    public Button staffButtonPrefab;
    public GameObject staffButtonParent;
    public GameObject tempFinsishButton;
    List<Button> staffButtonList = new List<Button>();
    public Button acceptButton;
    public Button rejectButton;
    bool initialEvent;

    void Awake ()
    {
        Instance = this;
        Time.timeScale = 1;
    }

	// Use this for initialization
	void Start () {
        initialEvent = true;
        SetupEvent(GameMaster.Instance.partyVan.GetComponent<VanScript>().currentNode.GetComponent<MapNode>().cityEventName, GameMaster.Instance.partyVan.GetComponent<VanScript>().currentNode.GetComponent<MapNode>().eventDescription, null, null);
        AddStaffButtons();
        acceptButton.gameObject.SetActive(false);
        rejectButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetupEvent(string cityEventName, string cityEventDescription, string buttonTextAccept, string buttonTextReject)
    {
        GameMaster.Instance.partyVan.inEvent = true;
        eventName.text = cityEventName;
        eventDesc.text = cityEventDescription;
        acceptButton.GetComponentInChildren<Text>().text = buttonTextAccept;
        rejectButton.GetComponentInChildren<Text>().text = buttonTextReject;
    }

    void AddStaffButtons()
    {
        foreach (GameObject duder in GameMaster.Instance.duderPrefabs)
        {
            var newButton = Instantiate(staffButtonPrefab);
            newButton.transform.SetParent(staffButtonParent.transform);
            newButton.GetComponent<StaffButtonScript>().staffName = duder.GetComponent<DuderScript>().duderName;
            newButton.GetComponentInChildren<Text>().text = duder.GetComponent<DuderScript>().duderName;
            newButton.GetComponent<Image>().sprite = duder.GetComponent<DuderScript>().mySprite;
            staffButtonList.Add(newButton);
        }
    }
    
    public void FinishEvent(bool acceptEvent)
    {
        if (GameMaster.Instance.activeDuders.Count >= 3 && initialEvent)
        {
            foreach (Button b in staffButtonList)
            {
                Destroy(b.gameObject);
            }
            initialEvent = false;
            Destroy(tempFinsishButton);
            acceptButton.gameObject.SetActive(true);
            rejectButton.gameObject.SetActive(true);
            GameMaster.Instance.initialSetupComplete = true;
        }

        if (acceptEvent)
        {
            GameMaster.Instance.partyVan.GetComponent<VanScript>().currentNode.GetComponent<MapNode>().ResolveCityEvent();
        }

        GameMaster.Instance.partyVan.inEvent = false;
        GameMaster.Instance.SetStorePanel(false);
        gameObject.SetActive(false);
    }


}
