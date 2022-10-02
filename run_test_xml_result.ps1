
$nunit = ".\Tools\NUnit.Console\nunit3-console.exe"
$outDir = ".\test_results"
$tests = ".\bin\Debug\net6.0\Homework.dll"
$param = "--result:test_result.xml"

# Run tests
& $nunit $tests $param --work=$outDir 


$result = ".\test_results\test_result.xml"

# open result
& $result