using System.IO;
using YooAsset.Editor;

[DisplayName("寻址地址文件名带扩展名")]

public class AddressByFileNameWithExt : IAddressRule
{
    string IAddressRule.GetAssetAddress(AddressRuleData data)
    {
        string address = Path.GetFileName(data.AssetPath);
        return address;
    }
}
