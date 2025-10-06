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
    public float duraçaoPowerup = 1f;
    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        

    }
    void Update()
    {
        movement();
        ComerDuration();
        WinParticle();

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
            GameObject enemy = other.gameObject;
            comer(enemy);
            enemySpawned--;
        }
        if (other.gameObject.CompareTag("Enemy") && !podeComer)
        {
            var gameOver = winTextObject.GetComponent<TextMeshProUGUI>();
            gameOver.text = "Game Over!";
            winTextObject.SetActive(true);
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
    void WinParticle()
    {
        if (pontos >= 12)
        {
            GetComponent<ParticleSystem>().Play();
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
    void ComerDuration()
    {
        if (podeComer)
        {
            timer += Time.deltaTime;
            if (timer >= duraçaoPowerup)
            {
                podeComer = false;
                timer = 0;
            }
        }
    }

    public void ApplyPowerUpModifier(PowerUpModefier powerUpModifier)
    {
        powerUpModifier.Activate(gameObject);
    }

}
