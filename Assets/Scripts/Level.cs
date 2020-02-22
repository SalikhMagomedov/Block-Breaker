using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
}
