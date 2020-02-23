using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    SceneLoader sceneLoader;

    private void Awake() => sceneLoader = FindObjectOfType<SceneLoader>();

    public void CountBreakableBlocks() => breakableBlocks++;

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
