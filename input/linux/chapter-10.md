---
Xref: linux/chapter-10
title: "Linux网络配置和管理"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-10
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Linux网络配置和管理

# 1. 网络基础概念

## TCP/IP协议栈
- **应用层**：HTTP、FTP、SSH、DNS
- **传输层**：TCP、UDP
- **网络层**：IP、ICMP、ARP
- **链路层**：以太网、Wi-Fi

## 网络配置要素
- IP地址和子网掩码
- 网关地址
- DNS服务器
- 主机名
- 接口（interface）

# 2. 网络接口管理

## 查看网络接口
```bash
# 查看所有网络接口
ip addr show

# 简写
ip a

# 传统方式
ifconfig -a
```

## 启用/禁用接口
```bash
# 启用接口
ip link set eth0 up

# 禁用接口
ip link set eth0 down
```

## 配置IP地址
```bash
# 临时配置IP
ip addr add 192.168.1.100/24 dev eth0

# 删除IP地址
ip addr del 192.168.1.100/24 dev eth0
```

# 3. 路由配置

## 查看路由表
```bash
# 查看路由表
ip route show

# 传统方式
route -n
```

## 添加/删除路由
```bash
# 添加默认网关
ip route add default via 192.168.1.1

# 添加静态路由
ip route add 10.0.0.0/8 via 192.168.1.2

# 删除路由
ip route del 10.0.0.0/8
```

# 4. DNS配置

## 查看DNS配置
```bash
cat /etc/resolv.conf
```

## 修改DNS服务器
```bash
# 编辑配置文件
vi /etc/resolv.conf

# 添加DNS服务器
nameserver 8.8.8.8
nameserver 8.8.4.4
```

# 5. 网络测试工具

## 连通性测试
```bash
# ping测试
ping google.com
ping -c 4 192.168.1.1

# 路由追踪
traceroute google.com
mtr google.com
```

## 端口测试
```bash
# 测试TCP端口
telnet 192.168.1.1 22

# 测试UDP端口
nc -u 192.168.1.1 53

# 端口扫描
nmap 192.168.1.0/24
```

## 查看连接
```bash
# 查看所有监听端口
# ss来自于iproute2工具集，功能更强大，性能更好
ss -tuln

# 传统方式
netstat -tuln

# 查看已建立连接
ss -tuln | grep ESTAB
```

# 6. 网络服务管理

## 网络服务
```bash
# 查看网络服务状态
systemctl status NetworkManager

# 重启网络服务
systemctl restart NetworkManager
```

## 主机名配置
```bash
# 查看主机名
hostname

# 临时修改主机名
hostname newhostname

# 永久修改
hostnamectl set-hostname newhostname
```

通过本章学习，你应该能够：
1. 理解TCP/IP网络基本概念
2. 掌握网络接口配置方法
3. 学会路由和DNS配置
4. 熟练使用网络测试和诊断工具
5. 能够排除常见网络故障
