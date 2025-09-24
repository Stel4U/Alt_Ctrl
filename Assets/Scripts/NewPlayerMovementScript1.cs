using NUnit.Framework;
using UnityEngine;

public class NewPlayerMovementScript : MonoBehaviour
{
    [Header ("Movement Values")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] float rotSpeed = 5f;
    [SerializeField] float boostSpeed = 7f;
    [SerializeField] bool canMove = false;

    [Header("Objects To Fill Manually")]
    [SerializeField] GameObject feedbackCube;
    [SerializeField] Transform orientation;
    [SerializeField] Transform transformP;

    Vector3 transformPVector3;

    Rigidbody rb;

    KeyCode leftUThruster = KeyCode.U;
    bool isLeftUThruster;

    KeyCode rightUThruster = KeyCode.O;
    bool isRightUThruster;

    KeyCode upThruster = KeyCode.I;
    bool isUpThruster;

    KeyCode downThruster = KeyCode.K;
    bool isDownThruster;

    KeyCode boost = KeyCode.Space;


    Vector3 moveDirection;
    float yRotation;
    float xRotation;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetKey(leftUThruster))
        {
            xRotation += rotSpeed;
            isLeftUThruster = true;
        }
        else
        {
            isLeftUThruster = false;
        }

        if (Input.GetKey(rightUThruster))
        {
            xRotation -= rotSpeed;
            isRightUThruster = true;
        }
        else
        {
            isRightUThruster = false;  
        }

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        Debug.Log(xRotation);
    }

    void NewMovePlayer()
    {
        moveDirection = orientation.forward;

        if (isLeftUThruster || isRightUThruster)
        {
            if (canMove == true)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }

        }
    }

    private void FixedUpdate()
    {
        NewMovePlayer();
    }
}
