using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float movespeed = 10f;

    float dirx, diry;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxis("Horizontal") * movespeed;
        diry = Input.GetAxis("Vertical") * movespeed;

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, diry);
    }
}
