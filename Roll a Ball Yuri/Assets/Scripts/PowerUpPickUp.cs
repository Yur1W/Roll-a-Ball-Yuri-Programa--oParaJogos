using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{   [SerializeField]
    PowerUpModefier powerUpModifier;   
    PlayerController playerController;
    void OnTriggerEnter(Collider other)
    {
        playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            ActivatePowerUp(playerController);
        }
    }

    public void ActivatePowerUp(PlayerController playerController)
    {
        playerController.ApplyPowerUpModifier(powerUpModifier);
    }
     void Update()
    {
        transform.Rotate(new Vector3(0f, 90, 0f) * Time.deltaTime);
        //transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
