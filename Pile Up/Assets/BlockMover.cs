using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    public float maxOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<BoxCollider2D>().enabled = true;
            rb.isKinematic = false;
            BlockSpawner.OnBlockReleased?.Invoke();
            Destroy(this);
        }
    }
    
    void FixedUpdate()
    {
        if (rb.isKinematic)
        {
            rb.MovePosition(new Vector2(Mathf.Lerp(maxOffset, -maxOffset, Mathf.PingPong(Time.time * moveSpeed, 1)), transform.position.y));
        }
    }
}
