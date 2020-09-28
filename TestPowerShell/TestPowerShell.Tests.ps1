Describe "Testing Binary Cmdlets" {
    $cred = Get-Credential -Message "Pester" -UserName $ENV:USERDOMAIN\$ENV:USERNAME
    It "Is Binary Cmdlet Though PowerShell" {
        Import-Module -Name $PSScriptRoot\bin\Debug\TestCmdlet1.dll
        Test-PowerShell1 -Name me | Should BeExactly "Hello me"
    }
    It "Is Executable Using Binary Cmdlet" {
        & $PSScriptRoot\bin\Debug\TestCmdlet2.exe me | Should BeExactly "Hello me"
    
    It "Can be Executed Remotely" {
        $sess = New-PSSession -ComputerName $ENV:COMPUTERNAME -Authentication Credssp -Credential $cred
        Invoke-Command -Session $sess -ScriptBlock {
            Import-Module -Name $script:PSScriptRoot\bin\Debug\TestCmdlet1.dll
            Test-PowerShell1 -Name me | Should BeExactly "Hello me"
		}
	}
    It "Can be Imported Remotely" {
        $sess = New-PSSession -ComputerName $ENV:COMPUTERNAME -Authentication Credssp -Credential $cred
        Get-Item $PSScriptRoot\bin\Debug\TestCmdlet1.dll | Import-Module -PSSession $sess
        Test-PowerShell1 -Name me | Should BeExactly "Hello me"
	}
}
