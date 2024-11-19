using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject focalPoint;
    public float speed;
    private float powerupStrength = 150000.0f;
    public GameObject powerupIndicator;
    public bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
        hasPowerup = false;
        powerupStrength = 150.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        RB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    

private void OnTriggerEnter(Collider other){
    if (other.CompareTag("PowerUp")){
        powerupIndicator.gameObject.SetActive(true);
        hasPowerup = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine());
    }
}
IEnumerator PowerupCountdownRoutine(){
    yield return new WaitForSeconds(7);
    powerupIndicator.gameObject.SetActive(false);
    hasPowerup = false;
}

private void OnCollisionEnter(Collision collision){
    if (collision.gameObject.CompareTag("Enemy") && hasPowerup){
        print("hello");

    Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
    Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

    Debug.Log("Player collided with" + collision.gameObject.name + "with powerup to" + hasPowerup);
    enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
    }

}
    
}
