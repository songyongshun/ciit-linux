---
Xref: linux/chapter-07
title: "Shell基础知识"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-06
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Shell基础知识

# 1. Shell概述

## 什么是Shell
- **Shell**：操作系统的命令解释器，是用户与内核交互的接口
- **作用**：接收用户输入的命令，传递给操作系统执行并返回结果
- **特点**：既是命令行接口，也是脚本编程语言

## 常见的Shell类型
- **Bash**：Bourne Again Shell，Linux默认Shell
- **Dash**：Debian Almquist Shell，轻量级Shell，Debian/Ubuntu下指向/bin/sh
- **Zsh**：Z Shell，功能更强大的Shell
- **Fish**：友好的交互式Shell

## 查看当前Shell
```bash
# 查看当前使用的Shell
echo $SHELL

# 查看系统可用Shell
cat /etc/shells

# 切换Shell（系统重启后生效）
chsh -s /bin/zsh
```

## POSIX标准
- **POSIX**：可移植操作系统接口（Portable Operating System Interface），是IEEE定义的一套操作系统国际标准
- **目的**：统一不同UNIX/Linux系统的接口规范，保证操作系统之间的兼容性和应用程序的可移植性
- **Shell与POSIX**：POSIX标准明确规定了Shell的语法规范、内置命令、行为逻辑和系统接口
- **重要意义**：
  - 符合POSIX标准的Shell脚本可以在所有兼容POSIX的操作系统上无修改运行
  - Bash、Zsh、Dash、Ksh等主流Shell都实现了POSIX基本规范
  - 跨平台Shell脚本开发应当遵循POSIX标准

# 2. Shell基本操作

## 命令格式
```bash
命令名 [选项] [参数]
```

## 常用快捷键
```bash
Ctrl + a   # 跳转到命令行开头
Ctrl + e   # 跳转到命令行结尾
Ctrl + u   # 删除光标到行首的内容
Ctrl + k   # 删除光标到行尾的内容
Ctrl + l   # 清屏
Ctrl + c   # 终止当前命令
Ctrl + d   # 退出当前Shell
Tab        # 自动补全
```

## 历史命令
```bash
# 查看命令历史
history

# 执行历史命令
!100       # 执行第100条命令
!!         # 执行上一条命令
!ls        # 执行最近以ls开头的命令

# 搜索历史命令
Ctrl + r
```

# 3. 环境变量

## 查看环境变量
```bash
# 查看所有环境变量
env

# 查看特定环境变量
echo $PATH
echo $HOME
echo $USER

# 设置临时环境变量
export MYVAR="hello"
```

## PATH变量
```bash
# 查看PATH
echo $PATH

# 添加目录到PATH
export PATH=$PATH:/usr/local/bin
```

## 配置文件
```bash
~/.bashrc         # 非登录Shell配置
~/.bash_profile   # 登录Shell配置
/etc/profile      # 全局配置
```

# 4. 通配符

## 常用通配符
```bash
*        # 匹配任意字符，任意长度
?        # 匹配任意单个字符
[]       # 匹配括号内的任意一个字符
[!]      # 不匹配括号内的字符
[a-z]    # 匹配小写字母
[0-9]    # 匹配数字
```

## 通配符示例
```bash
ls *.txt         # 列出所有txt文件
ls file?.txt     # 列出file1.txt, file2.txt等
ls file[123].txt # 列出file1.txt, file2.txt, file3.txt
ls file[!1].txt  # 列出不是file1.txt的文件
```

# 5. 输入输出重定向

## 标准流
- **stdin (0)**：标准输入，默认键盘
- **stdout (1)**：标准输出，默认屏幕
- **stderr (2)**：标准错误输出，默认屏幕

## 重定向操作
```bash
# 输出重定向
command > file   # 将输出覆盖写入文件
command >> file  # 将输出追加到文件

# 错误重定向
command 2> error.log
command 2>> error.log

# 同时重定向输出和错误
command > output.log 2>&1
command &> output.log

# 输入重定向
command < input.txt
```

# 6. 管道

## 管道概念
```bash
# 将第一个命令的输出作为第二个命令的输入
command1 | command2
```

## 管道示例
```bash
# 查看进程并过滤
ps aux | grep ssh

# 统计文件行数
cat file.txt | wc -l

# 排序并去重
cat file.txt | sort | uniq

# 分页显示
ls -la /etc | less
```

# 7. 命令替换

```bash
# 使用$()
files=$(ls)

# 使用反引号
files=`ls`

# 示例
echo "当前目录文件数: $(ls | wc -l)"
echo "当前时间: $(date)"
```

# 8. 别名

```bash
# 创建别名
alias ll='ls -la'
alias gs='git status'

# 查看别名
alias

# 删除别名
unalias ll
```

