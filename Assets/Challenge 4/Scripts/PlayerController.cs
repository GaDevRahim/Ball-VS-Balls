using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    bool space;
    [SerializeField] ParticleSystem dirt;
    float speed = 27.5f;

    [SerializeField] GameObject focalPoint;

    Rigidbody playerRB;
    [SerializeField] GameObject powerObj;
    Vector3 followPlayer;
    bool hasPower = false;
    float powerTime = 10.0f;

    Rigidbody BounceObj;
    Vector3 directionBounce;
    [SerializeField] GameObject targetGoal;
    float normalPower = 20;
    float strongPower = 30;

    internal static int score = 0;
    internal static bool gameOver = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        followPlayer = new Vector3(0, -0.65f, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (gameOver)
        {
            Destroy(gameObject);
            Destroy(powerObj);
            return;
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        space = Input.GetKey(KeyCode.Space);

        if (space)
        {
            speed = 40.0f;
            horizontalInput *= 2.5f;
            dirt.Play();
        } else if (!space)
        {
            speed = 25.0f;
            dirt.Stop();
        }

        playerRB.AddForce(focalPoint.transform.forward * verticalInput * speed);
        playerRB.AddForce(focalPoint.transform.right * horizontalInput * speed);

        focalPoint.transform.SetPositionAndRotation(transform.position, focalPoint.transform.rotation);

        powerObj.transform.SetPositionAndRotation(transform.position + followPlayer, powerObj.transform.rotation);
        dirt.transform.SetPositionAndRotation(transform.position + followPlayer, dirt.transform.rotation);
    }

    IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(powerTime);
        hasPower = false;
        powerObj.SetActive(hasPower);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPower = true;
            powerObj.SetActive(hasPower);
            StartCoroutine(TimeToWait());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BounceObj = collision.gameObject.GetComponent<Rigidbody>();
            directionBounce = (collision.gameObject.transform.position - transform.position).normalized;

            if (!hasPower)
                BounceObj.AddForce(directionBounce * normalPower, ForceMode.Impulse);
            else if(hasPower)
                BounceObj.AddForce(directionBounce * strongPower, ForceMode.Impulse);
        }
    }
}