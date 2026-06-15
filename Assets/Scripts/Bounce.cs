using UnityEngine;

public class Bounce : MonoBehaviour {
    public float bounceForce = 10f;

private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            Destroy(gameObject);
        }

        

    }
}