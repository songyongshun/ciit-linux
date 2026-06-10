# 1. 删除原有的软件源配置文件
sudo rm -rf /etc/yum.repos.d/*
# 2. 下载阿里云的CentOS 8镜像源配置文件
sudo wget -O /etc/yum.repos.d/CentOS-Base.repo https://mirrors.aliyun.com/repo/Centos-vault-8.5.2111.repo 
# 3. 清理YUM缓存并生成新的缓存
sudo yum clean all
sudo yum makecache
# 4 添加EPEL软件源（Extra Packages for Enterprise Linux）
sudo yum -y install epel-release
# 5. 更新软件包列表
sudo yum check-update

sudo yum -y install libatomic
curl -OL https://gitee.com/RubyMetric/nvm-cn/raw/main/install.sh
bash install.sh
source ~/.bashrc
nvm install 26
npm install -g @tencent-ai/codebuddy-code --verbose


