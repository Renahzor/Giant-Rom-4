using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNode : MonoBehaviour{

    public int speed = 2;

	public void MoveToGameObject(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
