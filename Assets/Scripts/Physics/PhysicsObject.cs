using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: 2D Platformer Character Controller - Scripting Gravity [2/8], [3/8]
//         https://www.youtube.com/watch?v=hn9lkAua3Vk&t 
//         https://www.youtube.com/watch?v=nyVfYhaomVQ&t

public class PhysicsObject : MonoBehaviour
{ 
    public float minGroundNormalY = .65f;

    protected bool grounded;

    protected Rigidbody2D rb2d;

    protected Vector2 velocity; //other classes will inherit, and they should be able to access velocity
    protected Vector2 groundNormal;

    public float gravityModifier = 1f; //allows us to scale the gravity (ie speed of drop)

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    protected ContactFilter2D contactFilter;


    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {

        float distance = move.magnitude;

        if ( distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

            hitBufferList.Clear();

            for(int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;

                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);

                if (projection < 0)
                {
                    velocity = velocity = projection * currentNormal;
                }

                float modifiedDist = hitBufferList[i].distance - shellRadius;
                distance = modifiedDist < distance ? modifiedDist : distance;
            }
        }


        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
