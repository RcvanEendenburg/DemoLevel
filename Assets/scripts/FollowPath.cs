using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour {

    private NavMeshAgent agent;

    public Transform path;

    private int index = 0;
    private Transform curClosestPoint;
    private Array navigationPoints;
    private bool whistle = false;

    private Vector3 tempGoal;





    void Start() {
        agent = GetComponent<NavMeshAgent>();
        navigationPoints = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++) {
            navigationPoints.SetValue(path.GetChild(i).transform, i);
        }

    }

	void Update () {
        moveThroughtNavigationPoints();        
    }

public void interruptPosCall(RaycastHit hit)
{
    tempGoal = hit.point;
    whistle = true;
}

private void moveThroughtNavigationPoints() {
    if(!whistle)
    {
        Vector3 curNavPoint = path.GetChild(index).position;
        agent.destination = curNavPoint;

        Vector3 tempAgentPosition = new Vector3(agent.transform.position.x, path.position.y, agent.transform.position.z);
        if (Vector3.Distance(curNavPoint, tempAgentPosition) < 0.2f) {
            if (++index >= path.childCount) {
                index = 0;
            }
        }
    }
        if(whistle)
        {
            agent.destination = tempGoal;
            Vector3 tempAgentPosition = new Vector3(agent.transform.position.x, path.position.y, agent.transform.position.z);
            if (Vector3.Distance(tempGoal, tempAgentPosition) < 0.2f) {
                whistle = false;
        }
        }
    }



}

