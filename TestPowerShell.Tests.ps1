Describe "Testing Binary Cmdlets" {
    It "Is Binary Cmdlet Though PowerShell" {
        Import-Module .\TestPowerShell1Cmdlet\TestPowerShell1Cmdlet\bin\Debug\TestPowerShell1Cmdlet.dll
        Test-PowerShell1 -Name me | Should BeExactly "Hello me"
    }
    It "Is Executable Using Binary Cmdlet" {
        .\TestPowerShell2\TestPowerShell2\bin\Debug\TestPowerShell2.exe me | Should BeExactly "Hello me"
    }
}
