using Google.Play.AppUpdate;
using Google.Play.Common;
using System.Collections;
using UnityEngine;

public class InAppUpdate : MonoBehaviour
{
#if !UNITY_EDITOR
   AppUpdateManager appUpdateManager;
   private void Awake()
   {
      appUpdateManager = new AppUpdateManager();
   }
   private void Start()
   {
      if(CheckInternet())
        StartCoroutine(CheckForUpdate());
   }
   IEnumerator CheckForUpdate()
   {
      PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation = appUpdateManager.GetAppUpdateInfo();
      yield return appUpdateInfoOperation;

      if (appUpdateInfoOperation == null)
         yield break;

      if (appUpdateInfoOperation.IsSuccessful)
      {
         AppUpdateInfo appUpdateInfoResult = appUpdateInfoOperation.GetResult();
         Debug.Log("UpdateAvailability " + appUpdateInfoResult.UpdateAvailability);
         if (appUpdateInfoResult.UpdateAvailability != UpdateAvailability.UpdateAvailable)          
            yield break;
         
         var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions(allowAssetPackDeletion: false);
         if (appUpdateOptions.AllowAssetPackDeletion)
            appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions(allowAssetPackDeletion: true);

         yield return StartImmediateUpdate(appUpdateInfoResult, appUpdateOptions);
      }
      else
         Debug.Log("error " + appUpdateInfoOperation.Error);
   }
   IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInfoResult, AppUpdateOptions appUpdateOptions)
   {
      var startUpdateRequest = appUpdateManager.StartUpdate(appUpdateInfoResult, appUpdateOptions);
      Debug.Log("update before " + startUpdateRequest.Status);
      yield return startUpdateRequest;
     Debug.Log("update failed " + startUpdateRequest.Status);
      Application.Quit();
   }
#endif
    private bool CheckInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
