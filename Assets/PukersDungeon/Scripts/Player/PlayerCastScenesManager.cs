using UnityEngine;
using UnityEngine.Playables;

public class PlayerCastScenesManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _deathCutscene;
    [SerializeField] private PlayableDirector _winCutscene;

    public void PlayDeathCutscene()
    {
        _deathCutscene.Play();
    }

    public void PlayWinCutscene()
    {
        _winCutscene.Play();
    }
}