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
- **NVMe SSD**：PCIe接口，性能最高

## 磁盘设备命名
```bash
/dev/sda    # 第一个SATA/SCSI磁盘
/dev/sdb    # 第二个磁盘
/dev/sda1   # 第一个磁盘第一个分区
/dev/nvme0n1  # NVMe磁盘
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
- **xfs**：高性能日志文件系统
- **btrfs**：现代写时复制文件系统

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

# 6. 磁盘配额

## 启用磁盘配额
```bash
# 修改fstab启用配额
/dev/sdb1  /mnt/data  ext4  usrquota,grpquota  0  2

# 重新挂载
mount -o remount /mnt/data

# 初始化配额数据库
quotacheck -cug /mnt/data

# 启用配额
quotaon /mnt/data
```

## 设置用户配额
```bash
# 编辑用户配额
edquota username

# 查看配额使用
repquota /mnt/data
```

# 7. LVM逻辑卷管理

## LVM基本概念
- **PV**：物理卷，底层物理磁盘
- **VG**：卷组，物理卷集合
- **LV**：逻辑卷，用户可见分区

## LVM操作
```bash
# 创建物理卷
pvcreate /dev/sdb1

# 创建卷组
vgcreate vg_data /dev/sdb1

# 创建逻辑卷
lvcreate -L 10G -n lv_data vg_data

# 创建文件系统
mkfs.ext4 /dev/vg_data/lv_data
```

# 8. 实践练习

## 磁盘管理练习
```bash
# 1. 查看磁盘信息
lsblk
fdisk -l

# 2. 查看挂载信息
df -h
mount

# 3. 查看目录大小
du -sh /var/log
```

## 分区和挂载练习
```bash
# 1. 创建分区
fdisk /dev/sdb

# 2. 创建文件系统
mkfs.ext4 /dev/sdb1

# 3. 挂载分区
mkdir /mnt/test
mount /dev/sdb1 /mnt/test

# 4. 验证挂载
df -h /mnt/test
```

# 9. 课后作业

## 1. 磁盘管理实践
1. 查看系统中所有磁盘和分区信息
2. 练习磁盘分区操作
3. 创建和挂载文件系统
4. 配置开机自动挂载

## 2. 高级磁盘管理
1. 学习LVM逻辑卷管理
2. 配置磁盘配额
3. 练习磁盘性能测试
4. 了解RAID磁盘阵列

通过本章学习，你应该能够：
1. 理解磁盘和分区基本概念
2. 熟练使用磁盘管理工具
3. 掌握文件系统创建和挂载
4. 学会LVM逻辑卷管理
5. 配置磁盘配额和自动挂载
