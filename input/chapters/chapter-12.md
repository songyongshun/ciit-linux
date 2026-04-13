---
title: "Linux系统安全和防火墙"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-12
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
Layout: /_layout.cshtml
---

## Linux系统安全和防火墙

### 1. 系统安全概述

#### 安全基本原则
- **最小权限原则**：用户和程序只拥有必要的权限
- **纵深防御**：多层安全防护
- **定期审计**：持续监控和检查

#### 常见安全威胁
- 未授权访问
- 暴力破解攻击
- 恶意软件
- 拒绝服务攻击
- 配置错误

### 2. 用户安全管理

#### 密码安全
```bash
# 设置密码策略
vi /etc/login.defs

# 密码有效期
PASS_MAX_DAYS   90
PASS_MIN_DAYS   0
PASS_WARN_AGE   7
```

#### 用户访问控制
```bash
# 禁止root远程登录
vi /etc/ssh/sshd_config
PermitRootLogin no

# 禁用无用用户
userdel username
usermod -L username  # 锁定用户
```

### 3. SSH安全配置

#### SSH安全设置
```bash
vi /etc/ssh/sshd_config

# 修改默认端口
Port 2222

# 禁用密码登录
PasswordAuthentication no

# 启用密钥登录
PubkeyAuthentication yes

# 限制登录用户
AllowUsers user1 user2
```

#### 密钥认证
```bash
# 生成密钥对
ssh-keygen -t rsa -b 4096

# 复制公钥到服务器
ssh-copy-id user@server

# 重启SSH服务
systemctl restart sshd
```

### 4. firewalld防火墙

#### firewalld基础操作
```bash
# 启动防火墙
systemctl start firewalld

# 启用开机启动
systemctl enable firewalld

# 查看状态
firewall-cmd --state

# 查看默认区域
firewall-cmd --get-default-zone
```

#### 端口管理
```bash
# 开放端口
firewall-cmd --add-port=80/tcp --permanent

# 移除端口
firewall-cmd --remove-port=80/tcp --permanent

# 开放服务
firewall-cmd --add-service=http --permanent

# 重新加载配置
firewall-cmd --reload

# 查看开放端口
firewall-cmd --list-ports
```

#### 区域管理
```bash
# 查看所有区域
firewall-cmd --get-zones

# 设置默认区域
firewall-cmd --set-default-zone=public

# 添加接口到区域
firewall-cmd --zone=public --add-interface=eth0 --permanent
```

### 5. 系统安全加固

#### 文件权限加固
```bash
# 查找SUID文件
find / -type f -perm /4000

# 查找世界可写文件
find / -type f -perm -0002

# 查找无主文件
find / -nouser -o -nogroup
```

#### 系统更新
```bash
# 更新系统
yum update

# 安装安全更新
yum update --security

# 自动安全更新
yum install yum-cron
```

### 6. 日志审计

#### 系统日志
```bash
# 查看系统日志
journalctl

# 查看认证日志
journalctl -u sshd

# 查看失败登录
grep "Failed password" /var/log/secure

# 查看登录历史
last
lastb
```

### 7. 实践练习

#### 防火墙配置练习
```bash
# 1. 启用防火墙
systemctl start firewalld
systemctl enable firewalld

# 2. 开放HTTP和HTTPS端口
firewall-cmd --add-service=http --permanent
firewall-cmd --add-service=https --permanent

# 3. 重新加载配置
firewall-cmd --reload

# 4. 查看配置
firewall-cmd --list-all
```

#### SSH安全练习
```bash
# 1. 生成SSH密钥
ssh-keygen -t rsa -b 4096

# 2. 配置SSH禁用密码登录
vi /etc/ssh/sshd_config
PasswordAuthentication no

# 3. 重启SSH服务
systemctl restart sshd
```

### 8. 课后作业

#### 1. 安全配置实践
1. 配置SSH安全设置
2. 配置firewalld防火墙规则
3. 设置用户密码策略
4. 禁用不必要的系统服务

#### 2. 安全审计
1. 查看系统日志分析安全事件
2. 检查系统文件权限
3. 扫描系统开放端口
4. 制定系统安全检查清单

通过本章学习，你应该能够：
1. 理解Linux系统安全基本原则
2. 掌握用户和SSH安全配置
3. 熟练使用firewalld防火墙
4. 学会系统安全加固方法
5. 能够进行安全日志审计和入侵检测