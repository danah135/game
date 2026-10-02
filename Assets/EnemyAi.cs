using UnityEngine;

public class EnemyAi : MonoBehaviour
{ public Transform player;
public float moveSpeed = 2f;
public float detectionRange = 2f;
public float attackRange=1.5f;
public float attackCooldown=2f;
public float attackTimer=0f;
private PlayerHealth playerHealth;
    public int attackDamage=10;
    void Start()
    {
        playerHealth=player.GetComponent<PlayerHealth>();
    }
 
enum State
    {
        Idle,
        Chasing,
        Attacking
      
    }
State currentState = State.Idle;
State previousState=State.Idle;
    void Update()
    {

float Distance=Vector2.Distance(player.position,transform.position);


       if (Distance <= attackRange)
            {
              
               currentState = State.Attacking;

            }  else if(Distance<=detectionRange)
{currentState = State.Chasing;
      
           
    }else{
        currentState = State.Idle;}
if(currentState!=previousState)
        {  if(currentState==State.Attacking)
            {
                attackTimer=0f;
            }
            Debug.Log("State changed from "+previousState+" to "+currentState);
            previousState=currentState;
          
        }
        switch(currentState)
        {
            case State.Idle:
               
                break;
            case State.Chasing:
                Vector2 direction=player.position-transform.position;
        direction=direction.normalized;
      transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;    
                break;
            case State.Attacking:
               attackTimer += Time.deltaTime;
               if(attackTimer>=attackCooldown)
                {
                    playerHealth.TakeDamage(attackDamage);
                    attackTimer = 0f;
                } 
                break;
        }
    }
}
