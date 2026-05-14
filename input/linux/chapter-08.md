---
Xref: linux/chapter-08
title: "Linux系统监控和性能优化"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-06
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Linux系统监控和性能优化

# 1. 系统监控概述

## 什么是系统监控
- **系统监控**：持续观察和记录系统资源使用情况的过程
- **目的**：确保系统稳定运行，及时发现和解决问题
- **重要性**：预防系统故障，优化性能，提高资源利用率

## 监控指标分类
- **CPU使用率**：处理器负载情况
- **内存使用率**：RAM使用情况
- **磁盘I/O**：磁盘读写性能
- **网络I/O**：网络流量和连接
- **进程状态**：运行中的进程信息
- **系统负载**：整体系统压力

# 2. CPU监控

## 查看CPU信息
```bash
# 查看CPU基本信息
cat /proc/cpuinfo

# 查看CPU使用情况
top
```

## CPU使用率分析
```bash
# 查看CPU详细信息
lscpu
```

## CPU负载监控
```bash
# 查看系统负载
uptime
```

## CPU性能优化
```bash
# 查找CPU占用高的进程，默认是按PID排序的，可以加上排序参数
ps -aux --sort=-%cpu | head -10

# 监控特定进程的CPU使用
top -p PID
```

# 3. 内存监控

## 查看内存信息
```bash
# 查看内存使用情况
free -h

# 查看详细内存信息
cat /proc/meminfo

# 使用top查看内存使用
top
```

## 内存使用分析
```bash
# 查看内存使用排名
ps aux --sort=-%mem | head -10
```

## 交换空间监控
```bash
# 查看交换空间使用
swapon -s

# 查看交换分区详细信息
cat /proc/swaps
```

# 4. 磁盘监控

## 查看磁盘使用情况
```bash
# 查看磁盘空间使用
df -h

# 查看目录大小
du -sh /path/to/directory

# 查看磁盘分区
fdisk -l
```

## 磁盘优化
```bash
# 清理磁盘空间
sudo apt autoremove  # Ubuntu/Debian
sudo yum autoremove  # CentOS/RHEL

# 查找大文件
find / -type f -size +100M 2>/dev/null

# 清理日志文件
sudo journalctl --vacuum-time=7d
```

# 5. 网络监控

## 查看网络接口
```bash
# 查看网络接口信息
ip addr show

# 简写查看网络接口
ip a
```

## 网络流量监控
```bash
# 使用iftop监控网络流量（需要安装）
iftop
```

## 网络连接监控
```bash
# 查看网络连接
netstat -tuln

# 查看进程网络连接（需要安装lsof）
lsof -i

# 监控网络连接数
netstat -an | grep ESTABLISHED | wc -l
```

## 网络性能测试
```bash
# 测试网络延迟
ping google.com

# 查看路由信息
route -n
ip route show
```

# 6. 进程监控

## 查看进程信息
```bash
# 查看所有进程
ps -aux

# 查看进程树
pstree

# 实时监控进程
top
```

## 进程状态分析
```bash
# 查看僵尸进程
ps aux | awk '$8 ~ /^Z/ { print $2 }'

# 查看进程打开的文件
lsof -p PID

# 查看进程环境变量
cat /proc/PID/environ | tr '\0' '\n'
```

## 进程管理
```bash
# 终止进程
kill PID
kill -9 PID
```

# 7. 日志监控

## 系统日志查看
```bash
# 查看系统日志
journalctl

# 查看特定服务日志
journalctl -u service_name

# 实时查看日志
journalctl -f
```

## 日志文件管理
```bash
# 查看日志文件大小
du -sh /var/log/*

# 清理旧日志
sudo journalctl --vacuum-time=7d
```

## 日志分析
```bash
# 查看错误日志
journalctl -p err

# 查看特定时间段日志
journalctl --since="2023-01-01" --until="2023-01-02"

# 查看启动日志
journalctl -b
```

通过本章学习，你应该能够：
1. 掌握Linux系统监控的基本方法
2. 熟练使用各种性能监控工具
3. 识别和分析系统性能瓶颈
4. 实施有效的性能优化措施
5. 建立完善的系统监控体系
6. 为系统稳定运行和性能优化打下坚实基础
