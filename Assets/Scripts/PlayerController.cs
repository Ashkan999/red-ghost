using System.Collections;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public GameObject playerEffect;
    private InputMaster inputMaster;
    private float verticalMovement = 2.0f;
    public float verticalSpeed = 30.0f;
    private float maxHeight = 4.0f;
    private float minHeight = -2.0f;
    private Vector2 startPostion = new Vector2(0, 0);
    private Vector2 currentPosition;

    void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Player.Up.performed += context => { StopCoroutine(MoveUp()); StartCoroutine(MoveUp()); };
        inputMaster.Player.Down.performed += context => { StopCoroutine(MoveDown()); StartCoroutine(MoveDown()); };

        rb2D.position = startPostion;
        currentPosition = startPostion;
    }

    IEnumerator MoveUp()
    {
        if (currentPosition.y < maxHeight)
        {
            AudioManager.instance.PlayPlayerMoveSound();
            CameraShaker.Instance.ShakeOnce(2f, 5f, 0f, 0.2f);
            Destroy(Instantiate(playerEffect, rb2D.position, Quaternion.Euler(180, 0, 0)), 2f);
            Vector2 targetPos = currentPosition + Vector2.up * verticalMovement;
            currentPosition = targetPos;
            while (rb2D.position != targetPos)
            {
                rb2D.MovePosition(Vector2.MoveTowards(rb2D.position, targetPos, verticalSpeed * Time.fixedDeltaTime));
                yield return null;
            }
        }
    }

    IEnumerator MoveDown()
    {
        if (currentPosition.y > minHeight)
        {
            AudioManager.instance.PlayPlayerMoveSound();
            CameraShaker.Instance.ShakeOnce(2f, 5f, 0f, 0.2f);
            Destroy(Instantiate(playerEffect, rb2D.position, Quaternion.identity), 2f);
            Vector2 targetPos = currentPosition + Vector2.down * verticalMovement;
            currentPosition = targetPos;
            while (rb2D.position != targetPos)
            {
                rb2D.MovePosition(Vector2.MoveTowards(rb2D.position, targetPos, verticalSpeed * Time.fixedDeltaTime));
                yield return null;
            }
        }
    }

    // private Vector2 GetNearestPosition(Vector2 position)
    // {
    //     int size = (int)((maxHeight - minHeight) / verticalMovement) + 1;
    //     Vector2[] positions = new Vector2[size];
    //     for (int i = 0; i < size; i++)
    //     {
    //         positions[i] = new Vector2(position.x, minHeight + i * verticalMovement);
    //     }

    //     int smallestDisIndex = -1;
    //     float minDis = float.MaxValue;
    //     for (int i = 0; i < size; i++)
    //     {
    //         if (Vector2.Distance(position, positions[i]) < minDis)
    //         {
    //             minDis = Vector2.Distance(position, positions[i]);
    //             smallestDisIndex = i;
    //         }
    //     }
    //     //throw Exception if -1
    //     return positions[smallestDisIndex];
    // }

    public void EnablePlayerControls()
    {
        inputMaster.Player.Enable();
    }

    public void DisablePlayerControls()
    {
        inputMaster.Player.Disable();
    }

    void OnEnable()
    {
        EnablePlayerControls();
    }

    void OnDisable()
    {
        DisablePlayerControls();
    }
}
