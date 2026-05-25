---
Xref: linux/chapter-11
title: "Linux磁盘管理"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-11
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Linux磁盘管理

# 1. 磁盘基础概念

## 磁盘类型
- **机械硬盘(HDD)**：传统磁盘，容量大，速度较慢
- **固态硬盘(SSD)**：闪存存储，速度快，价格较高

## 概念
- **磁盘**：物理存储设备
- **分区**：磁盘上的逻辑划分，每个分区可以独
立使用
- **文件系统**：分区上的数据组织结构，如ext4、xfs等
- **挂载**：将分区连接到文件系统树中，使其可访问
- **接口**：磁盘与计算机连接的方式，如SATA、NVMe等

## Linux磁盘使用
在 Linux 中，让一块新硬盘投入使用，通常需要依次执行以下三个步骤：
- 分区：使用 fdisk /dev/sdb 划分出 /dev/sdb1。
- 格式化：使用 mkfs.ext4 /dev/sdb1 创建文件系统。
- 挂载：使用 mount /dev/sdb1 /data 挂载到目录使用。

## 磁盘设备命名
```bash
/dev/sda    # 第一个SATA磁盘
/dev/sda1   # 第一个SATA磁盘第一个分区
/dev/sdb    # 第二个SATA磁盘

/dev/nvme0n1  # 第一个NVMe磁盘
/dev/nvme0n1p1 # 第一个NVMe磁盘第一个分区
/dev/nvme1n1  # 第二个NVMe磁盘

# n1: namespace 1, namespace类似于硬件层面的分区。绝大多数消费级固态硬盘都只有一个命名空间，所以通常固定为 n1
```

# 2. 磁盘信息查看

## 查看磁盘列表
```bash
# 查看块设备
lsblk

# 查看磁盘分区
fdisk -l

# 查看文件系统
df -h

# 查看目录大小
du -sh /path
```

# 3. 磁盘分区

## fdisk分区工具
修改磁盘的分区表，规划出每块空间(/dev/sda1等)的起始和结束位置。

```bash
# 对磁盘进行分区
fdisk /dev/sdb

# fdisk命令
n  # 新建分区
p  # 主分区
e  # 扩展分区
d  # 删除分区
p  # 显示分区表
w  # 保存退出
q  # 不保存退出
```

# 4. 文件系统

## 常见文件系统
- **ext4**：Linux默认文件系统
- **ntfs**：Windows默认文件系统
- **xfs**：高性能文件系统，适合大文件


## 创建文件系统
```bash
# 创建ext4文件系统
mkfs.ext4 /dev/sdb1

# 创建xfs文件系统
mkfs.xfs /dev/sdb1
```

# 5. 挂载管理

## 手动挂载
```bash
# 创建挂载点
mkdir /mnt/data

# 挂载分区
mount /dev/sdb1 /mnt/data

# 查看挂载信息
mount

# 卸载分区
umount /mnt/data
```

## 自动挂载
```bash
# 编辑fstab文件
vi /etc/fstab

# 添加条目
/dev/sdb1  /mnt/data  ext4  defaults  0  2

# 测试挂载
mount -a
```

通过本章学习，你应该能够：
1. 理解磁盘和分区基本概念
2. 熟练使用磁盘管理工具
3. 掌握文件系统创建和挂载
