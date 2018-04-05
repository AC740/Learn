### Define Deployment Variables
{
$location = 'EAST US'
$resourceGroupName = 'Andrew-Test-Grp-Copy'
$resourceDeploymentName = 'andrewtestgrpcopydeploy'
$templatePath = $env:SystemDrive + '\' + 'GitHub\Learn\Task7_Storage\test'
$templateFile = 'template.json'
$template = $templatePath + '\' + $templateFile
}

### Create Resource Group
{
New-AzureRmResourceGroup `
    -Name $resourceGroupName `
    -Location $location `
    -Verbose -Force
}

### Deploy Resources
{
New-AzureRmResourceGroupDeployment `
    -Name $resourceDeploymentName `
    -ResourceGroupName $resourceGroupName `
    -TemplateFile $template `
    -Verbose -Force
}