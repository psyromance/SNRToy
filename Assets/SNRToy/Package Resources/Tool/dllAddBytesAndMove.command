#!/bin/bash

# 放路径Proj/Tool/sh
# 切换工作目录到脚本所在目录
cd "$(dirname "$0")"

# 定义目标文件夹路径
targetFolder="../HybridCLRData/HotUpdateDlls/iOS"

# 获取脚本所在目录的同级目录（即 Golden 的上一级目录）
parentFolder=$(realpath "..")

# 构建完整的目标路径
fullTargetPath="$parentFolder/$targetFolder"

# 打印目录信息
echo "脚本所在目录: $(pwd)"
echo "父目录: $parentFolder"
echo "目标文件夹完整路径: $fullTargetPath"

# 遍历目标文件夹下扩展名为 .dll 的文件
find "$fullTargetPath" -type f -name "*.dll" -print0 | while IFS= read -r -d $'\0' file; do
    echo "正在处理文件: $file"
    mv "$file" "${file}.bytes"
done

# 定义目标文件夹路径（.bytes 文件）
bytesFolder="$parentFolder/../Assets/AllToHot/HotCode"

# 创建目标文件夹（如果不存在）
mkdir -p "$bytesFolder"

# 打印目录信息
echo "目标文件夹完整路径 (.bytes 文件): $bytesFolder"

# 遍历目标文件夹下扩展名为 .bytes 的文件
find "$fullTargetPath" -type f -name "*.bytes" -print0 | while IFS= read -r -d $'\0' file; do
    # 构建目标文件的路径
    destination="$bytesFolder/$(basename "$file")"
    
    # 如果目标文件存在，先删除
    if [ -e "$destination" ]; then
        rm "$destination"
    fi

    # 进行拷贝
    cp "$file" "$destination"

    # 删除源文件夹中的 .bytes 文件
    rm "$file"
done
