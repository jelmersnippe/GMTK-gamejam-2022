using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public IntVariable currentRound;

    private void Awake()
    {
        currentRound.SetValue(1);
    }
}
