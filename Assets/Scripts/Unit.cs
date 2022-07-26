using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Update()
    {

        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            //transform.forward = moveDirection; //Face move direction
            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed); //Face move direction smoothly

            unitAnimator.SetBool("IsWalking", true); //Move Unit
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false); //Stop Unit
        }
                
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }



}
