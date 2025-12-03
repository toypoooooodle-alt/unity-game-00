using UnityEngine;

public class Sexplayercontol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float nowSpeed = 0f;
    [SerializeField] private float maxSpeed = 20f;
    public float HalfMoveLimit = 8f;

    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        // スピード変更
        if (nowSpeed > 0)
        {
            nowSpeed -= 10 * Time.deltaTime;
        }
        else if (nowSpeed < 0)
        {
            nowSpeed += 10 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nowSpeed -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            nowSpeed += moveSpeed * Time.deltaTime;
        }

        if (nowSpeed >= maxSpeed)
        {
            nowSpeed = maxSpeed;
        }

        if (nowSpeed <= -maxSpeed)
        {
            nowSpeed = -maxSpeed;
        }

        // 移動
        transform.position += nowSpeed * Time.deltaTime * Vector3.right;

        if (transform.position.x >= HalfMoveLimit)
        {
            transform.position = new Vector3(HalfMoveLimit, transform.position.y, transform.position.z);
            nowSpeed = 0f;
        }

        if (transform.position.x <= -HalfMoveLimit)
        {
            transform.position = new Vector3(-HalfMoveLimit, transform.position.y, transform.position.z);
            nowSpeed = 0f;
        }
    }
}