using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public IntReference currentRound;

    private void Awake()
    {
        currentRound.value = 1;

        DontDestroyOnLoad(gameObject);
    }
}
