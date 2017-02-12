using UnityEngine;

public class DuderScript : MonoBehaviour {

    public string duderName;
    public int happiness, foodUse;
    public string specialAbilityname;
    public Sprite mySprite;

    void Awake()
    {
        happiness = 10;
        foodUse = 1;
    }

    public void ChangeHappiness(int delta)
    {
        happiness += delta;
    }

}
