using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private const float POWERUPTIME = 7.0f;
    private GameObject focalPoint;
    private Rigidbody rb;
    private bool hasPowerUP;
    public GameObject powerUpRing;
    public float power = 10.0f;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasPowerUP = false;
        focalPoint = GameObject.Find("Focal Point");
        powerUpRing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(speed * verticalInput * focalPoint.transform.forward);

        powerUpRing.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUP"))
        {
            powerUpRing.SetActive(true);
            hasPowerUP = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCount());
        }
    }

    IEnumerator PowerUpCount()
    {
        yield return new WaitForSeconds(POWERUPTIME);
        powerUpRing.SetActive(false);
        hasPowerUP = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUP)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * power, ForceMode.Impulse);
        }
    }
}
