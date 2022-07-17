using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TextMeshPro number;

    public void SetDamage(int damage)
    {
        number.text = damage.ToString();
    }
}
