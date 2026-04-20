---
Xref: linux/chapter-05
title: "Linux用户和权限管理"
---
# Linux用户和权限管理

# 1. 用户账户基础概念

## 什么是用户账户

- **用户账户**：Linux系统中用于标识和管理用户身份的机制
- **作用**：控制用户对系统资源的访问权限
- **类型**：超级用户（root）、普通用户、系统用户

## 用户ID（UID）和组ID（GID）

- **UID**：用户标识符，唯一标识系统中的每个用户
- **GID**：组标识符，唯一标识系统中的每个用户组
- **特殊UID**：
  - 0：root用户
  - 1-999：系统用户
  - 1000+：普通用户

# 2. 用户管理命令

## 查看用户信息

```bash
# 查看当前登录用户
whoami

# 查看所有登录用户
who

# 查看系统中所有用户
cat /etc/passwd

# 查看特定用户信息
id username
```

## 添加用户

```bash
# 添加新用户（默认会创建主目录）
sudo useradd username

# 添加用户但不创建主目录
sudo useradd -M username

# 添加用户并设置用户ID（在组建集群时可能需要）
sudo useradd -u 1001 username
```

## 切换用户

```bash
# 切换到另一个用户
su username
# 切换到root用户
su
```

注意，使用su命令切换用户时，如果目标用户没有设置密码，可能会提示“Authentication failure”。
因此，建议为所有用户设置密码，以确保可以正常切换用户.
但在root用户的情况下，是可以直接使用su命令切换到任意用户的。

## 设置用户密码

```bash
# 为用户设置密码
sudo passwd username

# 锁定用户账户
sudo passwd -l username

# 解锁用户账户
sudo passwd -u username
```

## 修改用户信息

```bash
# 修改用户主目录（有时用户目录在单独一块磁盘分区时需要修改）
sudo usermod -d /data1/home/newname username

# 修改用户shell
sudo usermod -s /bin/zsh username

# 将用户添加到组
sudo usermod -a -G groupname username
```

## 删除用户

```bash
# 删除用户但保留主目录
sudo userdel username

# 删除用户及其主目录
sudo userdel -r username
```

# 3. 用户组管理

## 查看组信息

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

## 创建和管理组

```bash
# 创建新组
sudo groupadd groupname

# 创建组并指定GID
sudo groupadd -g 1001 groupname

# 查看组ID(GID，没有新的命令，而是对id命令添加选项来查看用户所属的组ID，参数为用户名，代表查看指定用户所属的组ID。若无参数，代表查看当前用户所属的组ID)
id -g username

# 修改组名
sudo groupmod -n newname oldname

# 删除组
sudo groupdel groupname
```

## 管理组成员

```bash
# 将用户添加到组
sudo gpasswd -a username groupname

# 从组中删除用户
sudo gpasswd -d username groupname
```

## 初始组 vs. 附加组

- 初始组 (Primary Group)：
  用户创建时指定的组（GID 记录在 /etc/passwd 中）。
  在 /etc/group 文件里，初始组成员的名字通常是空着的，因为系统认为既然这是你的主组，就不必再重复记录一遍。
- 附加组 (Secondary Group)：
  当你执行 gpasswd -a user2 user2 时，你实际上是把 user2 显式地作为附加成员加入到了 user2 组中。
  结果：getent group 命令主要读取 /etc/group。只有当你手动添加（即使是加回同名组）后，该组的成员列表里才会出现 user2 这个名字，命令才会返回结果。

# 4. 文件权限基础

## 权限类型

- **读权限（r）**：4 - 可以读取文件内容或列出目录内容
- **写权限（w）**：2 - 可以修改文件内容或在目录中创建/删除文件
- **执行权限（x）**：1 - 可以执行文件或进入目录

## 权限表示方法
ls -l命令输出的信息中，第一列显示了文件类型和权限信息。权限信息由10个字符组成，分别表示文件类型和所有者、组用户、其他用户的权限。
- 第一个字符表示文件类型：
  - `-`：普通文件
  - `d`：目录
  - `l`：符号链接
  - `c`：字符设备文件
  - `b`：块设备文件
- 接下来的9个字符分为三组，每组三个字符，分别表示所有者、组用户和其他用户的权限：
  - `r`：读权限
  - `w`：写权限
  - `x`：执行权限

```bash
# 符号表示法
   -rw-r--r--  1 user group size date time filename
#  | | | | |
#  | | | | +-- 其他用户权限
#  | | +------ 组用户权限
#  | +-------- 所有者权限
#  +---------- 文件类型
```

还有另一种表示方法是数字表示法，每个权限位对应一个数字：
- 读权限（r）对应数字4
- 写权限（w）对应数字2
- 执行权限（x）对应数字1

```bash
# 数字表示法
chmod 755 filename  # rwxr-xr-x
chmod 644 filename  # rw-r--r--
```

## 查看文件权限

```bash
# 查看文件详细信息
ls -l filename

# 查看目录详细信息
ls -ld directoryname

# 查看隐藏文件
ls -la
```

# 5. 修改文件权限

## 使用chmod命令

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

# 递归修改目录权限（文件夹下的所有文件和子目录都会被修改）
chmod -R 755 directory
```

## 使用chown命令修改所有者

```bash
# 修改文件所有者
sudo chown username filename

# 修改文件所有者和组
sudo chown username:groupname filename

# 递归修改目录所有者
sudo chown -R username:groupname directory
```

# 6. sudo权限管理

## 什么是sudo

- **sudo**：以超级用户权限执行命令的安全方式
- **优势**：记录命令执行、不需要知道root密码、可以精细控制权限

## 配置sudo权限

```bash
# 编辑sudoers文件（推荐使用visudo,通过锁定文件机制防止多个用户同时编辑 /etc/sudoers）
sudo visudo
```
sudoers的基本语法如下：

```bash
song ALL=(ALL) ALL
```

用户/组 主机=(目标用户:目标组) 命令  


