using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public PlayerController playerController;
    public GameController gameController;

    [SerializeField]
    public float enemySpeed = 1f;

    [SerializeField]

    void Start()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        Debug.LogFormat("I am a new enemy ({0}). Distance to player:: {1}", name, playerDistance);
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

    }
    private void Update()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.Log("player null");
            return;
        }
        if (gameController.winTextObject.activeSelf == true)
        {
            this.enabled = false;
        }

        
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }
}
