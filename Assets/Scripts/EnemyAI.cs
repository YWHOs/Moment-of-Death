using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange;

    NavMeshAgent naveMeshAgent;
    float distanceTarget = Mathf.Infinity;
    bool isAngry;

    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTarget = Vector3.Distance(target.position, transform.position);

        if (isAngry)
        {
            EngageTarget();
        }
        else if (distanceTarget <= chaseRange)
        {
            isAngry = true;

        }
    }

    void EngageTarget()
    {
        // Chase
        if (distanceTarget >= naveMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetTrigger("Move");
            naveMeshAgent.SetDestination(target.position);
        }
        if(distanceTarget <= naveMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}