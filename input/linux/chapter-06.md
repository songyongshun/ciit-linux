---
Xref: linux/chapter-06
title: "Linux软件安装"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-02
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
Layout: /_layout.cshtml
---

# Linux软件安装

# 1. 软件包管理器基础

## 什么是软件包管理器
- **软件包管理器**：用于安装、更新、配置和删除软件的工具
- **作用**：简化软件管理，自动处理依赖关系
- **优势**：比手动编译安装更方便、更安全

## Linux主要包管理器
- **APT**：Advanced Package Tool，Debian/Ubuntu系统的包管理器
- **YUM**：Yellowdog Updater Modified，基于RPM的高级管理器

# 2. 软件源设置

## 查看系统包管理器
```bash
# 检查系统使用的包管理器
which apt
which yum
```

## 什么是软件源
- **软件源（Repository）**：存放软件包的服务器
- **作用**：提供软件下载和更新的来源
- **类型**：官方源、第三方源、本地源
## 查看当前软件源
```bash
# 查看YUM软件源列表
yum repolist
```

由于CentOS 8已经停止维护，建议使用阿里云的镜像源来替代默认的软件源，以获得更快的软件安装和更新速度。以下是配置阿里云镜像源的步骤：
```bash
# 1. 备份原有的软件源配置文件
sudo cp /etc/yum.repos.d/CentOS-Base.repo /etc/yum.repos.d/CentOS-Base.repo.bak
# 2. 下载阿里云的CentOS 8镜像源配置文件
sudo wget -O /etc/yum.repos.d/CentOS-Base.repo https://mirrors.aliyun.com/repo/Centos-vault-8.5.2111.repo 
# 3. 清理YUM缓存并生成新的缓存
sudo yum clean all
sudo yum makecache
```

## 添加EPEL软件源
```bash
# 安装EPEL源（Extra Packages for Enterprise Linux）
sudo yum install epel-release

```

## 查看当前软件源
```bash
# 查看YUM软件源列表
yum repolist

# repo id            repo name
AppStream          CentOS-8.5.2111 - AppStream - mirrors.aliyun.com # 应用程序、开发工具、桌面环境
base               CentOS-8.5.2111 - Base - mirrors.aliyun.com # 系统核心组件（内核、基础工具）
epel               Extra Packages for Enterprise Linux 8 - x86_64 # 第三方常用软件（如 htop, nginx）
epel-modular       Extra Packages for Enterprise Linux Modular 8 - x86_64 # EPEL模块化源（提供模块化的软件包）
extras             CentOS-8.5.2111 - Extras - mirrors.aliyun.com # 额外软件包（提供一些不常用的软件包）

# 查看详细的软件源信息
yum repolist all
```


# 3. 管理软件包
## 安装软件包
```bash
# 使用YUM安装软件
sudo yum install package_name

# 安装多个软件
sudo yum install package1 package2 package3
```

## 搜索软件包
```bash
# 搜索可用的软件包
yum search keyword

# 比如：搜索Firefox浏览器
yum search firefox
```

## 查看已安装的软件
```bash
# 列出所有已安装的软件
yum list installed

# 查看特定软件是否已安装
yum list installed | grep package_name

# 比如：查看是否安装了vim编辑器
yum list installed | grep vim
```

## 查看软件包信息
```bash
# 查看软件包详细信息
yum info package_name

# 比如：查看vim编辑器的信息
yum info vim
```


# 4. 软件更新和升级

## 更新软件包列表
```bash
# 更新YUM软件包列表
sudo yum check-update
```

## 升级单个软件
```bash
# 升级特定软件
sudo yum update package_name
```

## 升级所有软件
```bash
# 升级系统中所有可更新的软件
sudo yum update
```

# 5. 卸载软件

## 卸载单个软件
```bash
# 卸载软件（保留配置文件）
sudo yum remove package_name
```

## 卸载软件及其依赖
```bash
# 卸载软件并自动移除不再需要的依赖
sudo yum autoremove package_name
```

## 清理缓存
```bash
# 清理YUM缓存
sudo yum clean all
```

# 6. 实践练习

## 安装常用工具
```bash
# 1. 安装wget（用于下载文件）
sudo yum install wget

# 2. 安装htop（系统监控工具）
sudo yum install htop

# 3. 安装git（版本控制系统）
sudo yum install git
```

## 配置软件源
```bash
# 1. 安装EPEL源
sudo yum install epel-release

# 2. 验证EPEL源
yum repolist | grep epel

# 3. 搜索EPEL源中的软件
yum --enablerepo=epel search package_name
```

## 软件管理练习
```bash
# 1. 查看已安装的软件数量
yum list installed | wc -l

# 2. 查找特定类型的软件
yum list installed | grep -i editor

# 3. 查看某个软件的详细信息
yum info vim
```


通过本章学习，你应该能够：
1. 理解Linux软件包管理的基本概念
2. 熟练使用YUM进行软件管理
3. 配置和管理软件源
4. 解决常见的软件安装问题
5. 为后续的Linux学习和使用打下坚实基础