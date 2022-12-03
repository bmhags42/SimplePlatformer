using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D player;
    private PolygonCollider2D pC2d;
    private bool canDoubleJump;
    [SerializeField] private float speed;
    [SerializeField] private float fallSpeed;

   private void Awake() {
    player = GetComponent<Rigidbody2D>();
    pC2d = GetComponent<PolygonCollider2D>();
   } 

   private void Update() {
    // Debug.Log(player.velocity.y);

    //Jump
    if (Input.GetKeyDown(KeyCode.Space)) { 
        if (IsGrounded() | canDoubleJump) {
            player.velocity = new Vector2(player.velocity.x, speed);
            //Update double Jump status
            canDoubleJump = false;
        }
    
        //****************************************************************
        //Add short hop and high jump
        // use time.Time
    }

    // Update Double Jump Status
    if (IsGrounded() && !canDoubleJump) {
        canDoubleJump = true;
    }

    //Fast Fall
    if (!IsGrounded()) {
        if (Input.GetKey(KeyCode.S)) {
            player.velocity = new Vector2(player.velocity.x, -speed);
        }
    }
   }

   private void FixedUpdate() {
    if (Input.GetAxis("Horizontal") != 0) {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);
    } else {
        player.velocity = new Vector2(0, player.velocity.y);
    }

   }
    
    private bool IsGrounded() {
        float extraHeight = .5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(pC2d.bounds.center, Vector2.down, pC2d.bounds.extents.y + extraHeight, platformLayerMask);
        
        /*
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(pC2d.bounds.center, Vector2.down * (pC2d.bounds.extents.y + extraHeight), rayColor);
        Debug.Log(raycastHit.collider);
        */
        return raycastHit.collider != null;
    }
}
