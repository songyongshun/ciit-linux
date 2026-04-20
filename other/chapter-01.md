---
title: "CentOS 桌面美化指南"
collection: teaching
type: "Undergraduate course"
permalink: /teaching/2026-spring-teaching/other-chapter-1
venue: "常州工业职业技术学院, 信息工程学院"
date: 2026-03-01
location: "Changzhou, China"
---

# CentOS 系统桌面美化实战指南

> 适用于 CentOS 7 / 8 / 9 Stream 版本，基于 GNOME 桌面环境

---

## ✅ 前置准备

### 1. 启用 EPEL 软件源
```bash
# CentOS 9 Stream
sudo dnf install epel-release -y

# CentOS 7
sudo yum install epel-release -y
```

### 2. 更新系统
```bash
sudo dnf update -y
```

---

## 🎨 基础美化配置

### 1. 安装 GNOME Tweaks 优化工具
```bash
sudo dnf install gnome-tweaks gnome-extensions-app -y
```

### 2. 安装常用桌面扩展
访问 https://extensions.gnome.org/ 安装以下扩展：
| 扩展名称 | 功能说明 |
|---------|---------|
| User Themes | 允许使用第三方主题 |
| Dash to Dock | 底部任务栏美化 |
| Arc Menu | Windows 风格开始菜单 |
| Blur My Shell | 毛玻璃效果 |
| Just Perfection | 界面元素自定义 |
| Clipboard Indicator | 剪贴板历史 |

---

## 🎭 主题安装配置

### 1. 安装 GTK 主题

#### Arc 主题 (推荐)
```bash
sudo dnf install arc-theme -y
```

#### Numix 主题
```bash
sudo dnf install numix-gtk-theme numix-icon-theme -y
```

#### Materia 主题
```bash
sudo dnf install materia-gtk-theme -y
```

### 2. 安装图标主题

#### Papirus 图标集 (推荐)
```bash
sudo dnf install papirus-icon-theme -y
```

#### Tela 图标集
```bash
sudo dnf copr enable daniruiz/flat-remix
sudo dnf install tela-icon-theme -y
```

### 3. 安装光标主题
```bash
sudo dnf install breeze-cursor-theme -y
```

---

## ⚙️ 高级美化设置

### 1. 窗口透明效果
```bash
# 安装透明扩展
sudo dnf install gnome-shell-extension-transparent-window -y
```

### 2. 动态壁纸
```bash
sudo dnf install variety -y
```

### 3. 终端美化
```bash
# 安装 zsh 和 oh-my-zsh
sudo dnf install zsh git -y
sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"

# 安装 powerlevel10k 主题
git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

# 修改 ~/.zshrc 配置
ZSH_THEME="powerlevel10k/powerlevel10k"
```

---

## 🚀 推荐最终效果配置

| 项目 | 推荐配置 |
|-----|---------|
| GTK 主题 | Arc-Dark |
| Shell 主题 | Arc-Dark |
| 图标主题 | Papirus-Dark |
| 光标主题 | Breeze |
| 窗口管理器 | GNOME 40+ |
| Dock 位置 | 底部居中 |
| 毛玻璃透明度 | 70% |

---

## 💡 常见问题

1. **主题不生效**: 确保已启用 User Themes 扩展
2. **图标显示异常**: 执行 `gtk-update-icon-cache` 更新缓存
3. **重启后设置丢失**: 用 dconf 备份配置
4. **高分屏适配**: 调整缩放比例为 125% 或 150%

---