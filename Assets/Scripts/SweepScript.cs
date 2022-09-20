using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepScript : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    BoxCollider2D coll;
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.Hit("sweeping box");
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1.7f), ForceMode2D.Impulse);
        }
    }
}
