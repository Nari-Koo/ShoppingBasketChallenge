using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.SceneManagement;
using Unity.XR.CoreUtils;
using System.Collections;

public class XROriginManager : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private XROrigin xrOrigin;

    void Start()
    {
        xrOrigin = GetComponent<XROrigin>();
        initialPosition = xrOrigin.transform.position;
        initialRotation = xrOrigin.transform.rotation;

        SceneManager.sceneLoaded += OnSceneLoaded;

        // XR 시스템 초기화
        StartCoroutine(InitializeXR());
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private IEnumerator InitializeXR()
    {
        var xrManager = XRGeneralSettings.Instance.Manager;

        if (xrManager == null)
        {
            Debug.LogError("XR Manager를 찾을 수 없습니다. XR Plug-in 설정을 확인하세요.");
            yield break;
        }

        if (!xrManager.isInitializationComplete)
        {
            yield return xrManager.InitializeLoader();
        }

        if (xrManager.activeLoader != null)
        {
            xrManager.StartSubsystems();
            Debug.Log("XR 서브시스템이 시작되었습니다.");
        }
        else
        {

        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(ResetXROriginWithDelay());
    }

    private IEnumerator ResetXROriginWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // 초기화 대기

        xrOrigin.transform.position = initialPosition;
        xrOrigin.transform.rotation = initialRotation;

        TryRecenterHMD();
    }

    private void TryRecenterHMD()
    {
        var xrInputSubsystem = XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRInputSubsystem>();

        if (xrInputSubsystem != null)
        {
            bool recentered = xrInputSubsystem.TryRecenter();
            Debug.Log(recentered ? "HMD 재정렬 성공" : "HMD 재정렬 실패");
        }
        else
        {
            Debug.LogWarning("XRInputSubsystem을 찾을 수 없습니다.");
        }
    }
}