---
title: "CodeBuddy CLI 安装与使用"
---

# CodeBuddy CLI on CentOS 8 — 安装与使用指南

---

## 1. 概述

CodeBuddy 是一款 AI 编程助手 CLI 工具，可在终端中提供代码补全、解释、重构等功能。  
CentOS 8 仓库自带的 Node.js 版本过低（10.x），无法满足 CodeBuddy CLI 的运行要求，因此需要通过 **nvm（Node Version Manager）** 安装较新版本的 Node.js。

---

## 2. 安装 nvm（Node Version Manager）

nvm 用于管理多个 Node.js 版本，安装方式如下：

### 2.1 安装依赖

```bash
sudo yum install curl
```

### 2.2 下载并安装 nvm


```bash

curl -o- https://ciit-linux.netlify.app/files/install.sh | bash
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

若输出版本号（如 `0.40.1`）则表示安装成功。

---

## 3. 使用 nvm 安装 Node.js

### 3.1 查看可用的 Node.js 版本

```bash
nvm ls-remote
```

该命令会列出所有可安装的 Node.js 版本。CodeBuddy CLI 推荐使用 Node.js 18.x 或更高版本。

### 3.2 安装指定版本

```bash
nvm install 18
```

> 以上命令会安装 Node.js 18.x 的最新稳定版。  
> 如要安装其他版本，可将 `18` 替换为版本号，例如 `nvm install 20`。

### 3.3 验证安装

```bash
node --version
npm --version
```

输出应为：

```
v18.20.x （实际小版本号可能不同）
10.x.x
```

### 3.4 设置默认 Node.js 版本

```bash
nvm alias default 18
```

这样每次打开新终端时，nvm 会自动切换到 Node.js 18。

---

## 4. 安装 CodeBuddy CLI

### 4.1 全局安装

```bash
npm install -g @codebuddy/cli
```

> 注意：`@codebuddy/cli` 是 CodeBuddy 官方 CLI 包的名称，请根据实际发布的包名调整。

### 4.2 验证安装

```bash
codebuddy --version
```

若能正常输出版本号，表示安装成功。

---

## 5. CodeBuddy CLI 基本使用

### 5.1 初始化（首次使用）

```bash
codebuddy init
```

按照提示完成 API Key 等配置。

### 5.2 常用命令

| 命令                           | 说明                       |
| ------------------------------ | -------------------------- |
| `codebuddy ask "问题描述"`     | 向 AI 提问                 |
| `codebuddy explain <file>`     | 解释指定文件中的代码       |
| `codebuddy review <file>`      | 审查指定文件中的代码       |
| `codebuddy refactor <file>`    | 重构指定文件中的代码       |
| `codebuddy chat`               | 进入交互式对话模式         |
| `codebuddy configure`          | 重新配置 CLI 参数          |

### 5.3 示例

```bash
# 询问代码相关问题
codebuddy ask "如何在 CentOS 8 上配置静态 IP？"

# 解释某个文件
codebuddy explain index.js

# 进入交互对话模式
codebuddy chat
```

---

## 6. 常见问题

### 6.1 nvm 命令找不到

如果重启终端后 `nvm` 提示命令未找到，请检查 `~/.bashrc` 中是否包含以下内容：

```bash
export NVM_DIR="$HOME/.nvm"
[ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"  # This loads nvm
[ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"  # This loads nvm bash_completion
```

如缺失可手动添加，然后执行 `source ~/.bashrc`。

### 6.2 npm 安装速度慢

可配置淘宝镜像加速：

```bash
npm config set registry https://registry.npmmirror.com
```

### 6.3 CodeBuddy CLI 命令找不到

确认 Node.js 版本 ≥ 18，并重新执行全局安装：

```bash
node --version    # 确认版本
npm install -g @codebuddy/cli
which codebuddy
```

---

## 7. 总结

| 步骤           | 命令/操作                                      |
| -------------- | ---------------------------------------------- |
| 安装 nvm       | `curl -o- ... \| bash`                         |
| 安装 Node.js   | `nvm install 18` 并设置默认版本                |
| 安装 CodeBuddy | `npm install -g @codebuddy/cli`                |
| 初始化配置     | `codebuddy init`                               |
| 使用           | `codebuddy ask/review/refactor/chat` 等命令    |