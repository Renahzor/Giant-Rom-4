using UnityEngine;

public class RandomEventScript {

    public enum RewardTypes { None, Happiness, Food, Money, Internet }

    public string eventName { get; private set; }
    public string eventDescription { get; private set; }
    public int happinessChange { get; private set; }
    public int eventCost { get; private set; }
    public int foodCost { get; private set; }
    public string duderFixer { get; private set; }
    public string duderImmune { get; private set; }
    public string buttonOneText { get; private set; }
    public string buttonTwoText { get; private set; }
    public string buttonThreeText { get; private set; }
    public bool eventHasStore { get; private set; }
    RewardTypes rewardType = RewardTypes.None;
    int rewardQuantity = 0;
    int rewardIndex;

    public RandomEventScript(string name, string description, string buttonOne, string buttonTwo, string buttonThree, int happiness, int cost, int food, string duderCanAvoid, string immuneDuder, bool hasStore, RewardTypes reward, int rewardQty, int rewardButtonIndex)
    {
        eventName = name;
        eventDescription = description;
        happinessChange = happiness;
        eventCost = cost;
        duderFixer = duderCanAvoid;
        duderImmune = immuneDuder;
        eventHasStore = hasStore;
        rewardType = reward;
        rewardQuantity = rewardQty;
        foodCost = food;

        buttonOneText = buttonOne;
        buttonTwoText = buttonTwo;
        buttonThreeText = buttonThree;
        rewardIndex = rewardButtonIndex;
    }

    public void ExecuteReward(int buttonIndexSelected)
    {
        switch (rewardType)
        {
            case RewardTypes.None:
                {
                    break;
                }
            case RewardTypes.Happiness:
                {
                    if (buttonIndexSelected == 1)
                    {
                        foreach(GameObject duder in GameMaster.Instance.activeDuders)
                        {
                            duder.GetComponent<DuderScript>().happiness += rewardQuantity;
                        }
                    }
                    break;
                }
            case RewardTypes.Money:
                {
                    if (buttonIndexSelected == 2)
                    {
                        GameMaster.Instance.partyMoney += rewardQuantity;
                    }
                    break;
                }
            case RewardTypes.Food:
                {
                    if (buttonIndexSelected == 3)
                    {
                        GameMaster.Instance.foodStored += rewardQuantity;
                    }
                    break;
                }
            default: break;
        }
    }
}
