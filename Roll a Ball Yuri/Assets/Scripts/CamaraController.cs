using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject playerCode;
    private Vector3 deslocamento;

    void Start()
    {
        deslocamento = transform.position;
    }

    void Update()
    {
        SeguirJogador();
    }   

    void SeguirJogador()
    {
        if (playerCode == null) return;
        else
        {
            transform.position = playerCode.transform.position + deslocamento;
        }
        
    }
}
