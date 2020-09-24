Describe "Testing Binary Cmdlets" {
    It "Is Binary Cmdlet Though PowerShell" {
        Import-Module -Name .\bin\Debug\TestCmdlet1.dll
        Test-PowerShell1 -Name me | Should BeExactly "Hello me"
    }
    It "Is Executable Using Binary Cmdlet" {
        .\bin\Debug\TestCmdlet2.exe me | Should BeExactly "Hello me"
    }
}
