---
Xref: linux/chapter-09
title: "Linux系统进程管理"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-09
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Linux系统进程管理

# 1. 进程基础概念

## 什么是进程
- **进程**：正在运行的程序实例
- **特点**：拥有独立的内存空间、资源和执行状态
- **生命周期**：创建、就绪、运行、阻塞、终止

## 进程属性
- **PID**：进程ID，唯一标识
- **PPID**：父进程ID
- **UID/GID**：用户/组ID
- **状态**：运行(R)、睡眠(S)、停止(T)、僵尸(Z)

# 2. 查看进程

## ps命令
```bash
# 查看当前终端进程
ps

# 查看所有进程
ps aux
```

## top命令
```bash
# 实时监控进程
top

# top快捷键
P  # 按CPU排序
M  # 按内存排序
T  # 按时间排序
k  # 杀死进程
q  # 退出
```

## pstree命令
```bash
# 显示进程树
pstree

# 显示PID
pstree -p

# 显示用户
pstree -u
```

# 3. 进程状态

## 进程状态说明
```
R  Running      运行中
S  Sleeping     可中断睡眠
D  Disk Sleep   不可中断睡眠
T  Stopped      停止
Z  Zombie       僵尸进程
```

## 查看进程状态
```bash
# 查看所有进程状态
ps -eo pid,stat,cmd
```

# 4. 进程控制

## 前台和后台进程
```bash
# 后台运行程序
command &

# 比如
sleep 300 &
# 查看后台作业
jobs

```

## 终止进程
```bash
# 终止进程
kill PID

# 强制终止
kill -9 PID

# 按名称终止
killall process_name
```

# 5. 守护进程

## 什么是守护进程
- 后台运行的特殊进程
- 脱离终端控制
- 随系统启动而启动
- 提供系统服务

## systemd服务管理
```bash
# 启动服务
systemctl start service_name

# 停止服务
systemctl stop service_name

# 重启服务
systemctl restart service_name

# 查看服务状态
systemctl status service_name

# 设置开机启动
systemctl enable service_name
```

通过本章学习，你应该能够：
1. 理解进程的基本概念和属性
2. 熟练使用各种进程查看命令
3. 掌握进程控制和管理方法
4. 学会管理系统服务和守护进程
