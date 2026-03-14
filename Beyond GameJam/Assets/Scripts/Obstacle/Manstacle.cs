using System.Collections.Generic;
using UnityEngine;

public class Manstacle : MonoBehaviour
{
    private bool isTriggered;
    private Rigidbody2D rb;
    [SerializeField] private float triggerRadius;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask triggerLayer;
    [SerializeField] private List<Transform> goList;

    private int index;
    private int currIndex;
    [SerializeField] private bool bulakbalik = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        index = goList.Count;
        currIndex = 0;
    }
    private void Update()
    {
        isTriggered = Physics2D.OverlapCircle(transform.position, triggerRadius, triggerLayer);
        if (isTriggered)
        {
            Debug.Log("AAAAAAHHHHH");
            transform.position = Vector2.MoveTowards(transform.position, goList[currIndex].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, goList[currIndex].position) < 0.3f)
            {
                currIndex++;

                if (bulakbalik)
                {
                    currIndex = currIndex % index; // loop
                }
                else
                {
                    if (currIndex >= index)
                        currIndex = index - 1; // stop at last
                }
            }
        }
    }

    private void walk()
    {
        //transform.position = Vector2.MoveTowards(transform.position, goList[index].position, speed * Time.deltaTime);
        //if (Vector2.Distance(transform.position, goList[index].position) < 0.3)
        //{
        //    index++;
        //}
        //rb.linearVelocityX = -speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
