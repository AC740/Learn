 
 ### Instructions: ###
1. Sign up for a free github account.
2. Build several of the scenarios below. Be ready to explain your code structure, purpose, best practices, alternates etc.
3. NM is looking for your ability to research and recommend the right solution.
4. Use creativity and feel free improvise on each scenario.
5. Send the URL of the git repos to the recruiter before the interview. Make sure each repo has an updated readme file. NM is looking for your ability to document & walk through the solution.



### Scenarios: ###

1. Create a script that builds a load balanced IIS environment using Azure Resource manager templates. Use common best practices & be ready with explanation. (Use availability set, load
balancer)
2. Create a script that builds a load balanced NGNIX environment using Azure Resource manager templates. Use best practices & be ready with explanation.
3. Create a script using Azure CLI or PowerShell and ARM templates for the structure of a proper ARM Template Deployment via the command line
4. Create an Azure Policy to limit resource creation for specific resource types, enforce a specific group of tags, and limit location where resources can be deployed.
5. Using your preferred programming language build basic web application and deploy to Azure App Services. Be ready to discuss the best practices.
6. Create a code snippet and deploy it to an Azure Function that can be triggered via a schedule
7. Build a script to create two types of Azure Storage, a blob and a table. Add sample data to both storage locations that can be used for the following exercise. Create code to run from your desired location (local, Azure Function, etc.) to retrieve the content from table and print it to the screen. Create code to run from your desired location (local, Azure Function, etc) to run from anywhere that will retrieve the content from the blob storage and save it to local disk. Be ready to discuss the best practices of Azure Storage. 


### Answer: ###

The below script is used to deploy templates for each question. Before execute this script, the path of each template has to be modified, for example: $templatePath = $env:SystemDrive + '\' + 'GitHub\Learn\Task1_IIS\Scripts'.
### Define Deployment Variables
{
$location = 'EAST US'
$resourceGroupName = 'Andrew-iis-Grp'
$resourceDeploymentName = 'andrewiisgroup'
$templatePath = $env:SystemDrive + '\' + 'GitHub\Learn\Task1_IIS\Scripts'
$templateFile = 'iisiaastemplate.json'
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


1. Task1_IIS ==> This will create 2 virtual machines, a vnet, a load balance. 	

2. Task2_NGNIX ==> This is not completed.

3. Task3_Template ==> This will create two azure storages.

4. Task4_Policy ==> This is not completed.

5. Task5_Websites ==> This is a ASP.NET web sites and will be deployed from visual studio to azure using pubxml.
<?xml version="1.0" encoding="utf-8"?>
<!--
This file is used by the publish/package process of your Web project. You can customize the behavior of this process
by editing this MSBuild file. In order to learn more about this please visit https://go.microsoft.com/fwlink/?LinkID=208121. 
-->
<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <WebPublishMethod>MSDeploy</WebPublishMethod>
    <ResourceId>/subscriptions/8bd4b226-317a-4920-8b92-4263326776ed/resourcegroups/andrew-test-grp/providers/Microsoft.Web/sites/TestAndrewSimpleWeb</ResourceId>
    <ResourceGroup>andrew-test-grp</ResourceGroup>
    <PublishProvider>AzureWebSite</PublishProvider>
    <LastUsedBuildConfiguration>Release</LastUsedBuildConfiguration>
    <LastUsedPlatform>Any CPU</LastUsedPlatform>
    <SiteUrlToLaunchAfterPublish>http://testandrewsimpleweb.azurewebsites.net</SiteUrlToLaunchAfterPublish>
    <LaunchSiteAfterPublish>True</LaunchSiteAfterPublish>
    <ExcludeApp_Data>False</ExcludeApp_Data>
    <MSDeployServiceURL>testandrewsimpleweb.scm.azurewebsites.net:443</MSDeployServiceURL>
    <DeployIisAppPath>TestAndrewSimpleWeb</DeployIisAppPath>
    <RemoteSitePhysicalPath />
    <SkipExtraFilesOnServer>True</SkipExtraFilesOnServer>
    <MSDeployPublishMethod>WMSVC</MSDeployPublishMethod>
    <EnableMSDeployBackup>True</EnableMSDeployBackup>
    <UserName>$TestAndrewSimpleWeb</UserName>
    <_SavePWD>True</_SavePWD>
    <_DestinationType>AzureWebSite</_DestinationType>
  </PropertyGroup>
</Project>

6. Task6_Function ==> C# application and can be deployed into consumption plan.

7. Task7_Storage ==> 
	 #### Projects ####
	 For blob storage:
	 			SampleStorageHandler.DownLoadBlobs -> C# application. Will download blob into local disk, Porjects\BlobDataDownLoad\SampleData.
	For table storage
				SampleStorageHandler.SampleStorageHandler -> C# application. Will diplay table content on screen.
