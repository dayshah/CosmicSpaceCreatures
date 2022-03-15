using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AICreatureScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator anim;
    public GameObject[] route1;
    public GameObject[] route2;

    public GameObject player;

    public int route1JunctionIndex;
    public int route2JunctionIndex;

    private int currWaypoint;

    private VelocityReporter velReporter;

    private bool isTired;
    public float restTime;
    private float startRestTime;

    //public GameObject movingWaypoint;
    //public GameObject destinationTracker;

    public enum AIState
    {
        Route1,
        Route2,
        Hiding
    }
    public AIState aiState;

    // Start is called before the first frame update
    void Start()
    {
        isTired = false;
        restTime = 1.0f;
        startRestTime = Time.unscaledTime;

        aiState = AIState.Route1;

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        //velReporter = movingWaypoint.GetComponent<VelocityReporter>();

        currWaypoint = 0;

        //InvokeRepeating("setNextWaypoint", 0.0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTired && Time.unscaledTime >= startRestTime + restTime)
        {
            isTired = false;
            anim.SetFloat("vely", 1);
            setNextWaypoint();
        }

        if (navMeshAgent.pathPending != true && navMeshAgent.remainingDistance < 1 && !isTired)
        {
            isTired = true;
            anim.SetFloat("vely", 0);
            startRestTime = Time.unscaledTime;
        }
        
        
        //transform.Translate(navMeshAgent.velocity.magnitude / navMeshAgent.speed);
    }

    private void setNextWaypoint()
    {
        if (aiState == AIState.Route1)
        {
            makeDecision(route1, route1JunctionIndex);
        }
        else if (aiState == AIState.Route2)
        {
            makeDecision(route2, route2JunctionIndex);
        }
    }

    private void makeDecision(GameObject[] currRoute, int currRouteJunctionIdx)
    {
        Debug.Log("Making Decision");

        int nextWaypointIdx = currWaypoint + 1;
        if (nextWaypointIdx >= currRoute.Length)
        {
            nextWaypointIdx = 0;
        }

        int prevWaypointIdx = currWaypoint - 1;
        if (prevWaypointIdx < 0)
        {
            prevWaypointIdx = currRoute.Length - 1;
        }

        GameObject nextWaypoint = currRoute[nextWaypointIdx];
        GameObject prevWaypoint = currRoute[prevWaypointIdx];
        GameObject otherRouteJunction = null;

        // If we are at a junction, find other route junction
        if (currWaypoint == currRouteJunctionIdx)
        {
            if (aiState == AIState.Route1)
            {
                otherRouteJunction = route2[route2JunctionIndex];
            } else if (aiState == AIState.Route2)
            {
                otherRouteJunction = route1[route2JunctionIndex];
            }
        }

        // Get Player Distances
        float nextWaypointDist = getDistance(player, nextWaypoint);
        float prevWaypointDist = getDistance(player, prevWaypoint);
        float otherRouteJunctionDist = -1.0f;

        if (otherRouteJunction != null)
        {
            otherRouteJunctionDist = getDistance(player, otherRouteJunction);
        }

        // Greatest Distance is the next one we go to

        // Not at Junction

        int whereTo = -1;
        float maxDist = -1;
 
        if (nextWaypointDist < 10)
        {
            if (nextWaypointDist < prevWaypointDist)
            {
                whereTo = prevWaypointIdx;
                maxDist = prevWaypointDist;
            }
            else
            {
                whereTo = nextWaypointIdx;
                maxDist = nextWaypointDist;
            }
        } else
        {
            whereTo = nextWaypointIdx;
        }
        

        currWaypoint = whereTo;

        if (otherRouteJunctionDist >= maxDist)
        {
            // Change Route
            if (aiState == AIState.Route1)
            {
                aiState = AIState.Route2;
                currWaypoint = route2JunctionIndex;
                if (route2.Length != 0)
                {
                    navMeshAgent.SetDestination(route2[currWaypoint].transform.position);
                }
            }
            else if (aiState == AIState.Route2)
            {
                aiState = AIState.Route1;
                currWaypoint = route1JunctionIndex;
                if (route1.Length != 0)
                {
                    navMeshAgent.SetDestination(route1[currWaypoint].transform.position);
                }
            }
        } else
        {
            if (currRoute.Length != 0)
            {
                navMeshAgent.SetDestination(currRoute[currWaypoint].transform.position);
            }
        }
    }

    private float getDistance(GameObject object1, GameObject object2)
    {
        Vector3 pos1 = object1.transform.position;
        //Debug.Log("pos1 position " + pos1);
        Vector3 pos2 = object2.transform.position;
        //Debug.Log("pos2 position " + pos2);

        return (pos1 - pos2).magnitude;
    }


    /*
    private void setWaypointLookahead()
    {
        Vector3 agentPosition = this.transform.position;
        Vector3 waypointPosition = movingWaypoint.transform.position;

        float maxSpeed = navMeshAgent.speed;
        float dist = (waypointPosition - agentPosition).magnitude;
        if (dist < 1)
        {
            currWaypoint = -1;
            setNextWaypoint();
            return;
        }
        float lookAheadTime = dist / maxSpeed;

        Vector3 futureTarget = waypointPosition + lookAheadTime * velReporter.velocity;
        bool checkNavMesh = UnityEngine.AI.NavMesh.Raycast(waypointPosition, futureTarget, out var hit, UnityEngine.AI.NavMesh.AllAreas);
        //bool checkNavMesh = true;
        if (!checkNavMesh)
        {
            navMeshAgent.SetDestination(futureTarget);
            //destinationTracker.GetComponent<DestinationTrackerScript>().setPosition(futureTarget);
        }

    }
    */
}
