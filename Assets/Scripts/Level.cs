using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    SceneLoader sceneLoader;

    private void Awake() => sceneLoader = FindObjectOfType<SceneLoader>();

    public void CountBlocks() => breakableBlocks++;

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
