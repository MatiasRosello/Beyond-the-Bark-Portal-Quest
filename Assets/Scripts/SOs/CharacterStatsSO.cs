using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "CharacterSO", order = 0)]
public class CharacterStatsSO : ScriptableObject
{
    public string id;

    [Header("Health")]
    public float initialHealth;

    [Header("Attack")]
    public float damage;
    public string opponentTag;
    public float knockbackForce;
}