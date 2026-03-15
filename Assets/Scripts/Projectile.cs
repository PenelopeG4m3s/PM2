using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan;
    public float damageDone;
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
