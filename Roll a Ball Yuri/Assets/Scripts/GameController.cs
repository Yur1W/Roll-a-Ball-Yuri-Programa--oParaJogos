using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{   [Header("Spawns")]
    [SerializeField]
    public static float enemySpawned
    { get; set;}
    protected float pickupSpawned = 0;
    [Header ("Game State")]
    protected float tempo = 180;
    [SerializeField]
    protected static float pontos;
    public static bool playerAlive;
    GameObject player;
    
    [Header("UI")]
    [SerializeField]
    public TextMeshProUGUI pontosText; 
    [SerializeField]
    public GameObject winTextObject;

    void Start()
    {
        player = GameObject.Find("Player");
        pontos = 0;
        winTextObject.SetActive(false);
    }


    void Update()
    {
        
        tempo = (1 * Time.deltaTime) - tempo;  
        SetCountText();   
    }

    private void SetCountText()
    {
        pontosText.text = "Pontos: " + pontos.ToString();
        if (pontos >= 12)
        {
            winTextObject.SetActive(true);
            player.GetComponent<ParticleSystem>().Play();
        }
    }

}
