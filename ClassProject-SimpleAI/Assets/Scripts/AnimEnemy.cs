using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimEnemy : MonoBehaviour
{
    [SerializeField]
    //private EnemyAIStates state = EnemyAIStates.Patrolling;
    static private List<GameObject> patrolPoints = null;

    #region Enemy Options
    public float walkingSpeed = 3.0f;
    public float chasingSpeed = 5.0f;
    public float attackingSpeed = 1.5f;
    public float attackingDistance = 1.0f;
    #endregion

    private GameObject patrollingInterestPoint;
    private GameObject playerOfInterest;

    public Animator enAnim;
    void Start()
    {
        enAnim = GetComponent<Animator>();
        playerOfInterest = GameObject.FindGameObjectWithTag("Player");

        if (patrolPoints == null)
        {
            patrolPoints = new List<GameObject>();
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("PatrolPoints"))
            {
                Debug.Log("Patrol Point: " + go.transform.position);
                patrolPoints.Add(go);
            }
        }
       // ChangeToPatrolling();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, playerOfInterest.transform.position);
        enAnim.SetFloat("PlayerDist", dist);

        switch (enAnim.GetInteger("AnimState"))
        {
            case 3:
                OnAttackingUpdate();
                break;
            case 2:
                OnChasingUpdate();
                break;
            case 1:
                OnPatrollingUpdate();
                break;
        }
    }

    void OnAttackingUpdate()
    {
        float step = attackingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerOfInterest.transform.position, step);

      /*  float distance = Vector3.Distance(transform.position, playerOfInterest.transform.position);
        if (distance > attackingDistance)
        {
            ChangeToChasing(playerOfInterest);
        }*/
    }

    void OnChasingUpdate()
    {
        float step = chasingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerOfInterest.transform.position, step);

        /*float distance = Vector3.Distance(transform.position, playerOfInterest.transform.position);
        if (distance <= attackingDistance)
        {
            ChangeToAttacking(playerOfInterest);
        }*/
    }

    void OnPatrollingUpdate()
    {
        float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, patrollingInterestPoint.transform.position, step);

        float distance = Vector3.Distance(transform.position, patrollingInterestPoint.transform.position);
        if (distance == 0)
        {
            SelectRandomPatrolPoint();
        }
    }

   /* void OnTriggerEnter(Collider collider)
    {
        ChangeToChasing(collider.gameObject);
    }

    void OnTriggerExit(Collider collider)
    {
        ChangeToPatrolling();
    }
    */
   public void ChangeToPatrolling()
    {
       // state = EnemyAIStates.Patrolling;
        GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f);
        SelectRandomPatrolPoint();
        //playerOfInterest = null;
    }

   public void ChangeToAttacking()
    {
       // state = EnemyAIStates.Attacking;
        GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
    }

   public void ChangeToChasing()
    {
       // state = EnemyAIStates.Chasing;
        GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f);
        //playerOfInterest = target;
    }

    void SelectRandomPatrolPoint()
    {
        int choice = Random.Range(0, patrolPoints.Count);
        patrollingInterestPoint = patrolPoints[choice];
       // Debug.Log("Enemy going to patrol to point " + patrollingInterestPoint.name);
    }
}
