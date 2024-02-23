using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    //movement
    public Vector2 lastDirection;

    //bullets
    public bool shooting = false;
    public GameObject bullet;

    //personal stats
    public int hp;
    int maxhp;
    public int attack;
    public int defense;
    public float speed;
    public int range;

    Rigidbody myRig;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        maxhp = hp;

        myRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetV = new Vector3(lastDirection.x, lastDirection.y, 0).normalized * speed;
        myRig.velocity = Vector3.Lerp(myRig.velocity, targetV, 5);
    }

    public void move(InputAction.CallbackContext ev)
    {
        if (ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
        }
        if (ev.canceled)
        {// if cancelled, set last direction to 0 and this saves on computation
            lastDirection = Vector2.zero;
        }
    }

    public void shoot(InputAction.CallbackContext ev) {
        if (ev.performed) {
            shooting = true;
        }
        if (ev.canceled) {
            shooting = false;
        }
    }

    public IEnumerator Shoot() {
        if (shooting) {
            //spawn bullet here
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy") { 
            //wow math for stuffs here
        }
    }

    public void die() { 
        //lmao freal???
    }
}
