properties {
	$configuration = "Release"
	$sln_name = "DataStructures.sln"
}

task set-chocolatey-path {
	$script:chocolateyDir = $null
	if ($env:ChocolateyInstall -ne $null) {
		$script:chocolateyDir = $env:ChocolateyInstall;
	} elseif (Test-Path (Join-Path $env:SYSTEMDRIVE Chocolatey)) {
        $script:chocolateyDir = Join-Path $env:SYSTEMDRIVE Chocolatey;
    } elseif (Test-Path (Join-Path ([Environment]::GetFolderPath("CommonApplicationData")) Chocolatey)) {
		$script:chocolateyDir = Join-Path ([Environment]::GetFolderPath("CommonApplicationData")) Chocolatey;
	}

    Write-Output "Chocolatey installed at $script:chocolateyDir";
}

task restore-nuget-packages -depends set-chocolatey-path {
    $chocolateyBinDir = Join-Path $script:chocolateyDir -ChildPath "bin";
    $nugetExe = Join-Path $chocolateyBinDir -ChildPath "NuGet.exe";
	exec { & $nugetExe install NUnit.ConsoleRunner -OutputDirectory ..\packages }
	exec { & $nugetExe install OpenCover -OutputDirectory ..\packages }
	exec { & $nugetExe install coveralls.io -OutputDirectory ..\packages }
    exec { dotnet restore "..\$sln_name" }
}

task build {
	exec { dotnet build -c $configuration ..\$sln_name }
}

task unit-test {
	$nunitConsole = (Resolve-Path "..\packages\NUnit.ConsoleRunner.*\tools\nunit3-console.exe").ToString()
    $testsDlls = (Resolve-Path "..\tests\DataStructures.UnitTests\bin\Release\net462\*.UnitTests.dll").ToString()
	$opencover = (Resolve-Path "..\packages\OpenCover*\tools\OpenCover.Console.exe").ToString()
	exec { & $opencover -register:user -target:$nunitConsole -targetargs:"$testsDlls" -filter:"+[DataStructures*]* -[*UnitTests]*" -output:..\coverage.xml }
}

task coveralls -depends unit-test {
	$coveralls = (Resolve-Path "..\packages\coveralls.io.*\tools\coveralls.net.exe").ToString()
	$coverageReport = (Resolve-Path "..\coverage.xml").ToString()
	exec { & $coveralls --opencover $coverageReport -r $env:COVERALLS_REPO_TOKEN }
}

task report -depends build, unit-test {
	$reportGenerator = (Resolve-Path "..\packages\reportgenerator\ReportGenerator.exe").ToString()
	exec { & $reportGenerator -reports:..\coverage.xml -targetdir:.\reports --reporttypes:Html }
	exec { & Invoke-Item .\reports\index.htm }
}

task pre-build -depends restore-nuget-packages
task post-build -depends coveralls

task appveyor-install -depends pre-build
task appveyor-build -depends build
task appveyor-test -depends post-build
task test-coverage -depends report 
