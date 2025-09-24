using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] GameObject tUp;
    [SerializeField] GameObject tDown;
    [SerializeField] GameObject tLeft;
    [SerializeField] GameObject tRight;
    [SerializeField] GameObject tBoost;
    [SerializeField] Rigidbody rb;

    [SerializeField] GameObject feedbackCube;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] float boostSpeed = 7f;

    KeyCode leftUThruster = KeyCode.U;
    KeyCode leftDThruster = KeyCode.J;

    KeyCode rightUThruster = KeyCode.O;
    KeyCode rightDThruster = KeyCode.L;

    KeyCode upThruster = KeyCode.I;
    KeyCode downThruster = KeyCode.K;

    KeyCode boost = KeyCode.Space;

    void MovePlayer()
    {
        if (Input.GetKey(leftUThruster)) {
            rb.AddForce(moveSpeed * -2f, 0, moveSpeed * 2f);
        }

        if (Input.GetKey(leftDThruster))
        {
            rb.AddForce(moveSpeed * 2f, 0, moveSpeed * -2f);
        }


        if (Input.GetKey(rightUThruster))
        {
            rb.AddForce(moveSpeed * 2f, 0, moveSpeed * 2f);
        }

        if (Input.GetKey(rightDThruster))
        {
            rb.AddForce(moveSpeed * -2f, 0, moveSpeed * -2f);
        }


        if (Input.GetKey(upThruster))
        {
            rb.AddForce(0, moveSpeed * 2f, 0);
        }

        if (Input.GetKey(downThruster))
        {
            rb.AddForce(0, moveSpeed * -2f, 0);
        }


        if (Input.GetKey(boost))
        {
            moveSpeed = boostSpeed;
            feedbackCube.SetActive(true);

        }
        else
        {
            moveSpeed = baseSpeed;
            feedbackCube.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
