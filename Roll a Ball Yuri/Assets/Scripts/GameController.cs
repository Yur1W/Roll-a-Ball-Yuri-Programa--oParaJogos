using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{   [Header("Spawns")]
    [SerializeReference]
    protected float enemySpawned = 0;
    protected float pickupSpawned = 0;
    [Header ("Game State")]
    protected float tempo = 180;
    [SerializeField]
    protected static float pontos;
    
    [Header("UI")]
    [SerializeField]
    public TextMeshProUGUI pontosText; 
    [SerializeField]
    public GameObject winTextObject;

    void Start()
    {
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
        }
    }

}
