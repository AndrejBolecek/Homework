
$nunit = ".\Tools\NUnit.Console\nunit3-console.exe"
$outDir = ".\test_results"
Get-ChildItem -Path $outDir -Include *.log -File -Recurse | foreach { $_.Delete()}
$tests = ".\bin\Debug\net6.0\Homework.dll"
$param = "--out=test_result.log"

# Run tests
& $nunit $tests $param --work=$outDir 

# open result
allure generate "allure-results" --clean
allure open "allure-report"