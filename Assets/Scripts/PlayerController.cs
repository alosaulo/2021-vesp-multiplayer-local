using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;

    public float speed;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("HorizontalP"+playerNumber);
        float vAxis = Input.GetAxisRaw("VerticalP"+playerNumber);

        Vector2 newPos = new Vector2(hAxis, vAxis);

        rigidbody2D.velocity = newPos.normalized * speed;
    }
}
