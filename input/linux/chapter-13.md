---
Xref: linux/chapter-13
title: "Shell编程"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/chapter-13
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# Shell编程

# 1. Shell编程概述

## 什么是Shell脚本
Shell脚本是一种为Shell编写的脚本程序，它允许用户将多个命令组合在一起，实现自动化任务处理。

## Shell脚本的用途
- 自动化系统管理任务
- 批量处理文件和数据
- 系统监控和日志分析
- 软件部署和配置

## 创建和运行Shell脚本
```bash
# 创建脚本文件
vi myscript.sh

# 添加执行权限
chmod +x myscript.sh

# 运行脚本
./myscript.sh

# 或使用bash执行
bash myscript.sh
```

# 2. Shell脚本基础

## 脚本结构
```bash
#!/bin/bash
# 这是一个Shell脚本示例
# 第一行的 #! 称为shebang，指定脚本解释器

echo "Hello, World!"
```

## 注释
```bash
# 单行注释

: '
多行注释
可以使用冒号和单引号
'

<<EOF
这也是多行注释
使用heredoc语法
EOF
```

## 变量
```bash
# 定义变量（等号两边不能有空格）
name="John"
age=25

# 使用变量（加$符号）
echo "Name: $name"
echo "Age: $age"

# 读取用户输入
read -p "请输入您的姓名: " username
echo "您好, $username!"

# 特殊变量
echo "脚本名称: $0"
echo "第一个参数: $1"
echo "参数个数: $#"
echo "所有参数: $@"
echo "脚本退出状态: $?"
```

# 3. 字符串处理

## 字符串定义和操作
```bash
# 字符串定义
str1='single quotes'
str2="double quotes"

# 字符串长度
str="Hello, World!"
echo ${#str}  # 输出: 13

# 子字符串提取
echo ${str:0:5}  # 输出: Hello

# 字符串替换
echo ${str/World/Unix}  # 输出: Hello, Unix!

# 字符串拼接
str3="${str1} and ${str2}"
```

## 转义字符
```bash
echo "Price: \$100"    # 输出: Price: $100
echo "Line1\nLine2"    # 输出: Line1\nLine2
echo -e "Line1\nLine2" # 输出: Line1
                        #        Line2
```

# 4. 数组

## 数组定义和操作
```bash
# 定义数组
arr1=(apple banana cherry)
arr2[0]="red"
arr2[1]="green"
arr2[2]="blue"

# 访问数组元素
echo ${arr1[0]}      # 输出: apple
echo ${arr1[@]}      # 输出所有元素
echo ${#arr1[@]}     # 输出数组长度

# 数组操作
arr1+=(date)         # 添加元素
unset arr1[1]        # 删除元素

# 遍历数组
for fruit in "${arr1[@]}"; do
    echo "Fruit: $fruit"
done
```

# 5. 条件判断

## if语句
```bash
# 基本if语句
if [ condition ]; then
    commands
fi

# if-else语句
if [ condition ]; then
    commands1
else
    commands2
fi

# if-elif-else语句
if [ condition1 ]; then
    commands1
elif [ condition2 ]; then
    commands2
else
    commands3
fi
```

## 条件测试
```bash
# 数值比较
[ $a -eq $b ]  # 等于
[ $a -ne $b ]  # 不等于
[ $a -gt $b ]  # 大于
[ $a -lt $b ]  # 小于
[ $a -ge $b ]  # 大于等于
[ $a -le $b ]  # 小于等于

# 字符串比较
[ "$a" = "$b" ]    # 等于
[ "$a" != "$b" ]   # 不等于
[ -z "$a" ]        # 字符串为空
[ -n "$a" ]        # 字符串非空

# 文件测试
[ -e "$file" ]     # 文件存在
[ -f "$file" ]     # 普通文件
[ -d "$file" ]     # 目录
[ -r "$file" ]     # 可读
[ -w "$file" ]     # 可写
[ -x "$file" ]     # 可执行
[ -s "$file" ]     # 文件非空

# 逻辑运算
[ condition1 ] && [ condition2 ]   # 与
[ condition1 ] || [ condition2 ]   # 或
[ ! condition ]                    # 非
```

## case语句
```bash
case $variable in
    pattern1)
        commands1
        ;;
    pattern2)
        commands2
        ;;
    *)
        default_commands
        ;;
esac

# 示例
read -p "请输入选择 (1-3): " choice
case $choice in
    1)
        echo "您选择了选项1"
        ;;
    2)
        echo "您选择了选项2"
        ;;
    3)
        echo "您选择了选项3"
        ;;
    *)
        echo "无效选择"
        ;;
esac
```

# 6. 循环结构

## for循环
```bash
# 基本for循环
for var in item1 item2 item3; do
    echo "Item: $var"
done

# 范围循环
for i in {1..5}; do
    echo "Number: $i"
done

# C风格for循环
for ((i=0; i<5; i++)); do
    echo "Count: $i"
done

# 遍历文件
for file in *.txt; do
    echo "Processing: $file"
done
```

## while循环
```bash
# 基本while循环
count=1
while [ $count -le 5 ]; do
    echo "Count: $count"
    ((count++))
done

# 读取文件
while read line; do
    echo "Line: $line"
done < filename.txt

# 无限循环
while true; do
    echo "Press Ctrl+C to exit"
    sleep 1
done
```

## until循环
```bash
# until循环（条件为假时执行）
count=1
until [ $count -gt 5 ]; do
    echo "Count: $count"
    ((count++))
done
```

## break和continue
```bash
# break - 跳出循环
for i in {1..10}; do
    if [ $i -eq 5 ]; then
        break
    fi
    echo "Number: $i"
done

# continue - 跳过本次循环
for i in {1..10}; do
    if [ $((i % 2)) -eq 0 ]; then
        continue
    fi
    echo "Odd number: $i"
done
```

# 7. 函数

## 函数定义和调用
```bash
# 函数定义
function_name() {
    commands
}

# 或者
function function_name {
    commands
}

# 函数调用
function_name

# 带参数的函数
greet() {
    echo "Hello, $1!"
    echo "Welcome to $2"
}

greet "John" "Linux Course"
```

## 函数返回值
```bash
# 返回状态码（0-255）
check_file() {
    if [ -f "$1" ]; then
        return 0  # 成功
    else
        return 1  # 失败
    fi
}

if check_file "test.txt"; then
    echo "文件存在"
fi

# 返回值（通过echo输出）
add() {
    echo $(($1 + $2))
}

result=$(add 5 3)
echo "Result: $result"
```

## 局部变量
```bash
my_function() {
    local var="local value"
    echo "Inside function: $var"
}

var="global value"
my_function
echo "Outside function: $var"
```

# 8. 输入输出重定向

## 标准输入输出
```bash
# 标准输入 (stdin) - 文件描述符 0
# 标准输出 (stdout) - 文件描述符 1
# 标准错误 (stderr) - 文件描述符 2

# 重定向输出
command > output.txt      # 覆盖输出
command >> output.txt     # 追加输出

# 重定向输入
command < input.txt

# 重定向错误
command 2> error.log      # 错误输出到文件
command 2>&1              # 错误重定向到标准输出
command &> all.log        # 所有输出到文件

# 丢弃输出
command > /dev/null 2>&1
```

## 管道
```bash
# 管道将一个命令的输出作为另一个命令的输入
ls -la | grep ".txt"
cat file.txt | wc -l
ps aux | grep nginx | awk '{print $2}'
```

## Here Document
```bash
# 多行输入
cat << EOF > file.txt
This is line 1
This is line 2
This is line 3
EOF

# 变量替换
name="John"
cat << EOF
Hello, $name!
Welcome to our course.
EOF
```

# 9. 字符串处理工具

## cut命令
```bash
# 按字段切割
echo "name:age:city" | cut -d: -f1   # 输出: name
echo "name:age:city" | cut -d: -f2   # 输出: age

# 按字符位置切割
echo "Hello World" | cut -c1-5       # 输出: Hello
```

## awk命令
```bash
# 基本用法
awk '{print $1}' file.txt           # 打印第一列
awk -F: '{print $1, $3}' /etc/passwd # 打印用户名和UID

# 条件过滤
awk '$3 > 1000 {print $1}' /etc/passwd

# 计算
awk '{sum += $1} END {print sum}' numbers.txt
```

## sed命令
```bash
# 替换
sed 's/old/new/' file.txt           # 替换每行第一个匹配
sed 's/old/new/g' file.txt          # 替换所有匹配

# 删除
sed '/pattern/d' file.txt           # 删除匹配行
sed '2,5d' file.txt                 # 删除第2-5行

# 插入
sed '2i\New line' file.txt          # 在第2行前插入
sed '2a\New line' file.txt          # 在第2行后插入
```

## grep命令
```bash
# 基本搜索
grep "pattern" file.txt

# 选项
grep -i "pattern" file.txt          # 忽略大小写
grep -v "pattern" file.txt          # 反向匹配
grep -r "pattern" directory/        # 递归搜索
grep -n "pattern" file.txt          # 显示行号
grep -E "pat1|pat2" file.txt        # 扩展正则
```

# 10. 脚本调试

## 调试选项
```bash
# 执行时启用调试
bash -x script.sh                   # 显示执行的命令
bash -v script.sh                   # 显示读取的命令
bash -n script.sh                   # 语法检查

# 脚本中启用调试
set -x                              # 开启调试
commands
set +x                              # 关闭调试

set -e                              # 遇到错误立即退出
set -u                              # 使用未定义变量时报错
```

## 调试技巧
```bash
# 打印调试信息
debug_print() {
    if [ "$DEBUG" = "true" ]; then
        echo "DEBUG: $@" >&2
    fi
}

DEBUG=true
debug_print "Variable value:" $var

# 陷阱（trap）
trap 'echo "Script interrupted"; exit 1' INT TERM

# 日志记录
exec > >(tee -a script.log)
exec 2>&1
echo "Script started at $(date)"
```

# 11. 实践练习

## 练习1：系统信息收集脚本
```bash
#!/bin/bash
# 系统信息收集脚本

echo "===== 系统信息 ====="
echo "主机名: $(hostname)"
echo "操作系统: $(uname -s)"
echo "内核版本: $(uname -r)"
echo "运行时间: $(uptime)"
echo ""
echo "===== CPU信息 ====="
echo "CPU型号: $(grep 'model name' /proc/cpuinfo | head -1 | cut -d: -f2)"
echo "CPU核心数: $(nproc)"
echo ""
echo "===== 内存信息 ====="
free -h
echo ""
echo "===== 磁盘使用 ====="
df -h
```

## 练习2：批量文件重命名
```bash
#!/bin/bash
# 批量重命名文件，添加日期前缀

DATE=$(date +%Y%m%d)

for file in *.txt; do
    if [ -f "$file" ]; then
        mv "$file" "${DATE}_${file}"
        echo "Renamed: $file -> ${DATE}_${file}"
    fi
done
```

## 练习3：日志分析脚本
```bash
#!/bin/bash
# 分析Apache/Nginx访问日志

LOG_FILE="/var/log/nginx/access.log"

echo "===== 访问量统计 ====="
echo "总请求数: $(wc -l < $LOG_FILE)"
echo ""

echo "===== Top 10 IP地址 ====="
awk '{print $1}' $LOG_FILE | sort | uniq -c | sort -nr | head -10
echo ""

echo "===== Top 10 请求URL ====="
awk '{print $7}' $LOG_FILE | sort | uniq -c | sort -nr | head -10
echo ""

echo "===== 状态码统计 ====="
awk '{print $9}' $LOG_FILE | sort | uniq -c | sort -nr
```

## 练习4：系统监控脚本
```bash
#!/bin/bash
# 系统资源监控脚本

THRESHOLD=80

# 检查CPU使用率
CPU_USAGE=$(top -bn1 | grep "Cpu(s)" | awk '{print $2}' | cut -d% -f1)
echo "CPU使用率: ${CPU_USAGE}%"

# 检查内存使用率
MEM_USAGE=$(free | grep Mem | awk '{printf("%.0f", $3/$2 * 100.0)}')
echo "内存使用率: ${MEM_USAGE}%"

# 检查磁盘使用率
DISK_USAGE=$(df -h / | tail -1 | awk '{print $5}' | cut -d% -f1)
echo "磁盘使用率: ${DISK_USAGE}%"

# 告警
if [ $CPU_USAGE -gt $THRESHOLD ] || [ $MEM_USAGE -gt $THRESHOLD ] || [ $DISK_USAGE -gt $THRESHOLD ]; then
    echo "警告: 系统资源使用率超过 ${THRESHOLD}%"
fi
```

# 12. 课后作业

## 1. 基础脚本编写
1. 编写一个脚本，计算1到100的累加和
2. 编写一个脚本，判断一个数是否为素数
3. 编写一个脚本，实现简单的计算器功能（支持加减乘除）
4. 编写一个脚本，批量创建用户并设置密码

## 2. 系统管理脚本
1. 编写一个脚本，监控系统服务状态并自动重启失败的服务
2. 编写一个脚本，定期清理指定天数的日志文件
3. 编写一个脚本，备份指定目录并压缩
4. 编写一个脚本，检查磁盘空间并发送告警邮件

## 3. 数据处理脚本
1. 编写一个脚本，统计文本文件中每个单词出现的次数
2. 编写一个脚本，从日志文件中提取特定时间段的记录
3. 编写一个脚本，合并多个CSV文件并去重
4. 编写一个脚本，生成系统性能报告

## 4. 综合项目
设计一个系统维护脚本包，包含以下功能：
- 系统信息收集
- 性能监控
- 日志分析
- 自动备份
- 安全扫描

通过本章学习，你应该能够：
1. 掌握Shell脚本的基本语法和结构
2. 熟练使用变量、数组和字符串操作
3. 掌握条件判断和循环结构
4. 能够编写和使用函数
5. 熟练使用输入输出重定向和管道
6. 掌握常用文本处理工具（grep、awk、sed）
7. 能够编写实用的系统管理和数据处理脚本
8. 掌握脚本调试技巧