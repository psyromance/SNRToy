using UnityEngine;
using YooAsset;
using SNRKWordDefine;

public static class YooAssetHelper
{
    public static string GetPackageVersion(string packageName = KWord.PkgUnityObj)
    {
        string version = null;
        var defPackage = YooAssets.TryGetPackage(packageName);
        if (defPackage != null)
        {
            version = defPackage.GetPackageVersion();
        }

        return version;
    }
    public static Texture2D GetTexture2D(string texName, string packageName = KWord.PkgUnityObj)
    {
        var package = YooAssets.TryGetPackage(packageName);
        if (package != null)
        {
            var loadData = package.LoadAssetSync<GameObject>(texName);
            if (loadData != null && loadData.AssetObject is Texture2D)
            {
                Texture2D imgTex = loadData.AssetObject as Texture2D;

                return imgTex;
            }

        }

        return null;

    }


}
