using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Animator animator;

    private string levelToLoad;

    public void FadeToLevel(string levelName)
    {
        animator.SetTrigger("FadeOut");
        levelToLoad = levelName;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // public void FadeToNextLevel()
    // {
    //     FadeToLevel(SceneManager.GetActiveScene().buildIndex+1);
    // }
}
