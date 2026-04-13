---
Xref: linux/chapter-08
title: "Linux系统监控和性能优化"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-06
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
Layout: /_layout.cshtml
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

# 查看CPU核心数
nproc

# 查看CPU使用情况
top

# 实时监控CPU使用
htop  # 需要安装
```

## CPU使用率分析
```bash
# 使用vmstat监控CPU
vmstat 1 5  # 每秒采样，共5次

# 使用sar监控CPU（需要安装sysstat）
sar -u 1 5

# 查看CPU详细信息
lscpu
```

## CPU负载监控
```bash
# 查看系统负载
uptime

# 查看负载详细信息
cat /proc/loadavg

# 使用w命令查看负载
w
```

## CPU性能优化
```bash
# 查找CPU占用高的进程
ps aux --sort=-%cpu | head -10

# 监控特定进程的CPU使用
top -p PID

# 调整进程优先级
nice -n 10 command
renice 5 PID
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

# 使用htop查看内存使用
htop
```

## 内存使用分析
```bash
# 查看内存使用排名
ps aux --sort=-%mem | head -10

# 查看进程内存详细信息
pmap PID

# 监控内存使用趋势
vmstat 1 10
```

## 交换空间监控
```bash
# 查看交换空间使用
swapon -s

# 查看交换分区详细信息
cat /proc/swaps

# 监控交换使用情况
vmstat -s
```

## 内存优化
```bash
# 清理缓存（需要root权限）
sync; echo 3 > /proc/sys/vm/drop_caches

# 调整内存参数
echo 1 > /proc/sys/vm/overcommit_memory

# 查看内存泄漏
valgrind --tool=memcheck program
```

# 4. 磁盘监控

## 查看磁盘使用情况
```bash
# 查看磁盘空间使用
df -h

# 查看目录大小
du -sh /path/to/directory

# 查看文件系统信息
lsblk -f

# 查看磁盘分区
fdisk -l
```

## 磁盘I/O监控
```bash
# 使用iostat监控磁盘I/O（需要安装sysstat）
iostat -x 1 5

# 使用iotop监控磁盘I/O（需要安装）
iotop

# 查看磁盘详细信息
cat /proc/diskstats
```

## 磁盘性能分析
```bash
# 测试磁盘读写性能
dd if=/dev/zero of=testfile bs=1G count=1 oflag=direct
dd if=testfile of=/dev/null bs=1G iflag=direct

# 查看磁盘队列长度
iostat -x 1 | grep -E "(Device|sda)"

# 监控磁盘使用趋势
df -h | tail -n +2 | awk '{print $5 " " $6}' | sort -nr
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

# 查看网络接口统计
cat /proc/net/dev

# 使用ifconfig查看网络接口
ifconfig

# 使用nmcli查看网络连接
nmcli device status
```

## 网络流量监控
```bash
# 使用iftop监控网络流量（需要安装）
iftop

# 使用nload监控网络流量（需要安装）
nload

# 使用sar监控网络（需要安装sysstat）
sar -n DEV 1 5
```

## 网络连接监控
```bash
# 查看网络连接
netstat -tuln

# 查看详细连接信息
ss -tuln

# 查看进程网络连接
lsof -i

# 监控网络连接数
netstat -an | grep ESTABLISHED | wc -l
```

## 网络性能测试
```bash
# 测试网络延迟
ping google.com

# 测试网络带宽
iperf3 -c server_ip

# 查看路由信息
route -n
ip route show
```

# 6. 进程监控

## 查看进程信息
```bash
# 查看所有进程
ps aux

# 查看进程树
pstree

# 实时监控进程
top

# 增强版进程监控
htop
```

## 进程状态分析
```bash
# 查看进程状态
ps -eo pid,ppid,cmd,%mem,%cpu --sort=-%mem | head -10

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

# 终止进程组
killall process_name

# 查看进程优先级
ps -eo pid,comm,nice

# 调整进程优先级
renice 10 PID
```

# 7. 系统负载监控

## 系统负载查看
```bash
# 查看系统负载
uptime

# 查看负载详细信息
cat /proc/loadavg

# 使用w命令查看负载
w

# 查看CPU使用率
sar -u 1 5
```

## 负载分析
```bash
# 查看负载组成
vmstat 1 5

# 查看进程对负载的贡献
ps aux --sort=-%cpu | head -10

# 查看I/O等待情况
iostat -x 1 5
```

## 负载优化
```bash
# 查找高负载原因
top -b -n1 | head -20

# 检查磁盘I/O
iostat -x 1 5

# 检查内存使用
free -h
```

# 8. 日志监控

## 系统日志查看
```bash
# 查看系统日志
journalctl

# 查看特定服务日志
journalctl -u service_name

# 实时查看日志
journalctl -f

# 查看内核日志
dmesg
```

## 日志文件管理
```bash
# 查看日志文件大小
du -sh /var/log/*

# 清理旧日志
sudo journalctl --vacuum-time=7d

# 配置日志轮转
cat /etc/logrotate.conf
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

# 9. 性能监控工具

## 综合监控工具
```bash
# 使用glances（需要安装）
glances

# 使用nmon（需要安装）
nmon

# 使用htop
htop

# 使用atop（需要安装）
atop
```

## 专业监控工具
```bash
# 使用sar（需要安装sysstat）
sar -u 1 10  # CPU使用率
sar -r 1 10  # 内存使用率
sar -d 1 10  # 磁盘I/O

# 使用vmstat
vmstat 1 10

# 使用iostat（需要安装sysstat）
iostat -x 1 10
```

# 10. 实践练习

## 系统监控练习
```bash
# 1. 监控系统资源使用
top
htop

# 2. 查看磁盘使用情况
df -h
du -sh /var/log/

# 3. 监控网络连接
netstat -tuln
ss -tuln

# 4. 查看系统负载
uptime
cat /proc/loadavg
```

## 性能分析练习
```bash
# 1. 查找占用资源最多的进程
ps aux --sort=-%cpu | head -5
ps aux --sort=-%mem | head -5

# 2. 监控磁盘I/O
iostat -x 1 5

# 3. 监控网络流量
iftop

# 4. 查看系统日志
journalctl -f
```

## 性能优化练习
```bash
# 1. 清理磁盘空间
sudo apt autoremove
sudo yum autoremove

# 2. 清理内存缓存
sync; echo 3 > /proc/sys/vm/drop_caches

# 3. 优化启动项
systemctl list-unit-files --type=service | grep enabled

# 4. 调整系统参数
cat /proc/sys/vm/swappiness
```

# 11. 课后作业

## 1. 系统监控报告
1. 编写一个脚本，定期收集系统资源使用情况
2. 生成系统性能报告
3. 分析系统瓶颈并提出优化建议

## 2. 性能优化实践
1. 识别系统中的性能问题
2. 实施优化措施
3. 验证优化效果

## 3. 监控工具配置
1. 配置一个综合监控工具
2. 设置告警阈值
3. 测试告警功能

## 4. 日志分析
1. 分析系统日志中的错误信息
2. 识别潜在问题
3. 提出解决方案

# 12. 故障排除

## 常见问题及解决方法

### 1. 系统响应慢
```bash
# 检查CPU使用率
top

# 检查内存使用
free -h

# 检查磁盘I/O
iostat -x 1 5

# 检查网络连接
netstat -an | grep ESTABLISHED | wc -l
```

### 2. 磁盘空间不足
```bash
# 查找大文件
find / -type f -size +100M 2>/dev/null

# 清理日志文件
sudo journalctl --vacuum-time=7d

# 清理包缓存
sudo apt clean
sudo yum clean all
```

### 3. 内存不足
```bash
# 查看内存使用
free -h

# 查看内存占用高的进程
ps aux --sort=-%mem | head -10

# 清理缓存
sync; echo 3 > /proc/sys/vm/drop_caches

# 检查内存泄漏
valgrind --tool=memcheck program
```

### 4. 网络连接问题
```bash
# 检查网络接口
ip addr show

# 测试网络连通性
ping google.com

# 查看网络连接
netstat -tuln

# 检查DNS配置
cat /etc/resolv.conf
```

# 13. 扩展学习

## 自动化监控
```bash
# 编写监控脚本
cat > monitor.sh << 'EOF'
#!/bin/bash
echo "=== System Monitor Report ==="
echo "Date: $(date)"
echo "Uptime: $(uptime)"
echo "CPU Usage:"
top -bn1 | grep "Cpu(s)" | sed "s/.*, *\([0-9.]*\)%* id.*/\1/" | awk '{print 100 - $1"%"}'
echo "Memory Usage:"
free -h | grep Mem | awk '{print $3 "/" $2}'
echo "Disk Usage:"
df -h | grep -E '^/dev/' | awk '{print $6 ": " $5}'
EOF
chmod +x monitor.sh
```

## 性能调优
```bash
# CPU调优
echo performance > /sys/devices/system/cpu/cpu0/cpufreq/scaling_governor

# 内存调优
echo 1 > /proc/sys/vm/overcommit_memory

# 磁盘调优
echo deadline > /sys/block/sda/queue/scheduler

# 网络调优
echo 1 > /proc/sys/net/ipv4/tcp_tw_reuse
```

## 监控系统集成
```bash
# 安装Prometheus（监控系统）
# 安装Grafana（可视化工具）
# 配置监控告警
```

通过本章学习，你应该能够：
1. 掌握Linux系统监控的基本方法
2. 熟练使用各种性能监控工具
3. 识别和分析系统性能瓶颈
4. 实施有效的性能优化措施
5. 建立完善的系统监控体系
6. 为系统稳定运行和性能优化打下坚实基础