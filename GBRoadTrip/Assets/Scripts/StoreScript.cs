using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

    public int foodCost;
    [SerializeField]
    Text foodButtonText;

    void Start()
    {
        SetupStore();
    }

    public void PurchaseFood()
    {
        if (GameMaster.Instance.partyMoney < foodCost)
            return;

        GameMaster.Instance.partyMoney -= foodCost;
        GameMaster.Instance.foodStored += 5;
    }

    public void SetupStore()
    {
        foodCost = Random.Range(100, 250);
        foodButtonText.text = "5 food for $" + foodCost;
    }
}
