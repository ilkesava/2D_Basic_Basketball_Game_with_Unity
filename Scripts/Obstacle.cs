using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    int NextPosIndex;
    Transform Nextpos;
    private bool IsMoving;
    void Start()
    {
        Nextpos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move(IsMoving);
    }

    public void Move(bool x)
    {
        this.IsMoving = x;

        if (x == true)
        {
            if (transform.position == Nextpos.position)
            {
                NextPosIndex++;
                if (NextPosIndex >= Positions.Length)
                {
                    NextPosIndex = 0;
                }
                Nextpos = Positions[NextPosIndex];
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Nextpos.position, ObjectSpeed * Time.deltaTime);
            }
        }
        
    }
}
