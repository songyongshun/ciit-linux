---
title: "CodeBuddy CLI 安装与使用"
---
# CodeBuddy Code on CentOS 8 — 安装与使用指南

---

## 1. 概述

CodeBuddy  Code是一款 AI 编程助手 CLI 工具，可在终端中提供代码补全、解释、重构等功能。
CentOS 8 仓库自带的 Node.js 版本过低（10.x），无法满足 CodeBuddy Code 的运行要求，因此需要通过 **nvm（Node Version Manager）** 安装较新版本的 Node.js。

---

## 2. 安装 nvm（Node Version Manager）

nvm 用于管理多个 Node.js 版本，安装方式如下：

### 2.1 安装依赖

```bash
sudo yum install curl
sudo yum install libatomic #Node.js 在较新的版本中增加了对该库的依赖
```

### 2.2 下载并安装 nvm

```bash

curl -OL https://gitee.com/RubyMetric/nvm-cn/raw/main/install.sh
bash install.sh

```

> 上述命令会下载 nvm 安装脚本并自动执行，将 nvm 添加到 `~/.bashrc` 中。

### 2.3 使 nvm 生效

重新加载 shell 配置文件：

```bash
source ~/.bashrc
```

验证 nvm 是否安装成功：

```bash
nvm --version
```

若输出版本号（如 `0.40.4`）则表示安装成功。

---

## 3. 使用 nvm 安装 Node.js

### 3.1 查看可用的 Node.js 版本

```bash
nvm ls-remote
```

该命令会列出所有可安装的 Node.js 版本。CodeBuddy Code 推荐使用 Node.js 20.x 或更高版本。

### 3.2 安装指定版本

```bash
nvm install 26
```

> 以上命令会安装 Node.js 26.x 的最新稳定版。

### 3.3 验证安装

```bash
node --version
```

输出应为：

```
v26.2.0 （实际小版本号可能不同）
```

---

## 4. 安装 CodeBuddy Code

### 4.1 全局安装

```bash
npm install -g @tencent-ai/codebuddy-code --verbose
```

> 注意：`@tencent-ai/codebuddy-code` 是 CodeBuddy 官方 CLI 包的名称，请根据实际发布的包名调整。

### 4.2 验证安装

```bash
codebuddy --version
```

若能正常输出版本号，表示安装成功。

---

## 5. CodeBuddy Code 基本使用

### 5.1 初始化（首次使用）

```bash
mkdir buddy_work
cd buddy_work
codebuddy
# 选择信任此目录并继续
# 选择Log in via Chinese Site
```

会打开浏览器，按照提示登录并授权后，返回终端即可完成配置。

### 5.2 中文输入法

- 在设置->Regional Settings->Input Sources中添加输入法，选择Other->Chinese (Intelligent Pinyin)，即可使用中文输入法。
- 输入法设置:

```bash
ibus-setup
```

### 5.3 引入

你可以问：

- 帮我产生1到10之间的整数1000个，随机得到，统计各个整数出现的次数
- 帮我用html画一个红色圆，旁边有一个按钮，可以调节半径大小
