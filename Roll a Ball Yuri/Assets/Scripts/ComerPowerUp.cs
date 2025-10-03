using UnityEngine;
[CreateAssetMenu(menuName = "PowerUp /Comida")]

public class ComerPowerUp : PowerUpModefier
{
    public override void Activate(GameObject target)
    {
        var player = target.GetComponent<PlayerController>();
        player.podeComer = true;
    }
}
