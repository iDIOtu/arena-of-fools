using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _attack;
    [SerializeField] private AudioSource _jump;

    public void PLayAttackSound()
    {
        _attack.Play();
    }

    public void PLayJumpSound()
    {
        _jump.Play();
    }
}
