using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] string nextLevel;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Not player!");
            return;
        }
            
        GameObject.FindAnyObjectByType<LevelChanger>().FadeToLevel(nextLevel);

    }
}
