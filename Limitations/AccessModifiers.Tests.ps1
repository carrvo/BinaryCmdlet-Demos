Import-Module $PSScriptRoot\bin\Debug\AccessModifiers.dll
Describe "Access Modifier on Parameters" {
	It "Public Works (default)" {
		Get-Hello -PublicName "world" | Should Be "Hello world"
	}
	It "Private Works" {
		Get-Hello -PrivateName "world" | Should Be "Hello world"
	}
	It "Protected Works" {
		Get-Hello -ProtectedName "world" | Should Be "Hello world"
	}
	It "Internal Works" {
		Get-Hello -InternalName "world" | Should Be "Hello world"
	}
	It "Protected Internal Works" {
		Get-Hello -ProtectedInternalName "world" | Should Be "Hello world"
	}
	It "Private Protected Works" {
		Get-Hello -PrivateProtectedName "world" | Should Be "Hello world"
	}
	It "No Setter Works" {
		Get-Hello -NoSetterName "world" | Should Be "Hello world"
	}
}
