using UnityEngine;

public class PowerUpHealth : PowerUp
{
    public float amountToHeal;

    public override void Apply( Pawn target )
    {
        // Heal the pawn in target
        // Check if the pawn we are "healinng" has a health component
        if (target.health != null)
        {
            // Call its heal component
            target.health.Heal( amountToHeal );
        }
    }

    public override void Remove( Pawn target )
    {
        // TODO: Nothing. We don't do anything when removing a healing powerup
    }
}
