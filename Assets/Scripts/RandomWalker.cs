using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalker : MonoBehaviour
{
    [SerializeField] private float      speed;

    private Vector2     direction;
    private Vector2     bound;

    private void Start()
    {
        this.bound     = this.GetScreenBoundWithBall();
        this.direction = this.GetRandomDirection();
        }

    private void Update()
    {
        if (Math.Abs(Mathf.Abs(this.transform.position.x) - this.bound.x) > float.Epsilon || Math.Abs(Mathf.Abs(this.transform.position.y) - this.bound.y) > float.Epsilon)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.direction, this.speed * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, new Vector2(this.direction.x, this.direction.y)) < float.Epsilon)
            {
                this.direction = this.GetRandomDirection();
            }
        }
    }

    private Vector2 GetScreenBoundWithBall()
    {
        var screenBound          = Camera.main!.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane / 2));
        var screenBoundWithBallX = screenBound.x - this.transform.localScale.x / 2; // Minus Radius of the ball
        var screenBoundWithBallY = screenBound.y - this.transform.localScale.x / 2; // Minus Radius of the ball
        return new Vector2(screenBoundWithBallX, screenBoundWithBallY);
    }

    private Vector2 GetRandomDirection()
    {
        var randomX = Random.Range(0, 1) == 0 ? 1 * Random.Range(-this.bound.x, this.bound.x) : -1 * Random.Range(-this.bound.x, this.bound.x);
        var randomY = Random.Range(0, 1) == 0 ? 1 * Random.Range(-this.bound.y, this.bound.y) : -1 * Random.Range(-this.bound.y, this.bound.y);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello");
    }
}