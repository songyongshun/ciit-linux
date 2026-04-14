---
Xref: linux/chapter-04
title: "Linux文件目录结构"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-05
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Linux文件目录结构

# 1. 文件系统层次结构标准（FHS）

## 什么是FHS
- **FHS**：Filesystem Hierarchy Standard，文件系统层次结构标准
- **作用**：定义Linux系统中目录和文件的标准组织结构
- **目的**：确保不同Linux发行版之间的一致性和兼容性

## FHS目录结构概述
```bash
/                    # 根目录，所有文件系统的起点
├── bin/            # 基本用户命令
├── boot/           # 启动相关文件
├── dev/            # 设备文件
├── etc/            # 系统配置文件
├── home/           # 用户主目录
├── lib/            # 系统库文件
├── media/          # 可移动媒体挂载点
├── mnt/            # 临时挂载点
├── opt/            # 可选软件包
├── proc/           # 进程和系统信息
├── root/           # root用户主目录
├── run/            # 运行时数据
├── sbin/           # 系统管理命令
├── srv/            # 服务数据
├── sys/            # 系统设备信息
├── tmp/            # 临时文件
├── usr/            # 用户程序和数据
└── var/            # 变量数据（日志、缓存等）
```

# 2. 根目录（/）

## 根目录特点
- **根目录**：文件系统的最顶层目录
- **作用**：所有其他目录的起点
- **权限**：通常只有root用户可以在此目录下创建文件

## 查看根目录
```bash
# 查看根目录内容
ls -l /

# 查看根目录详细信息
ls -la /

# 查看根目录大小
du -sh /
```

# 3. /bin 目录

## /bin 目录作用
- **含义**：Binary的缩写
- **内容**：基本的用户命令和可执行文件
- **特点**：系统启动和运行所必需的命令

## 常见命令
```bash
# 查看/bin目录内容
ls /bin/

# 常见命令示例
/bin/ls        # 列出目录内容
/bin/cp        # 复制文件
/bin/mv        # 移动文件
/bin/rm        # 删除文件
/bin/cat       # 查看文件内容
/bin/grep      # 文本搜索
/bin/find      # 查找文件
/bin/tar       # 打包和解压
```

## /bin vs /usr/bin
- **/bin**：系统启动和基本操作必需的命令
- **/usr/bin**：用户应用程序和工具

# 4. /boot 目录

## /boot 目录作用
- **内容**：启动相关文件
- **重要文件**：
  - vmlinuz：内核文件
  - initrd：初始RAM磁盘
  - grub/：GRUB引导程序配置

## 查看/boot目录
```bash
# 查看/boot目录内容
ls -l /boot/

# 查看内核版本
uname -r

# 查看可用的内核
ls /boot/vmlinuz*

# 查看GRUB配置
cat /boot/grub2/grub.cfg
```

## 启动文件说明
```bash
/boot/vmlinuz-4.18.0-348.el8.x86_64    # 内核文件
/boot/initramfs-4.18.0-348.el8.x86_64.img  # 初始RAM磁盘
/boot/grub2/                            # GRUB配置目录
/boot/grub2/grub.cfg                   # GRUB配置文件
/boot/efi/                             # EFI系统分区
```

# 5. /dev 目录

## /dev 目录作用
- **含义**：Device的缩写
- **内容**：设备文件
- **类型**：字符设备、块设备、伪设备

## 设备文件类型
```bash
# 字符设备（按字符传输）
/dev/ttyS0        # 串行端口
/dev/null         # 空设备
/dev/zero         # 零设备

# 块设备（按块传输）
/dev/sda          # 硬盘
/dev/sda1         # 硬盘分区
/dev/cdrom        # 光驱

# 伪设备
/dev/random       # 随机数生成器
/dev/urandom      # 非阻塞随机数生成器
```

## 查看设备文件
```bash
# 查看/dev目录内容
ls /dev/

# 查看磁盘设备
ls /dev/sd*

# 查看字符设备
ls /dev/tty*

# 查看设备信息
cat /proc/partitions
```

# 6. /etc 目录

## /etc 目录作用
- **含义**：Et Cetera（等等）的缩写
- **内容**：系统配置文件
- **重要性**：系统管理和配置的核心目录

## 重要配置文件
```bash
/etc/passwd       # 用户账户信息
/etc/group        # 用户组信息
/etc/shadow       # 用户密码
/etc/fstab        # 文件系统挂载配置
/etc/hosts        # 主机名解析
/etc/resolv.conf  # DNS配置
/etc/hostname     # 系统主机名
/etc/sudoers      # sudo权限配置
/etc/yum.conf     # YUM配置
/etc/ssh/sshd_config  # SSH服务配置
```

## 网络配置文件
```bash
/etc/sysconfig/network-scripts/  # 网络接口配置
/etc/hosts                       # 本地主机名解析
/etc/resolv.conf                 # DNS服务器配置
/etc/nsswitch.conf               # 名称服务切换配置
```

## 服务配置文件
```bash
/etc/systemd/system/    # systemd服务配置
/etc/init.d/           # SysV init脚本
/etc/xinetd.d/         # xinetd服务配置
```

# 7. /home 目录

## /home 目录作用
- **内容**：普通用户的主目录
- **结构**：每个用户一个子目录
- **权限**：用户对自己的主目录有完全控制权

## 用户目录结构
```bash
/home/
├── user1/           # 用户1的主目录
│   ├── Documents/   # 文档
│   ├── Downloads/   # 下载文件
│   ├── Pictures/    # 图片
│   ├── Videos/      # 视频
│   └── .bashrc      # Bash配置文件
├── user2/           # 用户2的主目录
└── ...
```

## 隐藏文件和目录
```bash
# 查看用户主目录的隐藏文件
ls -la ~

# 常见隐藏文件
.bashrc           # Bash shell配置
.bash_profile     # Bash登录配置
.profile          # 用户环境配置
.vimrc            # Vim编辑器配置
.ssh/             # SSH密钥和配置
```

# 8. /lib 和 /lib64 目录

## /lib 目录作用
- **含义**：Library的缩写
- **内容**：系统库文件
- **类型**：共享库（.so文件）

## /lib vs /lib64
- **/lib**：32位系统库
- **/lib64**：64位系统库

## 常见库文件
```bash
/lib/libc.so.6      # C标准库
/lib/libm.so.6      # 数学库
/lib/libpthread.so.0  # 线程库
/lib/ld-linux.so.2  # 动态链接器
```

## 查看库依赖
```bash
# 查看程序依赖的库
ldd /bin/ls

# 查看库文件
ls /lib/

# 查找特定库
find /lib -name "*libc*"
```

# 9. /media 和 /mnt 目录

## /media 目录
- **作用**：可移动媒体的自动挂载点
- **设备**：USB驱动器、CD-ROM、DVD等
- **特点**：通常由桌面环境自动管理

## /mnt 目录
- **作用**：临时挂载点
- **用途**：手动挂载文件系统
- **特点**：需要手动管理

## 挂载示例
```bash
# 挂载USB驱动器到/mnt
sudo mount /dev/sdb1 /mnt

# 挂载ISO文件
sudo mount -o loop image.iso /mnt

# 查看挂载点
mount

# 卸载设备
sudo umount /mnt
```

# 10. /opt 目录

## /opt 目录作用
- **含义**：Optional的缩写
- **内容**：可选的第三方软件包
- **特点**：独立安装的软件

## 软件安装示例
```bash
/opt/
├── google/         # Google软件
├── jetbrains/      # JetBrains工具
├── oracle/         # Oracle软件
└── custom-app/     # 自定义应用程序
```

## 安装软件到/opt
```bash
# 创建软件目录
sudo mkdir /opt/myapp

# 解压软件包
sudo tar -zxvf package.tar.gz -C /opt/myapp

# 创建符号链接
sudo ln -s /opt/myapp/bin/myapp /usr/local/bin/myapp
```

# 11. /proc 目录

## /proc 目录特点
- **类型**：虚拟文件系统
- **内容**：进程和系统信息
- **特点**：运行时生成，不占用磁盘空间

## 重要文件和目录
```bash
/proc/cpuinfo       # CPU信息
/proc/meminfo       # 内存信息
/proc/version       # 内核版本
/proc/loadavg       # 系统负载
/proc/uptime        # 系统运行时间
/proc/mounts        # 挂载信息
/proc/partitions    # 分区信息
/proc/interrupts    # 中断信息
```

## 进程信息
```bash
/proc/1/            # PID为1的进程信息
/proc/self/         # 当前进程信息
/proc/[PID]/        # 特定进程信息
```

## 查看系统信息
```bash
# 查看CPU信息
cat /proc/cpuinfo

# 查看内存信息
cat /proc/meminfo

# 查看系统版本
cat /proc/version

# 查看系统负载
cat /proc/loadavg
```

# 12. /root 目录

## /root 目录特点
- **内容**：root用户的主目录
- **权限**：只有root用户可以访问
- **位置**：通常在根目录下

## root目录内容
```bash
/root/
├── .bashrc         # root的Bash配置
├── .ssh/           # root的SSH配置
├── scripts/        # root脚本
└── downloads/      # root下载文件
```

## 访问root目录
```bash
# 切换到root用户
sudo su -

# 查看root目录
ls -la /root/

# 注意：普通用户无法访问root目录
```

# 13. /run 目录

## /run 目录作用
- **含义**：运行时数据
- **内容**：系统运行时的临时文件
- **特点**：系统启动时创建，关机时清除

## 常见内容
```bash
/run/lock/          # 锁文件
/run/log/           # 日志文件
/run/systemd/       # systemd运行时数据
/run/user/          # 用户运行时数据
```

# 14. /sbin 目录

## /sbin 目录作用
- **含义**：System Binary的缩写
- **内容**：系统管理命令
- **权限**：通常需要root权限

## 常见命令
```bash
/sbin/ifconfig      # 网络接口配置
/sbin/iptables      # 防火墙配置
/sbin/reboot        # 重启系统
/sbin/shutdown      # 关闭系统
/sbin/fdisk         # 分区工具
/sbin/mkfs          # 文件系统创建
/sbin/service       # 服务管理
```

# 15. /srv 目录

## /srv 目录作用
- **含义**：Service的缩写
- **内容**：服务数据文件
- **用途**：网络服务的数据存储位置

## 常见服务数据
```bash
/srv/www/          # Web服务器数据
/srv/ftp/          # FTP服务器数据
/srv/git/          # Git仓库
/srv/samba/        # Samba共享数据
```

# 16. /sys 目录

## /sys 目录特点
- **类型**：虚拟文件系统
- **内容**：内核和设备信息
- **作用**：提供设备和驱动程序的接口

## /sys 目录结构
```bash
/sys/class/         # 设备类别
/sys/block/         # 块设备
/sys/devices/       # 设备树
/sys/fs/            # 文件系统信息
/sys/kernel/        # 内核参数
/sys/module/        # 模块信息
```

# 17. /tmp 目录

## /tmp 目录作用
- **含义**：Temporary的缩写
- **内容**：临时文件
- **特点**：系统重启时通常会被清空

## 临时文件管理
```bash
# 查看/tmp目录
ls -l /tmp/

# 创建临时文件
echo "test" > /tmp/testfile

# 查看临时文件大小
du -sh /tmp/

# 清理临时文件（通常由系统自动处理）
sudo rm -rf /tmp/*
```

# 18. /usr 目录

## /usr 目录作用
- **含义**：Unix System Resources的缩写
- **内容**：用户程序和数据
- **特点**：包含大部分用户应用程序

## /usr 目录结构
```bash
/usr/bin/          # 用户命令
/usr/sbin/         # 系统管理命令
/usr/lib/          # 用户库文件
/usr/local/        # 本地安装的软件
/usr/share/        # 共享数据
/usr/include/      # 头文件
/usr/src/          # 源代码
```

## /usr/local 目录
```bash
/usr/local/bin/    # 本地用户命令
/usr/local/sbin/   # 本地系统管理命令
/usr/local/lib/    # 本地库文件
/usr/local/share/  # 本地共享数据
```

# 19. /var 目录

## /var 目录作用
- **含义**：Variable的缩写
- **内容**：变量数据
- **特点**：内容经常变化的文件

## /var 目录结构
```bash
/var/log/          # 系统日志
/var/cache/        # 应用程序缓存
/var/lib/          # 应用程序数据
/var/spool/        # 队列文件
/var/tmp/          # 临时文件（重启不删除）
/var/run/          # 运行时数据
```

## 日志文件管理
```bash
# 查看系统日志
ls /var/log/

# 查看特定日志
tail -f /var/log/messages

# 清理日志文件
sudo journalctl --vacuum-time=7d

# 查看日志大小
du -sh /var/log/
```

# 20. 实践练习

## 目录结构探索
```bash
# 1. 查看整个文件系统结构
tree -d -L 2 /

# 2. 查看各目录大小
du -sh /*

# 3. 查看隐藏文件
ls -la /etc/

# 4. 查看设备文件
ls /dev/sd*

# 5. 查看进程信息
ls /proc/ | head -10
```

## 文件系统信息
```bash
# 1. 查看挂载信息
mount

# 2. 查看磁盘使用情况
df -h

# 3. 查看inode使用情况
df -i

# 4. 查看文件系统类型
lsblk -f
```

## 配置文件管理
```bash
# 1. 查看网络配置
cat /etc/hosts

# 2. 查看用户配置
cat /etc/passwd | head -5

# 3. 查看服务配置
ls /etc/systemd/system/

# 4. 查看日志配置
cat /etc/rsyslog.conf
```

# 21. 课后作业

## 1. 目录结构分析
1. 绘制当前系统的目录结构图
2. 分析各目录的用途和重要性
3. 记录各目录的大小和文件数量

## 2. 配置文件管理
1. 查看并理解/etc/passwd文件格式
2. 查看/etc/fstab文件，了解挂载配置
3. 查看/etc/hosts文件，了解主机名解析

## 3. 日志文件分析
1. 查看/var/log目录下的日志文件
2. 分析系统日志的内容和格式
3. 学习使用日志查看工具

## 4. 文件系统管理
1. 查看系统中所有挂载的文件系统
2. 了解不同文件系统的特点
3. 练习挂载和卸载操作

# 22. 故障排除

## 常见问题及解决方法

### 1. 磁盘空间不足
```bash
# 查看磁盘使用情况
df -h

# 查找大文件
find / -type f -size +100M 2>/dev/null

# 清理临时文件
sudo rm -rf /tmp/*
sudo journalctl --vacuum-time=7d
```

### 2. 配置文件错误
```bash
# 备份配置文件
sudo cp /etc/fstab /etc/fstab.bak

# 检查配置文件语法
sudo mount -a

# 恢复备份
sudo cp /etc/fstab.bak /etc/fstab
```

### 3. 权限问题
```bash
# 查看文件权限
ls -l /path/to/file

# 修改文件权限
sudo chmod 755 /path/to/file

# 修改文件所有者
sudo chown user:group /path/to/file
```

### 4. 服务启动失败
```bash
# 查看服务状态
sudo systemctl status service_name

# 查看服务日志
sudo journalctl -u service_name

# 检查配置文件
cat /etc/systemd/system/service_name.service
```

# 23. 扩展学习

## 文件系统类型
```bash
# 查看支持的文件系统
cat /proc/filesystems

# 查看当前使用的文件系统
df -T

# 了解不同文件系统的特点
# ext4: 传统Linux文件系统
# xfs: 高性能文件系统
# btrfs: 现代文件系统，支持快照
```

## 磁盘管理
```bash
# 查看磁盘信息
lsblk

# 查看分区信息
fdisk -l

# 创建文件系统
sudo mkfs.ext4 /dev/sdb1

# 挂载文件系统
sudo mount /dev/sdb1 /mnt
```

通过本章学习，你应该能够：
1. 理解Linux文件系统层次结构标准（FHS）
2. 熟悉各个重要目录的作用和内容
3. 掌握文件系统的基本管理操作
4. 学会查看和分析系统配置文件
5. 理解日志文件的作用和管理方法
6. 为系统管理和维护打下坚实基础
