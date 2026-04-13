# WSL简介
Windows Subsystem for Linux (WSL) 是微软在 Windows 10 及更高版本中引入的一个功能，它允许用户在 Windows 系统上直接运行 Linux 发行版，而无需安装虚拟机或双系统。WSL 提供了一个完整的 Linux 环境，包括命令行工具、开发工具和应用程序，使得开发者可以在 Windows 上无缝地进行 Linux 开发。

WSL 有两个主要版本：
- **WSL 1**：通过一个兼容层将 Linux 系统调用转换为 Windows 系统调用，提供了良好的兼容性。
- **WSL 2**：使用轻量级的虚拟机技术，提供了更好的性能和完全的 Linux 内核支持。

# 安装WSL
# 检查系统要求
在安装 WSL 之前，请确保您的 Windows 系统满足以下要求：
- Windows 10 版本 2004 及以上（内部版本 19041 及以上）或 Windows 11
- 64位处理器
- 至少 4GB 的 RAM（推荐 8GB 或更多）

# 启用WSL功能
1. 以管理员身份打开 PowerShell 或命令提示符。
2. 运行以下命令启用 WSL 功能：
   ```powershell
   wsl --install
   ```
   这个命令会自动启用必要的 Windows 功能并安装 WSL 2 和默认的 Linux 发行版（通常是 Ubuntu）。

3. 安装完成后，重启计算机。

# 手动安装WSL（可选）
如果您需要手动控制安装过程，可以按照以下步骤操作：

1. 启用 WSL 功能：
   ```powershell
   dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart
   ```

2. 启用虚拟机平台功能：
   ```powershell
   dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart
   ```

3. 重启计算机。

4. 设置 WSL 2 为默认版本：
   ```powershell
   wsl --set-default-version 2
   ```

# 安装Ubuntu
# 从Microsoft Store安装
1. 打开 Microsoft Store。
2. 搜索 "Ubuntu"。
3. 选择 "Ubuntu 22.04 LTS" 或最新版本。
4. 点击 "获取" 或 "安装" 按钮下载并安装。

# 使用命令行安装
您也可以通过命令行安装特定的 Ubuntu 版本：
```powershell
wsl --install -d Ubuntu-22.04
```

# 配置Ubuntu
# 首次启动
1. 安装完成后，在开始菜单中找到并启动 Ubuntu。
2. 系统会提示您创建一个新的用户账户和密码。请记住这个密码，因为您在使用 sudo 命令时需要输入它。

# 更新系统
首次启动后，建议立即更新系统：
```bash
sudo apt update && sudo apt upgrade -y
```

# 安装常用工具
为了提高开发效率，您可以安装一些常用的开发工具：
```bash
sudo apt install -y git vim curl wget build-essential
```

# 配置WSL
## 设置默认用户
如果您希望以特定用户身份启动 WSL，可以使用以下命令：
```powershell
ubuntu2204 config --default-user yourusername
```
（将 `yourusername` 替换为您在 Ubuntu 中创建的用户名）

## 配置网络
WSL 2 默认使用 NAT 网络模式，通常不需要额外配置。如果您需要访问 Windows 主机上的服务，可以使用 `localhost` 或 `127.0.0.1`。

## 文件系统访问
WSL 可以无缝访问 Windows 文件系统。Windows 驱动器会自动挂载在 `/mnt/` 目录下。例如，C 盘可以通过 `/mnt/c/` 访问。

# 性能优化
## 启用 Zsh 和 Oh My Zsh
为了获得更好的命令行体验，您可以安装 Zsh 和 Oh My Zsh：
```bash
sudo apt install -y zsh
sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"
```

## 配置 VS Code
VS Code 提供了 WSL 扩展，可以让您直接在 WSL 环境中开发：
1. 在 Windows 中安装 VS Code。
2. 安装 "Remote - WSL" 扩展。
3. 在 WSL 中打开项目：`code .`

# 常见问题和解决方案
# WSL 2 启动失败
如果遇到 WSL 2 启动失败的问题，可以尝试以下解决方案：
1. 确保 Windows 虚拟化功能已启用。
2. 更新 Windows 到最新版本。
3. 重置 WSL：
   ```powershell
   wsl --shutdown
   wsl --unregister Ubuntu-22.04
   wsl --install -d Ubuntu-22.04
   ```

# 网络连接问题
如果遇到网络连接问题：
1. 检查 Windows 防火墙设置。
2. 确保 Windows 系统已连接到网络。
3. 尝试重启 WSL：
   ```powershell
   wsl --shutdown
   ```

# 文件权限问题
在 Windows 和 Linux 之间共享文件时可能会遇到权限问题。建议在 WSL 中处理文件，避免直接在 Windows 中修改 WSL 文件系统中的文件。

# 总结
通过本章的学习，您已经掌握了在 Windows 系统上安装和配置 WSL 以及 Ubuntu 的基本方法。WSL 为您提供了一个强大的 Linux 开发环境，让您可以在 Windows 上无缝地进行 Linux 开发。接下来，您可以开始使用这个环境进行各种 Linux 相关的学习和开发工作。