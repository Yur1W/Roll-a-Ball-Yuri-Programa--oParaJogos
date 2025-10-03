using Mono.Cecil.Cil;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    [SerializeField]
    public float enemySpeed = 1f;

    [SerializeField]
    public float killDistance = 2f;

    void Start()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        Debug.LogFormat("I am a new enemy ({0}). Distance to player:: {1}", name, playerDistance);
    }

    // Approach the player and if they are within a given distance, "kill" them
    private void Update()
    {
        if (player == null)
        {
             Debug.Log("player null");
            return;
        }
           
            
        Vector3 playerVector = player.transform.position - transform.position;

        // A-Option 1: Move by hand
        Vector3 speedDirection = playerVector.normalized;
        transform.position += speedDirection * enemySpeed * Time.deltaTime;

        // A-Option 2: MoveTowards
        //transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        
        // B-Option 1: sqrMagnitude
        if (playerVector.sqrMagnitude < (killDistance * killDistance))
        // B-Option 2: Vector3.Distance
        //if (Vector3.Distance(transform.position, player.position) < killDistance)
        {
            Debug.Log("I caught up with the enemy :)");
            Destroy(player.gameObject);
        }
    }
}
