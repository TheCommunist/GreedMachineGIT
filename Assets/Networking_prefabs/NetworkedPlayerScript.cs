using UnityEngine;
using UnityEngine.Networking;

public class NetworkedPlayerScript : NetworkBehaviour
{
    public TankFPSControl fpsController;
    public Camera fpsCamera;
    public AudioListener audioListener;
    public MouseAim mouseAim;
    public TestFire testFire;
    //public ShootingScript shootingScript;
    //public CandyCaneMaterialSwitcher candyMaterialSwitcher;

    Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public override void OnStartLocalPlayer()
    {
        fpsController.enabled = true;
        fpsCamera.enabled = true;
        audioListener.enabled = true;
        mouseAim.enabled = true;
        testFire.enabled = true;
        //shootingScript.enabled = true;
        //candyMaterialSwitcher.SwitchMaterial(true);

        gameObject.name = "LOCAL Player";
        base.OnStartLocalPlayer();
    }

    void ToggleRenderer(bool isAlive)
    {
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].enabled = isAlive;
    }

    void ToggleControls(bool isAlive)
    {
        fpsController.enabled = isAlive;
        //shootingScript.enabled = isAlive;
        fpsCamera.cullingMask = ~fpsCamera.cullingMask;
        testFire.enabled = isAlive;
    }

    [ClientRpc]
    public void RpcResolveHit()
    {
        ToggleRenderer(false);

        if (isLocalPlayer)
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;

            ToggleControls(false);
        }

        Invoke("Respawn", 2f);
    }

    void Respawn()
    {
        ToggleRenderer(true);

        if (isLocalPlayer)
            ToggleControls(true);
    }
}