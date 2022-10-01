
$nunit = ".\Tools\NUnit.Console\nunit3-console.exe"
$outDir = ".\test_results"
$tests = ".\bin\Debug\net6.0\Homework.dll"
# Run tests
& $nunit $tests --work=$outDir