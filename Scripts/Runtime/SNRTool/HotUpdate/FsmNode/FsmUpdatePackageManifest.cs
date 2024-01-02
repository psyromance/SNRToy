using System.Collections;
using UnityEngine;
using UniFramework.Machine;
using YooAsset;
using SNRKWordDefine;


/// <summary>
/// 更新资源清单
/// </summary>
public class FsmUpdatePackageManifest : IStateNode
{
    private StateMachine _machine;

    void IStateNode.OnCreate(StateMachine machine)
    {
        _machine = machine;
    }
    void IStateNode.OnEnter()
    {
        PatchEventDefine.PatchStatesChange.SendEventMessage("更新资源清单！");
        var coBehaviour = (MonoBehaviour)_machine.GetBlackboardValue(KWord.CoroutineBehaviour);
        coBehaviour.StartCoroutine(UpdateManifest());
    }
    void IStateNode.OnUpdate()
    {
    }
    void IStateNode.OnExit()
    {
    }

    private IEnumerator UpdateManifest()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        var packageName = (string)_machine.GetBlackboardValue(KWord.PackageName);
        var packageVersion = (string)_machine.GetBlackboardValue(KWord.PackageVersion);
        var package = YooAssets.GetPackage(packageName);
        bool savePackageVersion = true;
        var operation = package.UpdatePackageManifestAsync(packageVersion, savePackageVersion);
        yield return operation;

        if (operation.Status != EOperationStatus.Succeed)
        {
            Debug.LogWarning(operation.Error);
            PatchEventDefine.PatchManifestUpdateFailed.SendEventMessage();
            yield break;
        }
        else
        {
            _machine.ChangeState<FsmCreatePackageDownloader>();
        }
    }
}