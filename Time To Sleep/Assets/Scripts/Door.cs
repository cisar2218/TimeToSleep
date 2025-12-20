using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] string nextLevel;


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindAnyObjectByType<LevelChanger>().FadeToLevel(nextLevel);
    }
}
