#Deploy current website via deploy.azure.com

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)


#Generic Deployment
You could point to your own repo. But note that because ARM doesn't allow dynamic keys, the sqlConn is only set to connectionString with the following names:
- DBContext
- MultiChannelToDoContext
- SchoolContext

MultiChannelToDoContext and SchoolContext are the connection string names used in this repo

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmkliu%2FToDoApp%2Fmaster%2Fazuredeploy.json) 

#Cli
You need to login first, two-factor auth doesn't work so either wait until Sep or use register an APP and use service principal to login

```
azure group create testrg -l "West US"
azure group deployment create -f azuredeploy.json -e azuredeploy-parameters.json -g testrg -n testdeploy -v
```
