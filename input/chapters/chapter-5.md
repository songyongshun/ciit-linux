---
title: "Linux用户和权限管理"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-3
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
Layout: /_layout.cshtml
---

## Linux用户和权限管理

### 1. 用户账户基础概念

#### 什么是用户账户
- **用户账户**：Linux系统中用于标识和管理用户身份的机制
- **作用**：控制用户对系统资源的访问权限
- **类型**：超级用户（root）、普通用户、系统用户

#### 用户ID（UID）和组ID（GID）
- **UID**：用户标识符，唯一标识系统中的每个用户
- **GID**：组标识符，唯一标识系统中的每个用户组
- **特殊UID**：
  - 0：root用户
  - 1-999：系统用户
  - 1000+：普通用户

### 2. 用户管理命令

#### 查看用户信息
```bash
# 查看当前登录用户
whoami

# 查看所有登录用户
who
w

# 查看系统中所有用户
cat /etc/passwd

# 查看特定用户信息
id username
finger username  # 需要安装finger包
```

#### 添加用户
```bash
# 添加新用户
sudo useradd username

# 添加用户并创建主目录
sudo useradd -m username

# 添加用户并指定shell
sudo useradd -m -s /bin/bash username

# 添加用户并设置用户ID
sudo useradd -u 1001 username

# 添加用户并设置注释信息
sudo useradd -c "User Full Name" username
```

#### 设置用户密码
```bash
# 为用户设置密码
sudo passwd username

# 删除用户密码（禁用账户）
sudo passwd -d username

# 锁定用户账户
sudo passwd -l username

# 解锁用户账户
sudo passwd -u username
```

#### 修改用户信息
```bash
# 修改用户主目录
sudo usermod -d /home/newdir username

# 修改用户shell
sudo usermod -s /bin/zsh username

# 修改用户注释信息
sudo usermod -c "New Comment" username

# 将用户添加到组
sudo usermod -a -G groupname username
```

#### 删除用户
```bash
# 删除用户但保留主目录
sudo userdel username

# 删除用户及其主目录
sudo userdel -r username
```

### 3. 用户组管理

#### 查看组信息
```bash
# 查看所有用户组
cat /etc/group

# 查看当前用户所属的组
groups

# 查看特定用户所属的组
groups username

# 查看特定组的成员
getent group groupname
```

#### 创建和管理组
```bash
# 创建新组
sudo groupadd groupname

# 创建组并指定GID
sudo groupadd -g 1001 groupname

# 修改组名
sudo groupmod -n newname oldname

# 删除组
sudo groupdel groupname
```

#### 管理组成员
```bash
# 将用户添加到组
sudo gpasswd -a username groupname

# 从组中删除用户
sudo gpasswd -d username groupname

# 设置组管理员
sudo gpasswd -A adminuser groupname

# 设置组密码
sudo gpasswd groupname
```

### 4. 文件权限基础

#### 权限类型
- **读权限（r）**：4 - 可以读取文件内容或列出目录内容
- **写权限（w）**：2 - 可以修改文件内容或在目录中创建/删除文件
- **执行权限（x）**：1 - 可以执行文件或进入目录

#### 查看文件权限
```bash
# 查看文件详细信息
ls -l filename

# 查看目录详细信息
ls -ld directoryname

# 查看隐藏文件
ls -la
```

#### 权限表示方法
```bash
# 符号表示法
-rw-r--r--  1 user group size date time filename
#  | | | | |
#  | | | | +-- 其他用户权限
#  | | +------ 组用户权限
#  | +-------- 所有者权限
#  +---------- 文件类型

# 数字表示法
chmod 755 filename  # rwxr-xr-x
chmod 644 filename  # rw-r--r--
```

### 5. 修改文件权限

#### 使用chmod命令
```bash
# 使用符号法修改权限
chmod u+r filename      # 给所有者添加读权限
chmod g-w filename      # 从组用户移除写权限
chmod o+x filename      # 给其他用户添加执行权限
chmod a+r filename      # 给所有用户添加读权限

# 使用数字法修改权限
chmod 755 filename      # rwxr-xr-x
chmod 644 filename      # rw-r--r--
chmod 777 filename      # rwxrwxrwx

# 递归修改目录权限
chmod -R 755 directory
```

#### 使用chown命令修改所有者
```bash
# 修改文件所有者
sudo chown username filename

# 修改文件所有者和组
sudo chown username:groupname filename
sudo chown username.groupname filename  # 某些系统使用点分隔

# 递归修改目录所有者
sudo chown -R username:groupname directory
```

#### 使用chgrp命令修改组
```bash
# 修改文件组
sudo chgrp groupname filename

# 递归修改目录组
sudo chgrp -R groupname directory
```

### 6. 特殊权限

#### SUID权限
- **作用**：允许用户以文件所有者的身份执行文件
- **设置方法**：
```bash
chmod u+s filename
chmod 4755 filename  # 数字法，4表示SUID
```

#### SGID权限
- **作用**：在文件上表示以组身份执行，在目录上表示新创建的文件继承目录的组
- **设置方法**：
```bash
chmod g+s filename
chmod 2755 filename  # 数字法，2表示SGID
```

#### Sticky Bit
- **作用**：只允许文件/目录的所有者删除自己的文件
- **常见用途**：/tmp目录
- **设置方法**：
```bash
chmod +t directoryname
chmod 1755 directoryname  # 数字法，1表示Sticky Bit
```

### 7. sudo权限管理

#### 什么是sudo
- **sudo**：以超级用户权限执行命令的安全方式
- **优势**：记录命令执行、不需要知道root密码、可以精细控制权限

#### 配置sudo权限
```bash
# 编辑sudoers文件（推荐使用visudo）
sudo visudo

# 或者直接编辑文件
sudo nano /etc/sudoers
```

#### sudoers文件语法
```bash
# 基本语法
用户名 主机名=(可执行身份) 命令列表

# 示例
root    ALL=(ALL:ALL) ALL
%wheel  ALL=(ALL:ALL) ALL
username ALL=(ALL) ALL
username ALL=(root) /usr/bin/systemctl
```

#### 用户组sudo权限
```bash
# 将用户添加到sudo组
sudo usermod -a -G wheel username  # CentOS/RHEL
sudo usermod -a -G sudo username   # Ubuntu/Debian

# 验证用户是否在sudo组中
groups username
```

### 8. 实践练习

#### 用户管理练习
```bash
# 1. 创建新用户
sudo useradd -m -s /bin/bash student1
sudo passwd student1

# 2. 查看用户信息
id student1
cat /etc/passwd | grep student1

# 3. 修改用户信息
sudo usermod -c "Linux Student" student1
sudo usermod -a -G wheel student1

# 4. 删除用户
sudo userdel -r student1
```

#### 权限管理练习
```bash
# 1. 创建测试文件和目录
touch testfile.txt
mkdir testdir

# 2. 修改文件权限
chmod 644 testfile.txt
chmod 755 testdir

# 3. 查看权限
ls -l testfile.txt
ls -ld testdir

# 4. 修改文件所有者
sudo chown student1 testfile.txt

# 5. 设置特殊权限
chmod u+s testfile.txt  # 设置SUID
chmod g+s testdir       # 设置SGID
chmod +t testdir        # 设置Sticky Bit
```

#### sudo练习
```bash
# 1. 创建新用户
sudo useradd -m student2

# 2. 将用户添加到sudo组
sudo usermod -a -G wheel student2

# 3. 验证sudo权限
su - student2
sudo whoami  # 应该显示root

# 4. 退出student2账户
exit
```

### 9. 课后作业

#### 1. 用户管理
1. 创建3个新用户：user1、user2、user3
2. 为每个用户设置密码
3. 查看每个用户的UID和GID
4. 将user1添加到wheel组
5. 删除user3用户及其主目录

#### 2. 权限练习
1. 创建一个文件test.txt，设置权限为644
2. 创建一个目录testdir，设置权限为755
3. 将test.txt的所有者改为user1
4. 将testdir的组改为user1的主组
5. 设置test.txt的SUID权限
6. 设置testdir的SGID和Sticky Bit权限

#### 3. sudo配置
1. 编辑sudoers文件，为user2添加特定命令的sudo权限
2. 测试user2是否可以执行指定的sudo命令
3. 记录sudo命令的执行日志

#### 4. 综合练习
1. 创建一个共享目录/shared
2. 设置适当的权限，让多个用户可以协作
3. 配置用户组，实现文件的共享管理
4. 测试不同用户的访问权限

### 10. 故障排除

#### 常见问题及解决方法

##### 1. 用户无法登录
```bash
# 检查用户是否存在
id username

# 检查用户账户状态
sudo passwd -S username

# 检查用户主目录
ls -ld /home/username
```

##### 2. 权限不足
```bash
# 查看文件权限
ls -l filename

# 检查用户所属组
groups username

# 临时提升权限
sudo command
```

##### 3. sudo命令被拒绝
```bash
# 检查用户是否在sudo组中
groups username

# 检查sudoers配置
sudo visudo

# 查看sudo日志
sudo tail /var/log/secure
```

##### 4. 文件无法删除
```bash
# 检查目录权限
ls -ld directory

# 检查Sticky Bit设置
ls -l directory

# 使用sudo删除
sudo rm filename
```

### 11. 扩展学习

#### 用户资源限制
```bash
# 查看用户资源限制
ulimit -a

# 设置用户资源限制（在/etc/security/limits.conf中）
username soft nofile 1024
username hard nofile 2048
```

#### 用户环境配置
```bash
# 查看用户环境变量
env

# 编辑用户环境配置文件
~/.bashrc
~/.bash_profile
~/.profile
```

#### 用户审计
```bash
# 查看登录历史
last

# 查看命令历史
history

# 查看系统日志
sudo tail /var/log/secure
```

通过本章学习，你应该能够：
1. 理解Linux用户和组的基本概念
2. 熟练使用用户管理命令
3. 掌握文件权限的设置和管理
4. 理解和配置sudo权限
5. 解决常见的用户和权限问题
6. 为系统安全和多用户环境管理打下基础
