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
        transform.Rotate(new Vector3(Random.Range(10, 45), Random.Range(25, 60), Random.Range(40, 75))* Time.deltaTime);
    }
}
