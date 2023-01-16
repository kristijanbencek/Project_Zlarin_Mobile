using UnityEngine;

public class CoralState : MonoBehaviour
{
    public GameData gameData;
    public GameManager gm;
    public SkinnedMeshRenderer modelMesh;
    public MeshRenderer[] eyesRender;

    [SerializeField] GameObject coralModel;
    [SerializeField] Animator coralAnimator;

    public bool coralVisible = true;


    private void Start()
    {
        InvokeRepeating("UpdateMethod", 0, 1);
    }
    void UpdateMethod()
    {
        InvokeRepeating("IsTheModelActive", 0, 1);
    }
    void IsTheModelActive()
    {
        gameData = SaveSystem.Load();
        if (gameData.firstLoad == true)
        {
            coralModel.SetActive(false);
        }
        else
        {
            coralModel.SetActive(true);
        }
    }
    void CheckAnimationState(string animationString)
    {
        SaveSystem.Load();
        //


    }
}
