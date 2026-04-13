---
Xref: linux/chapter-09
title: "Linux系统进程管理"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-09
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
Layout: /_layout.cshtml
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
ps -ef

# 显示进程树
ps axjf

# 自定义输出
ps -eo pid,ppid,cmd,%mem,%cpu
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

## htop命令
```bash
# 安装htop
sudo yum install htop

# 运行htop
htop
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

# 查找僵尸进程
ps aux | awk '$8 ~ /^Z/ { print $2 }'
```

# 4. 进程控制

## 前台和后台进程
```bash
# 后台运行程序
command &

# 查看后台作业
jobs

# 后台进程转到前台
fg %1

# 前台进程转到后台
Ctrl + z
bg %1
```

## 终止进程
```bash
# 终止进程
kill PID

# 强制终止
kill -9 PID

# 按名称终止
killall process_name
pkill process_name

# 发送信号
kill -l          # 列出所有信号
kill -TERM PID   # 正常终止
kill -HUP PID    # 重启进程
```

# 5. 进程优先级

## nice值
```bash
# nice值范围: -20(最高) 到 19(最低)
# 默认nice值: 0

# 以指定优先级启动程序
nice -n 10 command

# 修改运行中进程优先级
renice 5 PID
```

# 6. 守护进程

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

# 7. 实践练习

## 进程查看练习
```bash
# 1. 查看所有进程
ps aux

# 2. 查找特定进程
ps aux | grep sshd

# 3. 查看进程树
pstree

# 4. 实时监控进程
top
```

## 进程管理练习
```bash
# 1. 后台运行程序
sleep 300 &

# 2. 查看后台作业
jobs

# 3. 终止后台进程
kill %1

# 4. 调整进程优先级
nice -n 10 sleep 60 &
renice 5 $!
```

## 服务管理练习
```bash
# 1. 查看sshd服务状态
systemctl status sshd

# 2. 查看所有运行的服务
systemctl list-units --type=service --state=running
```

# 8. 课后作业

## 1. 进程管理实践
1. 使用ps命令查看系统所有进程
2. 使用top命令监控系统资源使用
3. 练习前后台进程切换
4. 学习使用kill命令终止进程

## 2. 服务管理
1. 查看系统中运行的服务
2. 练习启停服务操作
3. 配置服务开机自动启动
4. 查看服务日志信息

通过本章学习，你应该能够：
1. 理解进程的基本概念和属性
2. 熟练使用各种进程查看命令
3. 掌握进程控制和管理方法
4. 理解进程优先级和调度
5. 学会管理系统服务和守护进程