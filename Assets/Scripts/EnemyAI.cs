using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange;
    [SerializeField] float rotateSpeed;

    NavMeshAgent naveMeshAgent;
    Transform target;
    float distanceTarget = Mathf.Infinity;
    bool isAngry;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.IsDead())
        {
            this.enabled = false;
            naveMeshAgent.enabled = false;
        }
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
        Rotate();
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

    public void TakeDamage()
    {
        isAngry = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void Rotate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}
