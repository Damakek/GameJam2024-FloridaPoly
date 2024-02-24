using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class player : MonoBehaviour
{

    //movement
    public Vector2 lastDirection;
    //this is for gun angle. it's gonna be 8directional but idc at this point we can fix it in post
    public Vector2 shootDirection;

    //bullets
    public bool shooting = false;
    public GameObject bullet;

    //in case we wanna change increment/decriment values of drugs
    public int increaseBy;
    public int decreaseBy;

    //personal stats
    public int hp;
    int maxhp;
    public int attack;
    public int defense;
    public float speed;
    public int range;

    //things to display said stats in
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI moveText;

    public int amount;

    Rigidbody myRig;
    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        maxhp = hp;

        myRig = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();

        //set all of this
        hpText.text = "HP: " + hp;
        attackText.text = "ATK: " + attack;
        defText.text = "DEF: " + defense;
        rangeText.text = "RNG: " + range;
        moveText.text = "SPD: " + speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetV = new Vector3(lastDirection.x, lastDirection.y, 0).normalized * speed;
        myRig.velocity = Vector3.Lerp(myRig.velocity, targetV, 5);
        if (myRig.velocity.magnitude > 0)
        {
            myAnimator.SetFloat("speed", 1f);
        }
        else {
            myAnimator.SetFloat("speed", 0);
        }
    }

    public void move(InputAction.CallbackContext ev)
    {
        if (ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
            if (lastDirection.x == 0 && lastDirection.y == 1)
            { //up
                myAnimator.SetInteger("direction", 3);
            }
            else if ((lastDirection.x == 0 && lastDirection.y == 0) || (lastDirection.x == 0 && lastDirection.y == -1))
            {//down
                myAnimator.SetInteger("direction", 1);
            }
            else if (lastDirection.x == 1 && lastDirection.y == 0)
            {//right
                myAnimator.SetInteger("direction", 2);
            }
            else if (lastDirection.x == 0 && lastDirection.y == -1) {//down
                myAnimator.SetInteger("direction", 1    );
            }
            else
            {//left
                myAnimator.SetInteger("direction", 4);
            }
        }
        if (ev.canceled)
        {
            lastDirection = Vector2.zero;
            myAnimator.SetInteger("direction", 0);
        }
    }

    public void shoot(InputAction.CallbackContext ev) {
        if (ev.performed) {
            shooting = true;
            shootDirection = ev.ReadValue<Vector2>();
        }
        if (ev.canceled) {
            Debug.Log("Canceled");
            shooting = false;
            shootDirection = Vector2.zero;
        }
    }

    public IEnumerator Shoot() {
        if (shooting && shootDirection.magnitude != 0) {
            //spawn bullet here
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(.2f);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("Hit by an enemy!");
            hp -= amount;
            hpText.text = "HP: " + hp;
            if (hp <= 0)
            {
                die();
            }
        }

        if (other.gameObject.tag == "drug") {
            //Debug.Log("Drug located");
            string plustemp = other.GetComponent<drug>().plus;
            string minustemp = other.GetComponent<drug>().minus;

            Debug.Log(plustemp + ", " + minustemp);

            switch (plustemp) {
                case "hp":
                    hp += increaseBy;
                    hpText.text = "HP: " + hp;
                    break;
                case "atk":
                    attack += increaseBy;
                    attackText.text = "ATK: " + attack;
                    break;
                case "def":
                    defense += increaseBy;
                    defText.text = "DEF: " + defense;
                    break;
                case "range":
                    range += increaseBy;
                    rangeText.text = "RNG: " + range;
                    break;
                case "move":
                    speed += increaseBy;
                    moveText.text = "SPD: " + speed;
                    break;
                default:
                    Debug.Log("Invalid drug");
                    break;
            }
            switch (minustemp)
            {
                case "hp":
                    hp += decreaseBy;
                    hpText.text = "HP: " + hp;
                    break;
                case "atk":
                    attack += decreaseBy;
                    attackText.text = "ATK: " + attack;
                    break;
                case "def":
                    defense += decreaseBy;
                    defText.text = "DEF: " + defense;
                    break;
                case "range":
                    range += decreaseBy;
                    rangeText.text = "RNG: " + range;
                    break;
                case "move":
                    speed += decreaseBy;
                    moveText.text = "SPD: " + speed;
                    break;
                default:
                    Debug.Log("Invalid drug");
                    break;
            }
        }
    }

    public void die() {
        //lmao freal???
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }
}
