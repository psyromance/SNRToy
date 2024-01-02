#!/bin/bash
#使用时需单独复制该脚本的副本在当前目录且不把复制的加入git 进行使用,不然因为该脚本加入了git管理直接使用会造成git无法成功

branch_name="upm"
prefix="Assets/SNRToy"

# 获取当前脚本所在目录
script_dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# 切换到仓库根目录
cd "$script_dir"/../..

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
