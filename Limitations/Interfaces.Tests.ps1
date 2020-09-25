Describe "Interfaces" {
	Import-Module $PSScriptRoot\bin\Debug\Interfaces.dll
	It "Has an Interface" {
		Get-Hello -Name "world" | Should Be "Hello world"
	}
	It "Not have documentation" {
		Get-Help Get-Hello -Parameter Name | ForEach-Object description | Should Not BeLike "*The name to say hello to.*"
	}
}
