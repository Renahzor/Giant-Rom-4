using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseButton : MonoBehaviour {

	public void LoseGame()
    {
        GameMaster.Instance.ResetGame();
    }
}
