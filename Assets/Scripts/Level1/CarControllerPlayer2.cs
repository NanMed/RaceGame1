using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarControllerPlayer2 : MonoBehaviour
{
    float speedForce = 30f;
    float torqueForce = -200f;
    float driftFactorSticky = 0.9f;
    float driftFactorSlippy = 1;
    float maxStickyVelocity = 2.5f;
    public static int coins = 0;

    public float resetDelay = 1f;

    int lap;

    public Text lapText;
    public Text coinText;
    public GameObject win;
    public GameObject lose;
    public Button nextLevel;
   
    private AudioSource lineSound;
    public static bool first = false;
    private bool second;

    // Use this for initialization
    private void Awake()
    {
        win.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        first = false;
    }
    void Start()
    {
        win.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        lap = -1;
        lineSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        second = Car2dController.first;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Debug.Log(RightVelocity().magnitude);

        float driftFactor = driftFactorSticky;
        if (RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }




        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if (Input.GetButton("Accelerate2"))
        {
            rb.AddForce(transform.up * speedForce);

        }

        if (Input.GetButton("Brakes2"))
        {
            rb.AddForce(transform.up * -speedForce / 2f);
        }


        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2);

        rb.angularVelocity = Input.GetAxis("Horizontal2") * tf;
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);

    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Oil")
        {
            speedForce = 4f;
            Debug.Log("collide Oil");
        }
        if (other.gameObject.tag == "FinishLine")
        {
            lap += 1;
            lapText.text = "Laps: " + lap;
            lineSound.Play();
        }
        if (other.gameObject.tag == "Tanque")
        {
            Destroy(other.gameObject);
            RunForTime(2f, () => speedForce += 7 * Time.deltaTime);
            Debug.Log("collide Tanque");
        }

        if (other.gameObject.tag == "Moneda")
        {
            Destroy(other.gameObject);
            coins += 1;
            coinText.text = "Coins: " + coins;
            Debug.Log("collide moneda");
        }

        CheckGameOver();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Oil")
        {
            speedForce = 30f;
        }
    }

    void CheckGameOver()
    {
        if (lap == 3)
        {
            first = true;
        }

        if (first && !second)
        {
            win.SetActive(true);
            nextLevel.gameObject.SetActive(true);
        } else
        {
            win.SetActive(false);
            nextLevel.gameObject.SetActive(false);
        }
        if (!first && second)
        {
            lose.SetActive(true);
        }
    }

    //https://answers.unity.com/questions/1222208/add-x-amount-in-x-seconds.html
    IEnumerator _RunForTime(float aDuration, System.Action aCallback)
    {
        float t = 0f;
        while (t < aDuration)
        {
            t += Time.deltaTime;
            aCallback();
            yield return null;
        }
    }
    public void RunForTime(float aDuration, System.Action aCallback)
    {
        StartCoroutine(_RunForTime(aDuration, aCallback));
    }

}