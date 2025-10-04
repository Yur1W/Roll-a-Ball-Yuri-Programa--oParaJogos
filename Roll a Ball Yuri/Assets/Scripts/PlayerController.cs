using TMPro;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : GameController
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    public float velocidade = 5f;
    public bool podeComer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        movement();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pick Up")
        {   
            pontos++;
            other.gameObject.SetActive(false);
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {   
            GameObject enemy = other.gameObject.GetComponent<GameObject>();
            comer(enemy);
        }
        if (other.gameObject.CompareTag("Enemy") && !podeComer)
        {
            var gameOver = winTextObject.GetComponent<TextMeshProUGUI>();
            gameOver.text = "Game Over!";
            winTextObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    void movement()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0, movimentoVertical);
        rb.AddForce(movimento * velocidade);
    }

    void comer(GameObject other)
    {
        if (podeComer == true)
        {
            pontos = pontos + 2;
            Destroy(other);  
        }
    }

    public void ApplyPowerUpModifier(PowerUpModefier powerUpModifier)
    {
        powerUpModifier.Activate(gameObject);
    }

}
