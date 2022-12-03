using UnityEngine;

public class CoinCollisionDetector : MonoBehaviour
{

    private CircleCollider2D cC;
    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.tag == "Player") {
            Debug.Log(other.rigidbody.tag);
            DestroyObject();
        }
    }
}
