using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEnemyBehavior : MonoBehaviour
{
    public float moveRange;
    public float attackRange;
    public float moveDuration;

    private GameObject player;
    private GameObject myBody;

    private bool playerClose;
    private bool isMoving;
    private Vector3 targetPosition;

    private float moveTimer = 0f;
    private float pauseTimer = 0f;
    private bool delayComplete = false;
    private bool pauseComplete = false;

    private DCharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = GetComponent<DCharacterController>();
        myBody = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Vector2.Distance(player.transform.position, transform.position) < 50f)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < attackRange)
                playerClose = true;
            else
                playerClose = false;

            behaviorTick();
        }
    }

    public Vector3 GenerateRandomPosition()
    {
        // Generate random offsets in each axis within the specified range
        float offsetX = Random.Range(-moveRange, moveRange);
        float offsetY = Random.Range(-moveRange, moveRange);

        // Calculate the random position relative to the center
        Vector3 randomPosition = transform.position + new Vector3(offsetX, offsetY);
        return randomPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            targetPosition = GenerateRandomPosition();
    }

    public void behaviorTick()
    {
        if(!isMoving)
        {
            if(playerClose)
            {
                // Calculate the direction from this object to the target object
                Vector3 direction = player.transform.position - myBody.transform.position;

                // Calculate the angle in degrees
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                angle -= 90f;

                // Set the rotation of the sprite to face the target object
                myBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                cc.ExecuteCommand(new ShootCommand(false));
            }
            
            
            if (pauseComplete)
            {
                if (pauseTimer >= 1f)
                {
                    targetPosition = GenerateRandomPosition();
                    pauseTimer = 0f;
                    moveTimer = 0f;
                        
                    isMoving = true;
                }
                else
                {
                    pauseComplete = false;
                }
            }
            else
            {
                pauseTimer += Time.deltaTime;
                if(pauseTimer >= 1f)
                {
                    pauseComplete = true;
                }
            }
            
        }
        else
        {
            if(moveTimer >= moveDuration)
            {
                cc.ExecuteCommand(new MoveCommand(Vector3.zero, targetPosition));
                isMoving = false;
            }
            else
            {
                cc.ExecuteCommand(new MoveCommand(Vector3.Normalize(this.transform.position - targetPosition), targetPosition));
                moveTimer += Time.deltaTime;
            }
        }
    }
}
