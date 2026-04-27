#!/bin/bash

sudo yum install zsh-syntax-highlighting
echo "source /usr/share/zsh-syntax-highlighting/zsh-syntax-highlighting.zsh" >> ~/.zshrc

# 设置Zsh为默认Shell
chsh -s $(which zsh)