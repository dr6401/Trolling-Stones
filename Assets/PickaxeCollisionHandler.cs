using UnityEngine;

public class PickaxeCollisionHandler : MonoBehaviour
{
    public PickaxeController controller; // Reference to parent script

    private float swingForce;

    private void Awake()
    {
        swingForce = controller.swingForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected on pickaxe with: " + collision.gameObject.name);

        if (/*controller.isSwinging && */collision.gameObject.CompareTag("Boulder"))
        {
            Rigidbody2D boulderRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (boulderRb != null)
            {
                Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
                boulderRb.AddForce(forceDirection * swingForce, ForceMode2D.Impulse);
            }
        }
    }
}
