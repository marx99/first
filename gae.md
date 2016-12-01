TUTORIALDIR=~/src/my-first-project-151200/python_gae_quickstart-2016-12-01-10-30
git clone https://github.com/GoogleCloudPlatform/appengine-try-python-flask.git $TUTORIALDIR

cd $TUTORIALDIR
git checkout gcloud



1在云端 Shell 上测试应用
利用云端 Shell，您可以在部署之前先对应用进行测试，以确保其按照预期运行，就像在本地机器上进行调试一样。

要测试您的应用，请输入：
dev_appserver.py $PWD


2使用“网络预览”来预览您的应用
https://8080-dot-2201809-dot-devshell.appspot.com/?authuser=0

3终止预览实例
在云端 Shell 中按 Ctrl+C 终止应用的实例。

在回到您的工作目录后，您将可以继续操作：

~/src/my-first-project-151200/python_gae_quickstart-2016-12-01-10-30



1使用云端 Shell 部署
您可以使用云端 Shell 部署应用。要部署应用，请输入：
gcloud app deploy app.yaml --project my-first-project-151200


2访问应用
恭喜！您的应用已成功部署。应用的默认网址是 my-first-project-151200.appspot.com 。点击该网址即可访问应用。

3查看应用状态
您可以在 App 引擎信息中心里监控应用的状态，对应用进行检查。

打开控制台左侧的菜单，然后选择 App 引擎。


OVER
