using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    

    [SerializeField] float chaseRange = 15f; //how far from the nemy target can be before triggering chase

    [SerializeField] float roationSpeed = 5f;

    Transform target; //the target will be who the enemy will go after
    
    NavMeshAgent navMeshAgent;
    float attackRange; //how far from the nemy target can be before triggering chase

    float distanceToTraget = Mathf.Infinity;

    bool isProvoked = false;
    bool isDead = false;

    Animator enemyAnimator;
    EnemyHealth enemyHealth;

    private void Awake() 
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start() 
    {
        attackRange = navMeshAgent.stoppingDistance;
        enemyHealth.OnDamageTaken += Provoke;
        enemyHealth.OnDeath += Die;
    }

    private void Update() 
    {
        SetDestination();
        
    }

    public void Provoke()
    {
        if(!isDead)
        {
            isProvoked = true;
        }
        
    }

    private void SetDestination()
    {
        
        distanceToTraget = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distanceToTraget);
        if(isDead)
        {
            navMeshAgent.enabled = false;
            enabled = false;
        }
        if(isProvoked)
        {
            EngageTarget();
            RotateToTarget();
        }
        else if(distanceToTraget <= chaseRange && !isDead)
        {
            isProvoked = true;
        }
        else
        {
            isProvoked = false;
            enemyAnimator.SetBool("isAttacking", false);
            enemyAnimator.ResetTrigger("Move");
        }

    }

    private void EngageTarget()
    {
        

        if(distanceToTraget > attackRange) //chase target if not within attack range
        {
            ChaseTarget();
        }
        else if(distanceToTraget <= attackRange) //attack if within attack range
        {
            AttackTarget();
            return;
        }

        enemyAnimator.SetBool("isAttacking", false);
        
    }

    void ChaseTarget()
    {
        //Debug.Log("enemy is moving");
        enemyAnimator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
        
    }

    void AttackTarget()
    {
        //Debug.Log("attacking");
        enemyAnimator.SetBool("isAttacking", true);
    }

    void Die()
    {
        if(isDead)
        {
            return;
        }
        enemyAnimator.SetTrigger("Die");
        isProvoked = false;
        isDead = true;
    }


    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * roationSpeed);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = new Color(0.25f,1,0,1);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, GetComponent<NavMeshAgent>().stoppingDistance);
            
    }

    
}
