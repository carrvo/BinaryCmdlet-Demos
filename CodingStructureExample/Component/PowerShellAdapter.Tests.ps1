using assembly .\Component.dll
using namespace Example.Component
#Requires -Module @{ ModuleName='Pester'; RequiredVersion='4.10.1' }

Describe "PowerShell Adapters" {
	BeforeAll {
		Import-Module $PSScriptRoot\Algorithm.psd1
		Import-Module $PSScriptRoot\Component.psd1
	}

	It "cannot adapt a script method" {
		$dto = Get-DTO -Value 5
		{ $dto | Invoke-Algorithm } | Should -Throw
	}

	It "can adapt a PowerShell class" {
		class Anonymous {
			[int]PlusOne(){return 9}
		}
		New-Object Anonymous | Invoke-Algorithm | Should -Be 9
	}

	It "can accept a PowerShell class" {
		# fails despite https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_using?view=powershell-7.2#example-3---load-classes-from-an-assembly
		# interestingly, if pre-load module (but not `using`) it will succeed
		class Explicit : Example.Component.IData {
			[int]PlusOne(){return 9}
		}
		New-Object Explicit | Invoke-Algorithm | Should -Be 9
	}
}
