using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private NavMeshAgent[] navAgents;
    public Transform targetMarker;

    void Start()
    {
        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
    }

    void UpdateTargets (Vector3 targetPos)
    {
        foreach (NavMeshAgent agent in navAgents)
        {
            agent.destination = targetPos;
        }
    }

    void Update()
    {
        int button = 0;
        if (Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray.origin, ray.direction,out hitInfo))
            {
                Vector3 targetPos = hitInfo.point;
                UpdateTargets(targetPos);
                targetMarker.position = targetPos + new Vector3(0, 5, 0);
            }
        }
    }
}
