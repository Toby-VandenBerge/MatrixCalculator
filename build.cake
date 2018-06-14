#tool "nuget:?package=GitVersion.CommandLine"
#tool "nuget:?package=NUnit.ConsoleRunner&version=3.4.0"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solutionPath = "./InterviewMatrix.sln";
var projectDir = "./src/InterviewMatrix";
var buildDir = Directory(projectDir) + Directory("bin") + Directory(configuration);
GitVersion versionInfo = null;

Task("Default")
  .IsDependentOn("Test");
  
Task("Clean")
	.Does(() =>
	{
		CleanDirectory(buildDir);
	});

Task("Restore")
	.IsDependentOn("Clean")
    .Does(() =>
    {
        NuGetRestore(solutionPath);
    });

  
Task("Version")
	.Does(() => 
	{
		GitVersion(new GitVersionSettings{
			OutputType = GitVersionOutput.BuildServer,
			NoFetch = true
		});

		versionInfo = GitVersion(new GitVersionSettings{ OutputType = GitVersionOutput.Json, NoFetch = true });
	});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Version")
    .Does(() =>
    {
		var msBuildSettings = new MSBuildSettings
		{
			Configuration = configuration,
			Verbosity = Verbosity.Minimal
		};
		
        MSBuild(solutionPath, msBuildSettings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        NUnit3("./tests/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
			NoResults = true
        });
    });

RunTarget(target);