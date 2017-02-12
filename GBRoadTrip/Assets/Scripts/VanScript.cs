using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanScript : MonoBehaviour {

    public GameObject currentNode = null;
    GameObject previousNode = null;

    public Material lineMaterial;

    public bool moving = true;
    public bool inEvent = false;

    void Awake()
    {
        currentNode = GameObject.Find("San Francisco");
    }

    void Start()
    {
        UpdateNode();
    }

    void SetupLine(LineRenderer line)
    {
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = lineMaterial;
    }

    public void MoveStart(GameObject target)
    {
        if(!moving)
            StartCoroutine(MoveTo(target));
    }

    IEnumerator MoveTo(GameObject target)
    {
        previousNode = currentNode;

        MoveToNode move = GetComponent<MoveToNode>();
        moving = true;

        Vector3 targetPosition = target.transform.position;
        targetPosition.z = 0;

        int happinessChange = (int)Vector3.Distance(transform.position, targetPosition);

        while (Vector3.Distance(transform.position, targetPosition) >= 0.05f)
        {
            if (moving)
            {
                move.MoveToGameObject(targetPosition);
                GameMaster.Instance.travelTime += Time.deltaTime;
            }
            yield return null;
        }
        moving = false;

        GameMaster.Instance.foodStored -= (happinessChange * GameMaster.Instance.activeDuders.Count);

        if (GameMaster.Instance.foodStored < 0)
        {
            happinessChange = -(GameMaster.Instance.foodStored / 3);
            GameMaster.Instance.foodStored = 0;
        }

        else
            happinessChange = 0;

        foreach (GameObject duder in GameMaster.Instance.activeDuders)
        {
            duder.GetComponent<DuderScript>().ChangeHappiness(-happinessChange);
        }

        currentNode = target;
        ClearLines();
        UpdateNode();
        GameMaster.Instance.locationText.text = currentNode.GetComponent<MapNode>().nodeName;
        GameMaster.Instance.UpdateDudertext();
        GameMaster.Instance.StartCityEvent(currentNode.GetComponent<MapNode>());
    }

    void UpdateNode()
    {
        foreach (GameObject node in currentNode.GetComponent<MapNode>().connectedNodes)
        {
            LineRenderer line = node.gameObject.GetComponent<LineRenderer>();
            if(line == null)
                 line = node.gameObject.AddComponent<LineRenderer>();
            line.SetPosition(0, currentNode.transform.position);
            line.SetPosition(1, node.transform.position);
            SetupLine(line);
        }
    }

    void ClearLines()
    {
        foreach (GameObject node in previousNode.GetComponent<MapNode>().connectedNodes)
        {
            if (!currentNode.GetComponent<MapNode>().connectedNodes.Contains(node))
                Destroy(node.GetComponent<LineRenderer>());
        }
    }
}
