# CIIT Linux 课程网站

常州工业职业技术学院 - Linux 系统管理课程 2026春季学期

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Statiq](https://img.shields.io/badge/built%20with-Statiq%20Web-green.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)

## 📚 课程简介

本课程面向本科学生，系统讲解 Linux 操作系统的基本概念、常用命令、系统管理与维护技能。通过理论学习与实践操作结合，帮助学生掌握企业级 Linux 环境管理能力。

## ✨ 课程特点

- ✅ 基于 Ubuntu 22.04 LTS 最新稳定版
- ✅ 完整的章节体系，从基础到高级
- ✅ 理论知识 + 实践操作 双重教学模式
- ✅ 每章节附带练习与实验环境
- ✅ 中文本地化教学内容

## 🚀 本地预览

本项目使用 Statiq Web 静态站点生成器构建

### 前置要求
- .NET 8.0 SDK 或更高版本

### 运行方式
```bash
# 克隆仓库
git clone https://github.com/songyongshun/ciit-linux.git
cd ciit-linux

# 本地预览网站
dotnet run --preview

# 仅构建静态文件
dotnet run
```

构建完成后，本地预览服务器将自动启动，默认访问地址: `http://localhost:5080`

## 📖 课程目录 (2026春季学期)

| 周数 | 章节 | 课程内容 |
|------|------|----------|
| 第4周 | 第1章 | Linux的界面、网络连接和基本文件操作 |
| 第5周 | 第2章 | WSL下Ubuntu的安装与配置 |
| 第6周 | 第3章 | Linux用户和权限管理 |
| 第9周 | 第4章 | Linux软件安装和包管理 |
| 第10周| 第5章 | vim编辑器的使用 |
| 第11周| 第6章 | Shell基础知识 |
| 第12周| 第7章 | Bash脚本编程 |
| 第13周| 第8章 | Linux文件目录结构 |
| 第14周| 第9章 | Linux系统进程管理 |
| 第15周| 第10章| Linux网络配置和管理 |
| 第16周| 第11章| Linux磁盘管理 |
| 第17周| 第12章| Linux系统安全和防火墙 |

## 📂 项目结构

```
ciit-linux/
├── input/                  # 网站内容源文件
│   ├── chapters/           # 课程章节 Markdown 文件
│   ├── index.md            # 首页
│   ├── settings.yml        # 站点配置
│   └── *.cshtml            # Razor 布局模板
├── theme/                  # Statiq 主题
├── output/                 # 构建后的静态文件 (生成后)
├── cache/                  # 构建缓存
├── Program.cs              # Statiq 入口程序
└── ciit-linux.csproj       # .NET 项目文件
```

## 🛠 技术栈

- **静态站点生成器**: [Statiq Web](https://statiq.dev/web/)
- **运行时**: .NET 8.0
- **样式**: Bootstrap 5 + SCSS
- **部署**: GitHub Pages

## 📝 课程说明

1. 建议按照章节顺序学习，确保掌握必要的前置知识
2. 每个章节都包含理论讲解和实践练习
3. 所有操作都可以在 WSL、虚拟机或云服务器环境中进行
4. 遇到问题可以通过 Issues 进行反馈

## 📄 许可证

本项目采用 MIT 许可证，详情请查看 [LICENSE](LICENSE.md) 文件。

---

> 🎓 常州工业职业技术学院 信息工程学院  
> 课程教师: 宋永顺