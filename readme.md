Deploy current website via deploy.azure.com
[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)


Generic Deployment:

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmkliu%2FToDoApp%2Fmaster%2Fazuredeploy.json) 


azure group deployment create -f azuredeploy.json -e azuredeploy-parameters.json -g wayliu -v