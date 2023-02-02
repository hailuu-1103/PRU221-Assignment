using UnityEngine;

public class EmptyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject emptyPrefab;
    [SerializeField] private float      spawnDuration;

    private float            timer;

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.spawnDuration)
        {
            Instantiate(this.emptyPrefab, this.transform);
            this.timer = 0;
        }
    }
}