using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 15;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;
    public float maxUpRotation = 25f;
    public float maxDownRotation = -5f;
    public float rotationSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -28 || transform.position.y > 28)
        {
            finishGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        float rotationZ = myRigidbody.linearVelocity.y;

        rotationZ = Mathf.Clamp(rotationZ, maxDownRotation, maxUpRotation);

        Quaternion targetRotation = Quaternion.Euler(0, 0, rotationZ);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        finishGame();
    }

    private void finishGame() {
        logic.gameOver();
        birdIsAlive = false;
    }
}
