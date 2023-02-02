using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector2    initialPos;

    private void Start() { Instantiate(this.ballPrefab, this.initialPos, Quaternion.identity); }
}