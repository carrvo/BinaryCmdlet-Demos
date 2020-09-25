Import-Module $PSScriptRoot\bin\Debug\Interfaces.dll
Describe "Basic Interfaces" {
	It "Has an Interface" {
		Get-Hello -Name "world" | Should Be "Hello world"
	}
	It "Not have documentation" {
		Get-Help Get-Hello -Parameter Name | ForEach-Object description | Should Not BeLike "*The name to say hello to.*"
	}
}
Describe "Advanced Interfaces" {
	It "Interfaces are not acceptable" {
		{ Get-AdvancedHello -Name "world" } | Should Throw
	}
}
