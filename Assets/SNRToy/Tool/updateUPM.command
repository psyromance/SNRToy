#!/bin/bash

branch_name="upm"
prefix="Assets/SNRToy"

# 检查目标目录是否存在
if [ ! -d "$prefix" ]; then
    echo "Directory $prefix does not exist. Creating..."
    # 创建目录
    mkdir -p "$prefix"
    # 初始化目录，可以根据需要执行其他初始化操作
    # git init "$prefix"  # 如果需要在目录中初始化一个新的 Git 仓库
fi

# 检查分支是否存在
if git show-ref --quiet --heads "$branch_name"; then
    echo "Branch $branch_name already exists. Merging..."

    # 在已存在的分支上执行 subtree merge
    git checkout "$branch_name"
    git checkout main -- "$prefix"
    git commit -m "Sync changes from main to $branch_name"
else
    echo "Branch $branch_name does not exist. Creating..."
    # 创建新分支
    git subtree split --prefix="$prefix" --branch="$branch_name"
fi
