using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static GameMaster Instance;

    int vanStorage = 25;
    int internetStored, partsStored;

    public int foodStored = 10;
    public int partyMoney = 1500;

    int initialCapacity = 3;
    int maxCapacity = 6;

    public float travelTime= 0.0f;
    float randomEventTime;
    RandomEventScript currentRandomEvent = null;
    RandomEventController eventController;

    public VanScript partyVan;

    public Text locationText;

    public List<GameObject> activeDuders = new List<GameObject>();

    public List<GameObject> duderPrefabs = new List<GameObject>();
    public GameObject duderPanelPrefab;
    public GameObject duderPanelParent;

    List<GameObject> duderPanels = new List<GameObject>();

    public GameObject encounterWindow;
    public GameObject encounterButtonPrefab;
    public GameObject encounterButtonParent;
    public GameObject encounterBonusPanel;

    public GameObject loseScreen;
    public bool initialSetupComplete = false;

    public GameObject winScreen;

    [SerializeField]
    Text moneyText;
    [SerializeField]
    Text foodText;

    [SerializeField]
    GameObject storePanel;
    [SerializeField]
    GameObject storeButton;

    [SerializeField]
    GameObject cityEventPanel;

    void Awake()
    {
        Instance = this;
        eventController = GetComponent<RandomEventController>();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

	// Use this for initialization
	void Start () {

        randomEventTime = Random.Range(1.5f, 4.0f);

        locationText.text = "San Francisco, CA";

        storeButton.SetActive(false);
        storePanel.SetActive(true);
        encounterWindow.SetActive(false);
        encounterBonusPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.transform.tag == "MapNode" && partyVan.currentNode.GetComponent<MapNode>().connectedNodes.Contains(hit.transform.gameObject) && !partyVan.inEvent)
            {
                partyVan.MoveStart(hit.transform.gameObject);
            }
        }

        CheckRandomEncounter();
        UpdateDudertext();

        foodText.text = "Food: " + foodStored;
        moneyText.text = "Cash: $" + partyMoney;


        int duderDestroyIndex = -1;
        for (int i = 0; i < activeDuders.Count; i++)
        {
            if (activeDuders[i].GetComponent<DuderScript>().happiness <= 0)
            {
                Debug.Log(activeDuders[i].GetComponent<DuderScript>().duderName + " has gone home!");
                duderDestroyIndex = i;
            }
        }

        if (duderDestroyIndex != -1)
        {
            RemoveDuder(duderDestroyIndex);
        }

        if ( (activeDuders.Count == 0 || partyMoney < 0) && initialSetupComplete)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }

        if (partyVan.GetComponent<VanScript>().currentNode.GetComponent<MapNode>().nodeName == "New York, NY")
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }

    public void ResetGame()
    {
        Application.LoadLevel("MainMap");
    }


    public void RemoveDuder(int indexToDestroy)
    {
        Destroy(duderPanels[indexToDestroy]);
        duderPanels.Remove(duderPanels[indexToDestroy]);
        activeDuders.Remove(activeDuders[indexToDestroy]);
    }
    public void toggleStorePanel()
    {
        storePanel.SetActive(!storePanel.activeSelf);
    }

    public void SetStorePanel(bool open)
    {
        storePanel.SetActive(open);
    }

    public void UpdateDudertext()
    {
        for (int i = 0; i < duderPanels.Count; i++)
        {
            duderPanels[i].transform.FindChild("StaffName").GetComponent<Text>().text = activeDuders[i].GetComponent<DuderScript>().duderName;
            duderPanels[i].transform.FindChild("Happiness").GetComponent<Text>().text = "Happiness: " + activeDuders[i].GetComponent<DuderScript>().happiness.ToString();
        }
    }

    public void CheckRandomEncounter()
    {
        if (travelTime >= randomEventTime)
        {
            //do random event
            currentRandomEvent = eventController.randomEvents[Random.Range(0, eventController.randomEvents.Count)];
            partyVan.inEvent = true;
            partyVan.moving = false;
            Debug.Log("Random Event Happened");

            SetupEncounterWindow();

            travelTime = 0.0f;
            randomEventTime = Random.Range(1.5f, 4.0f);
        }
    }

    void SetupEncounterWindow()
    {
        if (currentRandomEvent.eventHasStore)
        {
            storeButton.SetActive(true);
            storePanel.GetComponent<StoreScript>().SetupStore();
        }

        encounterWindow.transform.FindChild("EventName").GetComponent<Text>().text = currentRandomEvent.eventName;
        encounterWindow.transform.Find("EventDescription").transform.FindChild("EventDescText").GetComponent<Text>().text = currentRandomEvent.eventDescription;

        if (currentRandomEvent.happinessChange != 0)
        {
            var myButton = Instantiate(encounterButtonPrefab);
            myButton.GetComponent<Button>().onClick.AddListener(() => ResolveRandomEncounter(0));
            myButton.transform.Find("Text").GetComponent<Text>().text = currentRandomEvent.buttonOneText;
            myButton.transform.SetParent(encounterButtonParent.transform, false);
        }

        if (currentRandomEvent.eventCost != 0)
        {
            var myButton = Instantiate(encounterButtonPrefab);
            myButton.GetComponent<Button>().onClick.AddListener(() => ResolveRandomEncounter(1));
            myButton.transform.Find("Text").GetComponent<Text>().text = currentRandomEvent.buttonTwoText;
            myButton.transform.SetParent(encounterButtonParent.transform, false);
        }

        if (currentRandomEvent.foodCost != 0)
        {
            var myButton = Instantiate(encounterButtonPrefab);
            myButton.GetComponent<Button>().onClick.AddListener(() => ResolveRandomEncounter(2));
            myButton.transform.Find("Text").GetComponent<Text>().text = currentRandomEvent.buttonThreeText;
            myButton.transform.SetParent(encounterButtonParent.transform, false);
        }

        if (currentRandomEvent.duderFixer != "None")
        {
            //setup bonus pane
            DuderScript fixer = null;

            foreach (GameObject duder in activeDuders)
            {
                if (duder.GetComponent<DuderScript>().duderName == currentRandomEvent.duderFixer)
                {
                    fixer = duder.GetComponent<DuderScript>();
                }
            }

            if (fixer != null)
            {
                encounterBonusPanel.transform.FindChild("Text").GetComponent<Text>().text = "Due to " + fixer.duderName + "'s special ability '" + fixer.specialAbilityname + "' you may bypass this encounter";
                encounterBonusPanel.transform.FindChild("DuderImage").GetComponent<Image>().sprite = fixer.GetComponent<DuderScript>().mySprite;
                encounterBonusPanel.SetActive(true);
            }
        }

        encounterWindow.SetActive(true);
    }

    public void ResolveRandomEncounter(int resolveType)
    {
        switch (resolveType)
        {
            case 0:
                {
                    foreach (GameObject duder in activeDuders)
                    {
                        if (duder.GetComponent<DuderScript>().duderName != currentRandomEvent.duderImmune)
                            duder.GetComponent<DuderScript>().happiness += currentRandomEvent.happinessChange;
                    }
                    currentRandomEvent.ExecuteReward(1);
                    break;
                }
            case 1:
                {
                    partyMoney += currentRandomEvent.eventCost;
                    currentRandomEvent.ExecuteReward(2);
                    break;
                }
            case 2:
                {
                    foodStored += currentRandomEvent.foodCost;
                    currentRandomEvent.ExecuteReward(3);
                    break;
                }
            case 999:
                {
                    break;
                }
            default: break;
        }

        partyVan.inEvent = false;
        partyVan.moving = true;
        currentRandomEvent = null;
        storeButton.SetActive(false);
        UpdateDudertext();

        encounterWindow.SetActive(false);
        encounterBonusPanel.SetActive(false);

        List<GameObject> childrenToDestroy = new List<GameObject>();
        foreach (Transform child in encounterButtonParent.transform)
            childrenToDestroy.Add(child.gameObject);
        foreach (GameObject child in childrenToDestroy)
            Destroy(child);

        return;
    }

    public void AddStaff(string staffName)
    {
        if (activeDuders.Count >= 3)
            return;

        foreach (GameObject duder in duderPrefabs)
        {
            if (duder.GetComponent<DuderScript>().duderName == staffName)
            {
                activeDuders.Add(Instantiate(duder));

                var newPanel = Instantiate(duderPanelPrefab);

                newPanel.transform.FindChild("StaffName").GetComponent<Text>().text = duder.GetComponent<DuderScript>().duderName;
                newPanel.transform.FindChild("Happiness").GetComponent<Text>().text = "Happiness: " + duder.GetComponent<DuderScript>().happiness.ToString();

                newPanel.transform.SetParent(duderPanelParent.transform, false);

                newPanel.GetComponent<Image>().sprite = duder.GetComponent<DuderScript>().mySprite;

                duderPanels.Add(newPanel);

                duderPrefabs.Remove(duder);

                return;
            }
        }
    }

    public void StartCityEvent(MapNode currentNode)
    {
        cityEventPanel.GetComponent<CityEventControl>().SetupEvent(currentNode.cityEventName, currentNode.eventDescription, currentNode.buttonAcceptText, currentNode.buttonRejectText);
        cityEventPanel.SetActive(true);
    }
}
