using UnityEngine;
using UnityEngine.Playables;

public class PlayerCastScenesManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _deathCutscene;

    public void PlayDeathCutscene()
    {
        _deathCutscene.Play();
    }
}