---
Xref: linux/chapter-12
title: "Shell编程"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-12
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---
# Shell编程

# 1. Shell概述

## 什么是Shell

Shell是一个命令解释器，它接收用户输入的命令并将其传递给Linux内核执行。同时，Shell也是一种编程语言，可以编写Shell脚本来自动化任务。

## 常见Shell类型

- **bash**：Bourne Again Shell，Linux默认Shell
- **sh**：Bourne Shell，最原始的Shell
- **csh**：C Shell，语法类似C语言
- **ksh**：Korn Shell，兼容bash和sh
- **zsh**：Z Shell，功能最强大的Shell

## 查看当前Shell

```bash
# 查看当前使用的Shell
echo $SHELL

# 查看系统所有可用Shell
cat /etc/shells

# 查看当前Shell版本
bash --version
```

## Shell脚本基础

```bash
#!/bin/bash
# 第一行称为shebang(释伴)，指定脚本解释器
# 以#开头的行为注释

echo "Hello, World!"
```

# 2. Shell变量

## 变量定义

```bash
# 定义变量（等号两边不能有空格）
name="John"
age=25

# 使用变量（加$符号）
echo $name
echo ${name}


## 特殊变量

```bash
$0      # 脚本名称
$1-$9   # 第1-9个参数
$#      # 参数个数
$@      # 所有参数
```

## 环境变量

```bash
# 设置环境变量
export PATH=$PATH:/new/path
export MY_VAR="value"

# 查看环境变量
env

# 常用环境变量
echo $HOME      # 用户主目录
echo $USER      # 当前用户
echo $PWD       # 当前工作目录
echo $PATH      # 命令搜索路径
```

# 3. 运算符

## 算术运算符

```bash
a=10
b=20

# 使用$(())（推荐）
val=$((a + b))

# 运算符：+ - * / % = == !=
```

## 关系运算符

```bash
a=10
b=20

# 使用[]
if [ $a -eq $b ]
then
   echo "相等"
fi

# 运算符：
# -eq 等于
# -ne 不等于
# -gt 大于
# -lt 小于
# -ge 大于等于
# -le 小于等于
```

## 布尔运算符

```bash
a=10
b=20

# 逻辑与
if [ $a -lt 100 ] && [ $b -gt 10 ]
then
   echo "条件成立"
fi

# 逻辑或
if [ $a -lt 100 ] || [ $b -lt 10 ]
then
   echo "至少一个条件成立"
fi

# 逻辑非
if [ ! $a -eq $b ]
then
   echo "不相等"
fi
```

## 字符串运算符

```bash
a="hello"
b="world"

# 字符串连接
c=$a$b

# 字符串长度
len=${#a}

# 运算符：
# =   相等
# !=  不相等
# -z  字符串长度为0
# -n  字符串长度不为0
# $   字符串不为空
```

## 文件测试运算符

```bash
file="/path/to/file"

# 文件测试
[ -e $file ]    # 文件存在
[ -f $file ]    # 是普通文件
[ -d $file ]    # 是目录
[ -r $file ]    # 可读
[ -w $file ]    # 可写
[ -x $file ]    # 可执行
[ -s $file ]    # 文件不为空
[ -L $file ]    # 是符号链接
```

# 4. 流程控制

## if条件语句

```bash
# 基本if语句
if [ 条件 ]
then
   命令
fi

# if-else语句
if [ 条件 ]
then
   命令1
else
   命令2
fi

# if-elif-else语句
if [ 条件1 ]
then
   命令1
elif [ 条件2 ]
then
   命令2
else
   命令3
fi

# 示例
score=85
if [ $score -ge 90 ]
then
   echo "优秀"
elif [ $score -ge 80 ]
then
   echo "良好"
elif [ $score -ge 60 ]
then
   echo "及格"
else
   echo "不及格"
fi
```

## for循环

```bash
# 基本for循环
for var in item1 item2 item3
do
   echo "当前值: $var"
done

# 使用范围
for i in {1..5}
do
   echo "数字: $i"
done

# C风格for循环
for ((i=0; i<5; i++))
do
   echo "计数: $i"
done

# 遍历文件
for file in *.txt
do
   echo "文件: $file"
done
```

## while循环

```bash
# 基本while循环
count=1
while [ $count -le 5 ]
do
   echo "计数: $count"
   count=$((count + 1))
done

# 读取文件
while read line
do
   echo "行内容: $line"
done < file.txt

# 无限循环
while true
do
   echo "按Ctrl+C退出"
   sleep 1
done
```

## break和continue

```bash
# break - 跳出循环
for i in {1..10}
do
   if [ $i -eq 5 ]
   then
      break
   fi
   echo "数字: $i"
done

# continue - 跳过本次循环
for i in {1..10}
do
   if [ $((i % 2)) -eq 0 ]
   then
      continue
   fi
   echo "奇数: $i"
done
```

# 5. 数组

## 数组定义

```bash
# 定义数组
arr=(value1 value2 value3)

# 或逐个赋值
arr[0]="first"
arr[1]="second"
arr[2]="third"


## 数组操作

```bash
arr=(apple banana cherry date)

# 访问元素
echo ${arr[0]}        # apple
echo ${arr[@]}        # 所有元素
echo ${arr[*]}        # 所有元素

# 修改元素
arr[0]="apricot"

# 删除元素
unset arr[2]

# 添加元素
arr+=(elderberry)
```

## 数组遍历

```bash
arr=(one two three four five)

# 遍历所有元素
for item in ${arr[@]}
do
   echo "元素: $item"
done
```

# 6. 字符串处理

## 字符串截取

```bash
str="Hello, World!"

# 提取子字符串
echo ${str:0:5}     # Hello
echo ${str:7}       # World!

# 从右边截取
echo ${str: -6}     # World!（注意空格）
```

# 7. 输入输出

## 读取输入

```bash
# 基本读取
echo "请输入姓名:"
read name
echo "你好, $name"

# 读取多个变量
echo "请输入姓名和年龄:"
read name age
echo "$name 今年 $age 岁"

# 读取一行到数组
echo "请输入多个值:"
read -a arr
echo "第一个值: ${arr[0]}"

# 不显示输入（密码）
echo "请输入密码:"
read -s password
echo "密码已接收"

# 设置超时
echo "请在5秒内输入:"
read -t 5 input
```

## 输出重定向

```bash
# 标准输出重定向
echo "Hello" > file.txt      # 覆盖
echo "World" >> file.txt     # 追加

# 标准错误重定向
command 2> error.log
command 2>> error.log

# 同时重定向标准和错误
command > output.log 2>&1
command &> output.log

# 丢弃输出
command > /dev/null 2>&1
```

# 8. 实践练习

## 练习1：计算器脚本

```bash
#!/bin/bash
# calculator.sh - 简单计算器

echo "简单计算器"
echo "1. 加法"
echo "2. 减法"
echo "3. 乘法"
echo "4. 除法"

read -p "请选择运算 (1-4): " choice
read -p "请输入第一个数: " num1
read -p "请输入第二个数: " num2

case $choice in
   1)
      result=$((num1 + num2))
      echo "$num1 + $num2 = $result"
      ;;
   2)
      result=$((num1 - num2))
      echo "$num1 - $num2 = $result"
      ;;
   3)
      result=$((num1 * num2))
      echo "$num1 * $num2 = $result"
      ;;
   4)
      if [ $num2 -eq 0 ]
      then
         echo "错误: 除数不能为0"
      else
         result=$((num1 / num2))
         echo "$num1 / $num2 = $result"
      fi
      ;;
   *)
      echo "无效选择"
      ;;
esac
```

## 练习2：文件备份脚本

```bash
#!/bin/bash
# backup.sh - 文件备份脚本

SOURCE_DIR="/path/to/source"
BACKUP_DIR="/path/to/backup"
DATE=$(date +%Y%m%d_%H%M%S)
BACKUP_NAME="backup_$DATE.tar.gz"

# 检查源目录是否存在
if [ ! -d "$SOURCE_DIR" ]
then
   echo "错误: 源目录不存在"
   exit 1
fi

# 创建备份目录
mkdir -p $BACKUP_DIR

# 创建备份
tar -czf $BACKUP_DIR/$BACKUP_NAME $SOURCE_DIR

if [ $? -eq 0 ]
then
   echo "备份成功: $BACKUP_DIR/$BACKUP_NAME"
else
   echo "备份失败"
   exit 1
fi

# 删除7天前的备份
find $BACKUP_DIR -name "backup_*.tar.gz" -mtime +7 -delete
echo "已清理7天前的备份"
```

## 练习3：系统信息收集脚本

```bash
#!/bin/bash
# sysinfo.sh - 系统信息收集

echo "========== 系统信息 =========="

echo "主机名: $(hostname)"
echo "操作系统: $(uname -s)"
echo "内核版本: $(uname -r)"
echo "运行时间: $(uptime)"
echo ""

echo "========== CPU信息 =========="
echo "CPU型号: $(grep 'model name' /proc/cpuinfo | head -1 | cut -d: -f2)"
echo "CPU核心数: $(nproc)"
echo ""

echo "========== 内存信息 =========="
free -h
echo ""

echo "========== 磁盘信息 =========="
df -h
echo ""

echo "========== 网络信息 =========="
ip addr show | grep "inet "
```

# 9. 练习题

## 1. 基础练习

1. 编写一个脚本，判断一个数是否为偶数
2. 编写一个脚本，计算1到100的和
3. 编写一个脚本，打印99乘法表
4. 编写一个脚本，判断一个年份是否为闰年

## 2. 进阶练习

1. 编写一个脚本，批量创建用户（从文件读取用户名列表）
2. 编写一个脚本，监控系统资源使用率（CPU、内存、磁盘）
3. 编写一个脚本，自动备份指定目录并发送到远程服务器
4. 编写一个脚本，检查网站是否可访问并发送警报

通过本章学习，你应该能够：

1. 理解Shell编程的基本概念和语法
2. 掌握变量、运算符和流程控制的使用
3. 熟练编写函数和数组操作
4. 学会字符串处理和输入输出重定向
5. 能够编写实用的Shell脚本来自动化日常任务
