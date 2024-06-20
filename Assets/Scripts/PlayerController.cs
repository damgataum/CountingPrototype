using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float throwIntensity;
    [SerializeField] GameObject aimObject;
    private GameObject stretchCube;
    private Vector3 dragPos;
    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 maxPos = new Vector3(-20, 0.6f, 0);

    private Vector3 mOffset;
    private float mZCoord;
    private Rigidbody ballRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get Game Manager object
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Get start position
        startPos = transform.position;

        // Get Ball Rigidbody
        ballRb = GetComponent<Rigidbody>();

        // Deactivate aim
        aimObject.SetActive(false);

        // Get aiming Cube's GameObject
        stretchCube = aimObject.transform.GetChild(1).gameObject;
    }

    // When mouse button is pressed
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            // Turn on aim
            aimObject.SetActive(true);

            // Get Camera's Z position
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            // Define offset from mouse pointer relative to the game display area
            mOffset = transform.position - GetMouseWorldPos();
        }
    }

    // While draging the mouse
    private void OnMouseDrag()
    {
        if (gameManager.isGameActive)
        {
            // Define position of the mouse in the game display
            dragPos = GetMouseWorldPos() + mOffset;
            newPos.z = 0f;

            // Limit x position so the player cannot drag the ball forward
            if (dragPos.x >= startPos.x)
            {
                newPos.x = startPos.x;
            }
            // Limit y position so the player cannot drag the ball past x maxPos limit
            else if (dragPos.x <= maxPos.x)
            {
                newPos.x = maxPos.x;
            }
            else
            {
                newPos.x = dragPos.x;
            }

            // Limit y position so the player cannot drag the ball upwards
            if (dragPos.y >= startPos.y)
            {
                newPos.y = startPos.y;
            }
            // Limit y position so the player cannot drag the ball under the ground
            else if (dragPos.y <= maxPos.y)
            {
                newPos.y = maxPos.y;
            }
            else
            {
                newPos.y = dragPos.y;
            }

            // Set ball position to new limited mouse position
            transform.position = newPos;

            // Change it's position to be right between the aim and the ball
            stretchCube.transform.position = (startPos + newPos) / 2;
            // Rotate the cube towards the aim
            if (newPos != startPos) {
                stretchCube.transform.rotation = Quaternion.LookRotation((newPos - startPos));
            }
            // Stretch the aiming cube to the Ball's position
            stretchCube.transform.localScale = new Vector3(0.2f, 0.2f, (-1 * newPos.x - 15));
        }
    }

    private void OnMouseUp()
    {
        Vector3 throwForce;

        throwForce = (startPos - newPos) * throwIntensity;

        ballRb.useGravity = true;
        ballRb.AddForce(throwForce, ForceMode.Impulse);

        aimObject.SetActive(false);
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePosGlobal = Input.mousePosition;
        mousePosGlobal.z = mZCoord;
        Vector3 mousePosScreen = Camera.main.ScreenToWorldPoint(mousePosGlobal);
        return mousePosScreen;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.isGameActive && collision.gameObject.name != "Obstacle")
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.0f);

        if (gameManager.isGameActive)
        {
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.position = startPos;
            aimObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
