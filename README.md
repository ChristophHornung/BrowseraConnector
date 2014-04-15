BrowseraConnector
=================
BrowseraConnector is a small C# library to access the API of [Browsera](http://www.browsera.com). 

**Warning the library is currently in the alpha state and every part of the API is subject to change!**

## Features
- Low level wrapper to directly access the API
- Wrapper to start a test run or create new sites
- Poller that allows starting of a run and polling the results (images, etc...) into an output directory. This can be used to integrate Browsera more easily into a build pipeline. It is available through C# or as a console program.


## Todo
- Proper exceptions
- ~~Wrap into an MSBuild task~~

## MSBuild Sample

```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="4.0" DefaultTargets="Snapshot" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">

  <UsingTask AssemblyFile="$(BrowseraConnectorPath)" TaskName="BrowseraBuildTasks.CreateAndRunBrowseraTestTask" />

  <PropertyGroup>
	<BasePath>c:\pathToWhereYouAreBuilding</BasePath>
	<SnapshotPath>$(BasePath)/snapshots</SnapshotPath>
	<BrowseraConnectorPath>$(BasePath)/BrowseraBuildTasks.dll</BrowseraConnectorPath>
	<CustomJavascript>Your custom javascript to run at the start of the test(); Use this to login if you're having issues with Browsera auto-submitting your login details();</CustomJavascript>
	<BaselineBrowser>Your baseline browser (I use 'Chrome 33' at present)</BaselineBrowser>
	<SubmitInputId>The #id of your sigin button</SubmitInputId>
	<UsernameInputId>The #id of your username field</UsernameInputId>
	<PasswordInputId>The #id of your password field</PasswordInputId>
	<UserName>Your username to login</UserName>
	<Password>Your password to login</Password>
	<LoginUrl>https://mysite.com/loginPage</LoginUrl>
	<IsWebsiteLogin>If you're using basic auth (false) or the javascript/fields for login (true)</IsWebsiteLogin>
	<UseLogin>If you want this test to attempt to login or not</UseLogin>
	<SiteName>The name of your test (Browsera calls this a 'site')</SiteName>
	<ApiKey>Your API key</ApiKey>
  </PropertyGroup>
  
  <!-- This is where we specify a list of browsers to use for the test -->
  <ItemGroup>
  <Browsers Include="Internet Explorer 11"/>
  <Browsers Include="Firefox 24"/>
  <Browsers Include="Chrome 33"/>
  </ItemGroup>
  
  <!-- This is where we specify a list of urls for the test to visit -->
  <ItemGroup>
  <Pages Include="http://mywebsite.com/page1"/>
  <Pages Include="http://mywebsite.com/page2"/>
  </ItemGroup>

  <!-- This is the task that executes the test, it waits until its finished so it can take a very long time so
  set your timeouts accordingly! -->
  <Target Name="Snapshot">
    <Message Text="Snapshot starts"/>
	<!-- kill the files from the last test -->
    <RemoveDir Directories="$(SnapshotPath)"/>
	<!-- run the test -->
	<CreateAndRunBrowseraTestTask
		UseLogin = "$(UseLogin)"
		CustomJavascript = "$(CustomJavascript)"
		BaselineBrowser = "$(BaselineBrowser)" 
		LoginUrl = "$(LoginUrl)"
		BaseLineBrowser = "$(BaselineBrowser)"
		SubmitInputId = "$(SubmitInputId)"
		UsernameInputId = "$(UsernameInputId)"
		PasswordInputId = "$(PasswordInputId)"
		Username = "$(Username)"
		Password = "$(Password)"
		IsWebsiteLogin = "$(IsWebsiteLogin)"
		SiteName = "$(SiteName)"
		ApiKey = "$(ApiKey)"
		ResultDirectory = "$(SnapshotPath)"
		Pages="@(Pages)"
		Browsers="@(Browsers)"
		>
	</CreateAndRunBrowseraTestTask>
    <Message Text="Snapshot ends"/>
  </Target>

</Project>
```


