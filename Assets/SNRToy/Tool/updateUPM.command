#!/bin/bash

# 获取脚本所在目录
script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# 返回到SNRPkg的根目录
cd "$script_dir/../../.."


branch_name="upm"
prefix="Assets/SNRToy"

# 检查分支是否存在
if git show-ref --quiet --heads "$branch_name"; then
    echo "Branch $branch_name already exists. Merging..."
    # 合并到已存在的分支
    git subtree add --prefix="$prefix" "$branch_name"
else
    echo "Branch $branch_name does not exist. Creating..."
    # 创建新分支
    git subtree split --prefix="$prefix" --branch="$branch_name"
fi